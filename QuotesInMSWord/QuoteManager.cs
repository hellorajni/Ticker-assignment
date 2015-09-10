using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuotesInMSWord
{
    class QuoteManager
    {
        private const string COMMA = "%2C"; //hex values
        private const string SPACE = "%22";
        //Found it on web serach
        private const string BASE_URL = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        /// <summary>
        /// get quotes
        /// </summary>
        /// <param name="tickers">symbols</param>
        /// <returns>quotes</returns>
        public static List<Quote> Get(string[] tickers)
        {

            List<Quote> quotes = new List<Quote>(tickers.Count());
            foreach (var ticker in tickers)
            {
                quotes.Add(new Quote(ticker));
            }
            string url = string.Format(BASE_URL, String.Join(COMMA, tickers.Select(ticker => SPACE + ticker + SPACE).ToArray()));

            //TODO: Implement time out?
            XDocument doc = XDocument.Load(url);
            Parse(quotes, doc);
            
            return quotes;
        }

        /// <summary>
        /// parse doc and update quotes
        /// </summary>
        /// <param name="quotes"></param>
        /// <param name="doc"></param>
        private static void Parse(List<Quote> quotes, XDocument doc)
        {
            //TODO: Define all strings as constants 
            XElement results = doc.Root.Element("results");

            foreach (Quote quote in quotes)
            {
                XElement xQuote = results.Elements("quote").First(ele => ele.Attribute("symbol").Value == quote.Ticker);

                if (xQuote != null)
                {
                    //quote.Ticker is populated as input
                    quote.ChangeInPercent = GetDouble(xQuote.Element("ChangeinPercent").Value);
                    quote.DayLow = GetDouble(xQuote.Element("DaysLow").Value);
                    quote.DayHigh = GetDouble(xQuote.Element("DaysHigh").Value);
                    quote.YearLow = GetDouble(xQuote.Element("YearLow").Value);
                    quote.YearHigh = GetDouble(xQuote.Element("YearHigh").Value);

                    quote.Name = xQuote.Element("Name").Value;
                }
                else
                { 
                //TODO: error handling here or validate before calling this method
                }
            }
        }

        private static double? GetDouble(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            input = input.Replace("%", "");//percent in change come with %

            double value;

            if (double.TryParse(input, out value))
                return value;
            else
            return null;
        }


    }
}

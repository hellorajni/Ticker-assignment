using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesInMSWord
{
    public class Quote
    {
        public Quote(string ticker)
        {
            Ticker = ticker;
        }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public double? ChangeInPercent { get; set; }
        public double? DayHigh { get; set; }
        public double? DayLow { get; set; }
        public double? YearHigh { get; set; }
        public double? YearLow { get; set; }
    }
}

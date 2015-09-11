using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace QuotesInMSWord
{
    public class TickerInputViewModel : IDataErrorInfo
    {
        #region Properties
        
        private bool IsProcessing = false;

        public string InputSymbols { get; set; }
        
        public ObservableCollection<Quote> Quotes { get; set; } //set explicitly

        public ICommand GenerateTableCommand { get; set; }
        
        #endregion

        #region Contructor
        public TickerInputViewModel()
        {
            GenerateTableCommand = new DelegateCommand(Execute, CanExecute);
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return IsAllowed(InputSymbols) && !IsProcessing;
        }

        public bool IsAllowed(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var str = new Regex("^[a-zA-Z0-9,]*$");
            return str.IsMatch(text) && !text.Contains(",,");

        }

        public void Execute(object parameter)
        {
            IsProcessing = true;

            string[] tickers = this.InputSymbols.Split(new char[] { ',' });

            Task<List<Quote>> t1 = Task.Run(() =>
            {
                return QuoteManager.Get(tickers);//get quotes
            });
            t1.ContinueWith((x, y) =>
            {
                //updates WPF data grid
                Quotes.Clear();
                foreach (var q in x.Result)
                {
                    Quotes.Add(q);
                }

                //updates Winforms data grid
                Globals.ThisDocument.dgvQuotes.BeginInvoke((System.Action)(() =>
                {
                    Globals.ThisDocument.dgvQuotes.DataSource = x.Result;
                }));

            }, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(x =>
            {
                IsProcessing = false;
            });
        }
        #endregion

        #region IDataErrorInfo implementation
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "InputSymbols":
                        if (!IsAllowed(InputSymbols))
                            return "Invalid input! Enter comma separated symbols.";

                        break;
                }
                return string.Empty;
            }
        }
        #endregion
    }
}

using System.Collections.ObjectModel;
using System.Windows.Data;

namespace QuotesInMSWord
{
    public class CustomDataGridViewModel
    {
        private object _quotesLock = new object();

        public ObservableCollection<Quote> Quotes { get; set; }

        public CustomDataGridViewModel()
        {
            Quotes = new ObservableCollection<Quote>();
            BindingOperations.EnableCollectionSynchronization(Quotes, _quotesLock);
        }
    }
}

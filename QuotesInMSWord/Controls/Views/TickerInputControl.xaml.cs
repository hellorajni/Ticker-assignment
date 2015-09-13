using System.Windows.Controls;

namespace QuotesInMSWord
{
    /// <summary>
    /// Interaction logic for TickerInputControl.xaml
    /// </summary>
    public partial class TickerInputControl : UserControl
    {
        public TickerInputControl()
        {
            this.DataContext = new TickerInputViewModel();
            InitializeComponent();
        }
    }
}

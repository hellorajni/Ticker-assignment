using System.Windows.Controls;

namespace QuotesInMSWord
{
    /// <summary>
    /// Interaction logic for CustomDataGrid.xaml
    /// </summary>
    public partial class CustomDataGrid : UserControl
    {
        public CustomDataGrid()
        {
            this.DataContext = new CustomDataGridViewModel();
            InitializeComponent();
            
        }
    }
}

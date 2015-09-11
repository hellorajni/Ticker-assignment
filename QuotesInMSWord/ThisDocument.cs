using System.Windows.Forms;
using System.Drawing;

namespace QuotesInMSWord
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            //init data grid view custom settings
            dgvQuotes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvQuotes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvQuotes.CellFormatting += dgvQuotes_CellFormatting;
            
            var wfcHost = new WinformControlHostInputs();
            this.ActionsPane.Controls.Add(wfcHost);

            //reference the Quotes collection to inputs view model so that it can update.
            var inputVM = wfcHost._TickerInputControl.DataContext as TickerInputViewModel;
            var dataGridVM = this.quotesInMSWord_WinformControlHostDataGrid1._CustomDataGrid.DataContext as CustomDataGridViewModel;
            inputVM.Quotes = dataGridVM.Quotes;

        }

     
        void dgvQuotes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)//this.dgvQuotes.Rows[e.RowIndex].Cells["ChangeInPercent"];
                {
                    double changeInPercent = (double)e.Value;

                    if (changeInPercent > 0)
                        e.CellStyle.ForeColor = Color.Green;
                    else if (changeInPercent < 0)
                        e.CellStyle.ForeColor = Color.Red;
                    else
                    {
                        //default color if 0
                    }
                }
            }
            catch
            {
                //TODO: log message?
            }
        }

      
        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {

        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(this.ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(this.ThisDocument_Shutdown);

        }

        #endregion

    }
}


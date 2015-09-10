using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;
using System.Threading.Tasks;

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

            this.tbInputSymbols.TextChanged += tbInputSymbols_TextChanged;
            btnGenerateTable.Enabled = false; //assume there is no content in input text box
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

        void tbInputSymbols_TextChanged(object sender, EventArgs e)
        {
            //disable generate table button when no input is provided
            //TODO: Regex or validate input symbols
            this.btnGenerateTable.Enabled = !string.IsNullOrWhiteSpace(this.tbInputSymbols.Text);
        }

        /// <summary>
        /// Get qoutes then update data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateTable_Click(object sender, EventArgs e)
        {
            btnGenerateTable.Enabled = false; //avoid multiple clicks

            string[] tickers = this.tbInputSymbols.Text.Split(new char[] { ',' });

            Task<List<Quote>> t1 = Task.Run(() =>
            {

                return QuoteManager.Get(tickers);//get quotes
            });
            t1.ContinueWith((x, y) =>
            {
                dgvQuotes.BeginInvoke((System.Action)(() =>
                {
                    try
                    {
                        dgvQuotes.DataSource = x.Result;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error in getting quotes!" + Environment.NewLine + ex.Message); ;
                    }
                    btnGenerateTable.Enabled = true;
                }));

            }, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(x =>
            {
                dgvQuotes.BeginInvoke((System.Action)(() =>
                {
                    btnGenerateTable.Enabled = true; //enable it back in any case
                }));
            });

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
            this.btnGenerateTable.Click += new System.EventHandler(this.btnGenerateTable_Click);
            this.Startup += new System.EventHandler(this.ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(this.ThisDocument_Shutdown);

        }

        #endregion

    }
}


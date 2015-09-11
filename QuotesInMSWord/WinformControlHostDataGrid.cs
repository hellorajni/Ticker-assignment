using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace QuotesInMSWord
{
        [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
        [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
        public class WinformControlHostDataGrid : System.Windows.Forms.Integration.ElementHost
        {
            public CustomDataGrid _CustomDataGrid = new CustomDataGrid();

            public WinformControlHostDataGrid()
            {

                base.Child = _CustomDataGrid;
            }

        }
}

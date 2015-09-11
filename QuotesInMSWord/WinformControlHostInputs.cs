using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace QuotesInMSWord
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    public class WinformControlHostInputs : System.Windows.Forms.Integration.ElementHost
    {
        public TickerInputControl _TickerInputControl = new TickerInputControl();

        public WinformControlHostInputs()
        {
         
            base.Child = _TickerInputControl;
        }

    }
}

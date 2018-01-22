using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace ExtendedControls
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    class ExtendedTextBox_WinFormsHost : System.Windows.Forms.Integration.ElementHost
    {
        protected ExtendedTextBox extendedTextBox = new ExtendedTextBox();

        public ExtendedTextBox_WinFormsHost()
        {
            //base.Child = extendedTextBox;
        }

        public string TextValue
        {
            get
            {
                return extendedTextBox.TextValue;
            }
            set
            {
                extendedTextBox.TextValue = value;
            }
        }

    }
}

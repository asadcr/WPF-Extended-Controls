using ExtendedControls.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace ExtendedControls
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    public class ExtendedListView_WinformsHost : System.Windows.Forms.Integration.ElementHost
    {
        protected ExtendedListView ExtendedListView = new ExtendedListView();

        public ExtendedListView_WinformsHost()
        {
            base.Child = ExtendedListView;
        }

        public List<EmailViewModel> Emails
        {
            get
            {
                return ExtendedListView.Emails;
            }
            set
            {
                ExtendedListView.Emails = value;
            }
        }
    }
}

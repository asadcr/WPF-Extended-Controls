using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtendedControls
{
    /// <summary>
    /// Interaction logic for ExtendedTextBox.xaml
    /// </summary>
    public partial class ExtendedTextBox : UserControl
    {
        public ExtendedTextBox()
        {
            InitializeComponent();
            this.DataContext = this;
            TextValue = "";
        }

        public string TextValue
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }
    }
}

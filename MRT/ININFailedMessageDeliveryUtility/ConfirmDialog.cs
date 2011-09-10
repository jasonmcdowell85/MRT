using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog()
        {
            InitializeComponent();
        }
        // This throws an exception and doesn't seem to work.  Investigate later...
        // Instantiate this form object to pass in the values of Header, Message, Button1, Button2 to display customized form values.
        /*public ConfirmDialog(string Header, string Message, string Button1, string Button2)
        {
            try
            {
                this.Text = Header;
                this.Messagelabel.Text = Message;
                this.Yesbtn.Text = Button1;
                this.Nobtn.Text = Button2;
            }
            catch
            {
                MessageBox.Show("Why is this exception hit?");
            }
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MailDirForm : Form
    {
        public MailDirForm()
        {
            InitializeComponent();
        }
        // Used to obtain the directory Form value enterd by the user.
        public string GetDirectoryEntered()
        {
            return MailDirtxtbx.Text;
        }
        // Determine whether Other Directory is checked; if so, then don't set Mail/NoRetry and Mail/Outbox folder in the main().
        public bool GetOtherDirectory()
        {
            return OtherDirectory.Checked;
        }
        // Show 'help' on Mail directory folder path input.
        private void Help_Click(object sender, EventArgs e)
        {
            // Display the help contents for entering the Mail directory path
            string help = "";
            help += "---------------Directory path entry---------------\r\n";
            help += "If running this utility ON the IC server: \r\n";
            help += "- e.g., D:\\I3\\IC\\Mail \r\n \r\n";
            help += "If running this utility OFF server, use the UNC path: \r\n";
            help += "- e.g., \\\\ICServer01\\Mail \r\n\r\n\r\n";
            help += "*Please note the following requirements*: \r\n\r\n";
            help += "1) Read only - The IC server's Mail folder and all files under the NoRetry folder must be accessable.\r\n\r\n";
            help += "2) Read and write - In addition to the above requirements, the Mail\\Outbox folder must be accessable ";
            help += "and have file write access.  The ability to modify files under the NoRetry folder is also required.\r\n\r\n\r\n";

            help += "-------------Other Directory path entry-------------\r\n";
            help += "Check this option if the XML files do NOT reside under the Mail\\NoRetry folder.  ";
            help += "This should only be enabled if XML files have been manually copied or moved to a path other than the default NoRetry folder.  ";
            help += "The XML files must exist in the root of the directory path entered.";

            

            MessageBox.Show(help, "HELP | IC Mail directory");
        }

        private void Browsebtn_Click(object sender, EventArgs e)
        {
            // I don't know whether this can throw an exception, but try to catch anyways...
            try
            {
                // Pop the folder browse dialogue to select a local or network path for the Mail folder.
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.RootFolder = Environment.SpecialFolder.Desktop;
                    dlg.Description = "Select Folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        MailDirtxtbx.Text = (dlg.SelectedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught while opening the folder dialogue: " + ex.Message);
                TraceLogging.Warning("Exception caught while opening the folder dialogue for the Mail directory manual entry: " + ex.Message);
            }
        }
        // NOT USED
        public void Okbtn_Click(object sender, EventArgs e)
        {
            // ***THIS IS ALL NOW DUPLICATE CODE *** RETIRING CODE - Changes made and ported to new location.
            // Since the GetMailDirManual() method in Program.cs is directly tied into the OK result of the OK button,
            // this is all being done there now.
            //...
            MailDirtxtbx.Focus();
        }
        // This is no longer being used now (keydown is) since the autocomplete feature voided this
        private void MailDirtxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Okbtn.Focus();
            }*/
        }
        private void OtherDirectory_CheckedChanged(object sender, EventArgs e)
        {
            MailDirtxtbx.Focus();  // When the Other Directory option is toggled, place focus back on the text box
        }
        private void OtherDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the checkbox, 
            {
                if (OtherDirectory.Checked == true)  // If the Other directory checkbox is already checked, uncheck.
                {
                    OtherDirectory.Checked = false;
                }
                else if (OtherDirectory.Checked == false)  // If the Other directory checkbox isn't checked, check it.
                {
                    OtherDirectory.Checked = true;
                }
            }
        }

        private void MailDirtxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Okbtn.Focus();
            }
        }

        private void MailDirtxtbx_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(MailDirtxtbx.Text))  // If the directory exists, enable the ability to hit ok
            {
                Okbtn.Enabled = true;
            }
            else  // Disable the ok button
            {
                Okbtn.Enabled = false;
            }
        }
    }
}

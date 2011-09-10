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
    public partial class XMLRetrievalSettings : Form
    {
        public XMLRetrievalSettings(int TotalMessageCountTemp, string MailNoRetryDir, string MailDir, string OtherRootDirectoryOption)
        {
            InitializeComponent();
            TotalMessageCountlabel.Text = TotalMessageCountTemp.ToString();
            AllMessagesradiobtn.Checked = true;  // Default the "All" button to be enabled

            CurrentMailDirectorytextbox.Text = MailDir;
            if (OtherRootDirectoryOption == "True") 
            {
                OtherDirectory.Checked = true; // If the Other Directory checkbox was set in the mail dir manual form, set it here too.
                SpecifyXMLtxtbx.Text = MailDir;
            }  
            else if (OtherRootDirectoryOption == "False") 
            {
                OtherDirectory.Checked = false;  // If the Other Directory checkbox wasn't already set, leave unchecked.
                SpecifyXMLtxtbx.Text = MailNoRetryDir;  // If the Other Directory option is not enabled, default this textbox to the NoRetry folder.
            }  
            // Default to yes: sync the Specify XML (browse to) path with the mail directory path (+NoRetry directory)
            SpecifyXMLSyncchkbx.Checked = true;
            // Obtain the server name for which the application is being ran against
            ServerValuelabel.Text = Program.ServerRanAgainst(MailDir);
        }
        // After the show dialog is called in Program.cs and OK is clicked in this form, call this method to 
        // obtain the final values that have already been validated.
        public string[] GetXMLRetrievalSettings()
        {
            //Initialize the Option (1-all, 2-subcount, 3-oneXML) variable to default to none - "NULL".
            string RetrievalOption = "NULL";
            // Create array: Settings[0] = option (1-all, 2-subcount, 3-oneXML); 
            // Settings[1] = Message count filter; Settings[2] = Mail directory; Settings[3] = BrowseXML; Settings[4] = OtherDirectory 
            string[] Settings = new string[4];
            Settings[0] = "NULL";
            Settings[1] = "NULL";
            Settings[2] = "NULL";
            Settings[3] = "NULL";
            // Repop the form until all data is valid - directories exist and radio button clicked.
            bool RePopForm = true;
            while (RePopForm = true)
            {
                // The Import message 'all' radio button was selected when OK was pressed.
                if (AllMessagesradiobtn.Checked == true)
                {
                    if (Directory.Exists(CurrentMailDirectorytextbox.Text))
                    {
                        RetrievalOption = "1";
                        Settings[0] = RetrievalOption;
                        Settings[1] = TotalMessageCountlabel.Text;
                        Settings[2] = CurrentMailDirectorytextbox.Text;
                        Settings[3] = OtherDirectory.Checked.ToString();
                        RePopForm = false;  // This isn't necessary because the return will break the while loop
                        TraceLogging.Verbose("XMLRetrievalSettings form: 'All' radio button selected.");
                        TraceLogging.Verbose("XMLRetrievalSettings form: Total message count: " + Settings[1] + "; Current directory (exists): " + Settings[2] + "; Other directory: " + Settings[3]);
                        return Settings;
                    }
                    else  // The form should repop (below)
                    {
                        TraceLogging.Warning("The directory entered does not exist! " + CurrentMailDirectorytextbox.Text);
                        StatusFooter1.Text = "Directory does not exist! ";
                        StatusFooter2.Text = CurrentMailDirectorytextbox.Text;
                    }
                }
                // The Import message 'Specify quantity' radio button was selected when OK was pressed.
                else if (SpecifyQuantityradiobtn.Checked == true)
                {
                    if (Directory.Exists(CurrentMailDirectorytextbox.Text))
                    {
                        RetrievalOption = "2";
                        Settings[0] = RetrievalOption;
                        // Ensure the specified count is equal or less than the total count of messages in the folder.
                        // If this wasn't here, then the try/catch handling later on would catch this and not allow it, but I'd rather avoid that.
                        if (int.Parse(SpecifyMessageQuantitytxtbx.Text) <= int.Parse(TotalMessageCountlabel.Text))
                        {
                            Settings[1] = SpecifyMessageQuantitytxtbx.Text;
                        }
                        else
                        {
                            // The Specify quantity user input value is higher than the total message count, so just use the total message count.
                            Settings[1] = TotalMessageCountlabel.Text;
                        }
                        Settings[2] = CurrentMailDirectorytextbox.Text;
                        Settings[3] = OtherDirectory.Checked.ToString();
                        TraceLogging.Verbose("XMLRetrievalSettings form: 'Specify quantity' radio button selected.");
                        TraceLogging.Verbose("XMLRetrievalSettings form: specified message count: " + Settings[1] + "; Current directory (exists): " + Settings[2] + "; Other directory: " + Settings[3]);
                        RePopForm = false;  // This isn't necessary because the return will break the while loop
                        return Settings;
                    }
                    else  // The form should repop (below)
                    {
                        TraceLogging.Warning("The specified directory does not exist!  " + CurrentMailDirectorytextbox.Text); 
                        StatusFooter1.Text = "Directory does not exist!  ";
                        StatusFooter2.Text = CurrentMailDirectorytextbox.Text;
                    }
                }
                // The Import message 'Browse to XML' radio button was selected when OK was pressed.
                else if (BrowseToXMLradiobutton.Checked == true)
                {
                    if (File.Exists(SpecifyXMLtxtbx.Text))
                    {
                        RetrievalOption = "3";
                        Settings[0] = RetrievalOption;
                        Settings[1] = "1";  // Only one XML will be returned by directory + file name
                        Settings[2] = SpecifyXMLtxtbx.Text;
                        Settings[3] = OtherDirectory.Checked.ToString();
                        RePopForm = false;  // This isn't necessary because the return will break the while loop
                        TraceLogging.Verbose("XMLRetrievalSettings form: 'Browse to XML' radio button selected");
                        TraceLogging.Verbose("XMLRetrievalSettings form: Total message count: " + Settings[1] + "; Selected file (exists): " + Settings[2] + "; Other directory: " + Settings[3]);
                        return Settings;
                    }
                    else  // The form should repop (below)
                    {
                        // This should only be hit if the user manually modifies the field and doesn't use the browse dialog only
                        TraceLogging.Warning("The specified directory does not exist!  " + SpecifyXMLtxtbx.Text);
                        StatusFooter1.Text = "Directory does not exist!  ";
                        StatusFooter2.Text = SpecifyXMLtxtbx.Text;
                    }
                }
                else  // No radio button was selected.  This should no longer be possible since I default to the 'All' radio button
                {
                    StatusFooter1.Text = "Please select an 'Import messages' option!";
                    RetrievalOption = "NONE";
                    Settings[0] = RetrievalOption;  // Leave for now, however, this value will NEVER make it back to main()
                }
                //  Default to repopping form if the directory entered doesn't exist or if no radio button was selectred.
                if (this.ShowDialog() == DialogResult.OK)  // *** SHOULD i DO ANYTHING HERE LIKE I DO IN PROGRAM.CS???
                {
                    TraceLogging.Verbose("Manually re-launching form since the entered directory didn't exist.");
                    StatusFooter2.Text = "\r\nReady";
                }
                else  // The Window was manually exited (most likely).  Prompt to confirm exiting the program
                {
                    // Pop Confirm dialog.  *** add/move this to the top of main(), only line below
                    ConfirmDialog ConfirmDialog = new ConfirmDialog();
                    if (ConfirmDialog.ShowDialog() == DialogResult.Yes)
                    {
                        TraceLogging.Warning("The XMLRetrievalSettings form was closed intentionally.  Terminating application...");
                        Application.Exit();
                        Environment.Exit(0);  //  IS this considered as exiting successfully in the Win code?
                    }
                    else
                    {
                        // Leave empty for now.  The user did NOT choose to exit the application (yes).
                    }
                }
            }
            // Exiting the while loop.  I don't *think* the below return should ever be hit.
            TraceLogging.Warning("While LOOP exit hit!  ***return Settings okay?");  
            return Settings;
        }
        /*private void SpecifyMessageQuantitybtn_MouseClick(object sender, MouseEventArgs e)
        {
            // If the text box associated with the radio button has a curser placed in it (clicked), then highlight 
            // the associated radio button.
            SpecifyQuantityradiobtn.Checked = true;
        }
        private void SpecifyXMLbtn_MouseClick(object sender, MouseEventArgs e)
        {
            // If the text box associated with the radio button has a curser placed in it (clicked), then highlight 
            // the associated radio button.
            BrowseToXMLradiobutton.Checked = true;
        }
         */
        //  Rebrowse/select the Mail directory (again), if you'd like.  Should already be populated via auto or manual input.
        private void BrowsebtnMailDir_Click(object sender, EventArgs e)
        {
            // I'm not sure whether this can catch an exception, but try anyway.
            try
            {
                // Pop the folder browse dialogue to select a local or network path for the Mail folder.
                string MailDirTemp = "NULL";
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.SelectedPath = CurrentMailDirectorytextbox.Text;  // used to be: dlg.RootFolder = dlg.RootFolder = Environment.SpecialFolder.Desktop;
                    dlg.Description = "Select Folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        // Remove all trailing backslashes and add one back for formatting purposes.
                        MailDirTemp = Program.RemoveTrailingBackslashesAddOneBack(dlg.SelectedPath);
                        string MailNoRetry = MailDirTemp + "NoRetry\\";
                        // Update/refresh the total message counts in the selected folder
                        // Only update/sync the specify textbox with the mail dir box if checkbox is enabled...
                        if (SpecifyXMLSyncchkbx.Checked == true)
                        {
                            if (OtherDirectory.Checked == false)  // Assume the NoRetry folder to be the default for specify
                            {
                                TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailNoRetry).ToString();
                                CurrentMailDirectorytextbox.Text = MailDirTemp;
                                TraceLogging.Verbose("Mail directory updated: " + MailDirTemp);
                                StatusFooter1.Text = "Directory updated:  ";
                                StatusFooter2.Text = MailDirTemp;

                            }
                            else if (OtherDirectory.Checked == true) // Don't assume a NoRetry folder and set/update the specify path to the same as mail dir
                            {
                                TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailDirTemp).ToString();
                                CurrentMailDirectorytextbox.Text = MailDirTemp;
                                TraceLogging.Verbose("Other directory updated: " + MailDirTemp);
                                StatusFooter1.Text = "Directory updated:  ";
                                StatusFooter2.Text = MailDirTemp;
                            }
                        }
                        else if (SpecifyXMLSyncchkbx.Checked == false)  // Used for tracing only to more accurately reflect whether it's a Mail or Other directory
                        {
                            if (OtherDirectory.Checked == false)
                            {
                                TraceLogging.Verbose("Mail directory updated: " + MailDirTemp);
                                StatusFooter1.Text = "Directory updated:  ";
                                StatusFooter2.Text = MailDirTemp;
                            }
                            else if (OtherDirectory.Checked == true)
                            {
                                TraceLogging.Verbose("Other directory updated: " + MailDirTemp);
                                StatusFooter1.Text = "Directory updated:  ";
                                StatusFooter2.Text = MailDirTemp;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception caught while opening the folder dialogue: " + ex.Message); *** remove ?
                StatusFooter1.Text = "Exception opening folder:  ";
                StatusFooter2.Text = ex.Message;
                TraceLogging.Warning("Exception caught while opening the folder dialogue for the Mail directory re-entry: " + ex.Message);
            }
        }
        // Select the browse button to specify a specific XML to open.
        private void BrowsebtnToXML_Click(object sender, EventArgs e)
        {
            // I'm not sure whether this can catch an exception, but try anyway.
            try
            {
                OpenFileDialog SelectXML = new OpenFileDialog();
                // Set the directory to the value of the current textbox value, e.g., C:\I3\IC\Mail\NoRetry.
                SelectXML.InitialDirectory = SpecifyXMLtxtbx.Text;
                // Only display XML files
                SelectXML.Filter = "XML Files (*.xml)|*.xml";
                // *** Implement the ability to select multiple XML files.
                //*** SelectXML.Multiselect = true;
                // If OK is selected, populate the form textbox with the selected file.  Also, select the radio button.
                if (SelectXML.ShowDialog() == DialogResult.OK)
                {
                    BrowseToXMLradiobutton.Checked = true;
                    SpecifyXMLtxtbx.Text = SelectXML.FileName;  // *** To use a new multi-select feature, change to SelectXML.FileNames -> array
                    TraceLogging.Verbose("File selected successfully: " + SelectXML.FileName);
                    StatusFooter1.Text = "File selected successfully:  ";
                    StatusFooter2.Text = SelectXML.FileName;
                }
                // If OK is NOT selected, do nothing.  Is that even possible? ***
            }
            catch (Exception ex)
            {
                TraceLogging.Warning("Exception caught while opening the dialogue for XML file selection: " + ex.Message);
                StatusFooter1.Text = "Exception opening selection! ";
                StatusFooter2.Text = ex.Message;
            }
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            // This likely isn't needed for total message count checking now because CurrentMailDirectorytextbox_TextChanged does this dynamically as the text changes
            // Used mostly for form validation and updating variables if changed
            string CurrentDirectory = CurrentMailDirectorytextbox.Text;
            string MailNoRetry = Program.RemoveTrailingBackslashesAddOneBack(CurrentDirectory) + "NoRetry\\";
            string OtherDirectoryTemp = OtherDirectory.Checked.ToString();
            if (OtherDirectoryTemp == "False")
            {
                if (Directory.Exists(CurrentDirectory))
                {
                    // If the default of assuming Mail\NoRetry (Other option not set), update the total count to the Mail\NoRetry count
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailNoRetry).ToString();
                }
            }
            else if (OtherDirectoryTemp == "True")
            {
                if (Directory.Exists(CurrentDirectory))
                {
                    // If the Other Directory option is used, update the total count with the root of the other directory path
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(CurrentDirectory).ToString();
                }
            }
            // If the total count in the specified directory is 0 AND Option 1 (all) or 2 (specify count) is selected,
            // then prompt if the user would like to continue despite no XMLs in that directory.  Do if NOT option 3 (browseToXML)
            ConfirmDialog ConfirmDialog = new ConfirmDialog();
            if (TotalMessageCountlabel.Text == "0" && BrowseToXMLradiobutton.Checked == false)
            {  
                if (ConfirmDialog.ShowDialog() == DialogResult.Yes)  // Allow the main form to be popped, though no XML messages will be populated
                {
                    TraceLogging.Verbose("Intentionally proceeding to the main form with no user selected folder containing XML files to load.");
                    this.Ok.DialogResult = DialogResult.OK;
                }
                else if (ConfirmDialog.DialogResult == DialogResult.No) // If "Yes" is not selected, then do NOT continue to the main form and allow the user to make more changes.
                {
                    this.DialogResult = DialogResult.Retry;  
                    this.Close();
                }
            }
        }
        // Update/refresh the total message count for the current mail/other directory text box.
        private void UpdateCountbtn_Click(object sender, EventArgs e)
        {
            if (OtherDirectory.Checked == false)  // If the other direcectory checkbox is not enabled, assume Mail NoRetry
            {
                string MailNoRetry = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text) + "NoRetry\\";
                if (Directory.Exists(MailNoRetry))
                {
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailNoRetry).ToString();
                    StatusFooter1.Text = "Successfully updated 'Total message count' in: ";
                    StatusFooter2.Text = MailNoRetry;
                }
                else
                {
                    StatusFooter1.Text = "Update failed!";
                    StatusFooter2.Text = "Directory does not exist! " + MailNoRetry;
                }
            }
            else if (OtherDirectory.Checked == true)  // If the other directory checkbox is enabled, use the existing current other dir path.
            {
                string OtherDir = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text);
                if (Directory.Exists(OtherDir))
                {
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(OtherDir).ToString();
                    StatusFooter1.Text = "Successfully updated 'Total message count' in: ";
                    StatusFooter2.Text = OtherDir;
                }
                else
                {
                    StatusFooter1.Text = "Update failed!";
                    StatusFooter2.Text = "Directory does not exist: " + OtherDir;
                }
            }
        }
        private void SpecifyXMLSyncchkbx_CheckedChanged(object sender, EventArgs e)
        {
            // Only update/sync the specify textbox with the mail dir box if checkbox is enabled...
            if (SpecifyXMLSyncchkbx.Checked == true)
            {
                if (OtherDirectory.Checked == false)  // Asume the NoRetry folder to be the default for specify
                {
                    SpecifyXMLtxtbx.Text = CurrentMailDirectorytextbox.Text + "NoRetry\\";
                }
                else if (OtherDirectory.Checked == true) // Don't assume a NoRetry folder and set/update the specify path to the same as mail dir
                {
                    SpecifyXMLtxtbx.Text = CurrentMailDirectorytextbox.Text;
                }
            }
        }
        // Whenever the Other Directory option is checked, change the other corresponding text values that reference "mail" or "other" dir.
        private void OtherDirectory_CheckedChanged(object sender, EventArgs e)
        {
            string DirectoryTemp = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text);
            string MailNoRetry = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text) + "NoRetry\\";

            if (OtherDirectory.Checked == false)
            {
                // Change the label value to accurately reflect the option selected
                CurrentDirectorytxt.Text = "Current mail directory:";
                SpecifyXMLSyncchkbx.Text = "Sync to 'Current mail directory'";

                if (Directory.Exists(MailNoRetry))
                {
                    StatusFooter1.Text = "Directory updated: ";
                    StatusFooter2.Text = MailNoRetry;
                    SpecifyXMLtxtbx.Text = MailNoRetry;  // Update the specify xml txtbx to the current mail directory
                    // Update the total message count against the current directory when the checkbox is toggled. 
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailNoRetry).ToString();
                }
                else
                {
                    StatusFooter1.Text = "Directory doesn't exist!  ";
                    StatusFooter2.Text = MailNoRetry;
                }
            }
            else if (OtherDirectory.Checked == true)
            {
                // Change the label value to accurately reflect the option selected
                CurrentDirectorytxt.Text = "Current other directory:";
                SpecifyXMLSyncchkbx.Text = "Sync to 'Current other directory'";

                if (Directory.Exists(DirectoryTemp))
                {
                    StatusFooter1.Text = "Directory updated: ";
                    StatusFooter2.Text = DirectoryTemp;
                    SpecifyXMLtxtbx.Text = DirectoryTemp;  // Update the specify xml txtbx to the current other directory
                    // Update the total message count against the current directory when the checkbox is toggled.
                    TotalMessageCountlabel.Text = Program.GetXMLMailCount(DirectoryTemp).ToString();
                }
                else
                {
                    StatusFooter1.Text = "Directory doesn't exist!  ";
                    StatusFooter2.Text = DirectoryTemp;
                }
            }
            CurrentMailDirectorytextbox.Focus();  // When the Other Directory option is toggled, place focus back on the text box
        }
        private void statusStrip1_MouseHover(object sender, EventArgs e)
        {
            // *** doesn't work - this.toolTip1.SetToolTip(StatusFooter1.ToolTipText);

        }
        // Provide real-time changes based on this txtbx changing values
        private void CurrentMailDirectorytextbox_TextChanged(object sender, EventArgs e)
        {
            if (AllMessagesradiobtn.Checked == true)
            {
                if (Directory.Exists(CurrentMailDirectorytextbox.Text))
                {
                    Ok.Enabled = true;
                }
                else
                {
                    Ok.Enabled = false;
                }
            }
            else if (SpecifyQuantityradiobtn.Checked == true)
            {
                if (Directory.Exists(CurrentMailDirectorytextbox.Text) && SpecifyMessageQuantitytxtbx.Text.Length > 0)
                {
                    Ok.Enabled = true;
                }
                else
                {
                    Ok.Enabled = false;
                }
            }
            try
            {
                string CurrentDirectory = CurrentMailDirectorytextbox.Text;
                string MailNoRetry = Program.RemoveTrailingBackslashesAddOneBack(CurrentDirectory) + "NoRetry\\";
                string OtherDirectoryTemp = OtherDirectory.Checked.ToString();
                // Used to update the total message count in real time when the text is changed in the current mail directory textbox
                if (OtherDirectoryTemp == "False")
                {
                    if (Directory.Exists(MailNoRetry))
                    {
                        // If the default of assuming Mail\NoRetry (Other option not set), update the total count to the Mail\NoRetry count
                        TotalMessageCountlabel.Text = Program.GetXMLMailCount(MailNoRetry).ToString();
                        // Update the status footer
                        StatusFooter1.Text = "Directory updated: ";
                        StatusFooter2.Text = MailNoRetry;
                        //  Sync the specify text box with the current dir + "NoRetry\"
                        if (SpecifyXMLSyncchkbx.Checked == true)
                        {
                            SpecifyXMLtxtbx.Text = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text) + "NoRetry\\";
                        }
                    }
                    else
                    {
                        TotalMessageCountlabel.Text = "--"; // If the directory doesn't exit, blank the total count
                        StatusFooter1.Text = "Directory doesn't exist!";
                        StatusFooter2.Text = MailNoRetry;
                    }
                }
                else if (OtherDirectoryTemp == "True")
                {
                    if (Directory.Exists(CurrentDirectory) && CurrentDirectory.Length > 1)  // Length check used to fix "\", "/", ".", etc from being seen as valid directories.
                    {
                        // If the Other Directory option is used, update the total count with the root of the other directory path
                        TotalMessageCountlabel.Text = Program.GetXMLMailCount(CurrentDirectory).ToString();
                        // Update the status footer
                        StatusFooter1.Text = "Directory updated: ";
                        StatusFooter2.Text = CurrentDirectory;
                        //  Sync the specify text box with the current dir
                        if (SpecifyXMLSyncchkbx.Checked == true)
                        {
                            SpecifyXMLtxtbx.Text = CurrentMailDirectorytextbox.Text;
                        }
                    }
                    else
                    {
                        TotalMessageCountlabel.Text = "--"; // If the directory doesn't exit, blank the total count
                        StatusFooter1.Text = "Directory doesn't exist!";
                        StatusFooter2.Text = CurrentDirectory;
                    }
                }
                /*
                //  If the sync box is checked, then dynamically update the specify XML textbox as the current directory text changes
                if (SpecifyXMLSyncchkbx.Checked == true)
                {
                    if (OtherDirectory.Checked == true)  // If the Other directory option is checked, sync verbatim.
                    {
                        SpecifyXMLtxtbx.Text = CurrentMailDirectorytextbox.Text;
                    }
                    else if (OtherDirectory.Checked == false)  // If the Other directory option is NOT checked, sync with a "\NoRetry\" appended.
                    {
                        SpecifyXMLtxtbx.Text = Program.RemoveTrailingBackslashesAddOneBack(CurrentMailDirectorytextbox.Text) + "NoRetry\\";
                    }
                }
                */
                // Update the server name value if it changes.  Monitor for performance impact...? *** This isn't that necessary of a feature to warrant extra CPU cycles
                // ServerValuelabel.Text = Program.ServerRanAgainst(CurrentDirectory);  // *** After testing this, it GREATLY degraded performance and locked up (slow PC though).
            }
            catch (Exception ex)
            {
                TraceLogging.Verbose("Exception caught in CurrentMailDirectorytextbox_TextChanged, which can likely be ignored: " + ex.Message);
            }
        }
        // Whenever the focus leaves from the current directory text box, fire this handler
        private void CurrentMailDirectorytextbox_Leave(object sender, EventArgs e)
        {
            ServerValuelabel.Text = Program.ServerRanAgainst(CurrentMailDirectorytextbox.Text);  // Update the server name value if it changes.
        }
        // This isn't being used anymore (keydown is), since the autocomplete feature voided this.
        private void SpecifyMessageQuantitytxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus(); 
            }*/
        }
        // This isn't used anymore (keydown is) since the autocomplete feature voided this
        private void CurrentMailDirectorytextbox_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus();
            }*/
        }
        // This isn't used anymore (keydown is) since the autocomplete feature voided this
        private void SpecifyXMLtxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus();
            }*/
        }
        // Allow enter key to toggle checkbox
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
        // Allow enter key to toggle checkbox
        private void SpecifyXMLSyncchkbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')  // If the enter key (carriage return) is pressed in the checkbox, 
            {
                if (SpecifyXMLSyncchkbx.Checked == true)  // If the sync checkbox is already checked, uncheck.
                {
                    SpecifyXMLSyncchkbx.Checked = false;
                }
                else if (SpecifyXMLSyncchkbx.Checked == false)  // If the sync checkbox isn't checked, check it.
                {
                    SpecifyXMLSyncchkbx.Checked = true;
                }
            }
        }

        private void SpecifyMessageQuantitytxtbx_Enter(object sender, EventArgs e)
        {
            // If the text box associated with the radio button has a curser placed in it (clicked), then highlight 
            // the associated radio button.
            SpecifyQuantityradiobtn.Checked = true;
        }

        private void SpecifyXMLtxtbx_Enter(object sender, EventArgs e)
        {
            // If the text box associated with the radio button has a curser placed in it (clicked), then highlight 
            // the associated radio button.
            BrowseToXMLradiobutton.Checked = true;
        }

        private void SpecifyMessageQuantitytxtbx_Leave(object sender, EventArgs e)
        {
            // If the textbox is not null/empty (length >0) and the entered number is higher than the total count, 
            // change the value to the max (total count) when the txtbox looses focus
            if (SpecifyMessageQuantitytxtbx.Text.Length > 0)
            {
                if (int.Parse(TotalMessageCountlabel.Text) < int.Parse(SpecifyMessageQuantitytxtbx.Text))
                {
                    SpecifyMessageQuantitytxtbx.Text = TotalMessageCountlabel.Text;
                }
            }
        }

        private void SpecifyMessageQuantitytxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus();
            }
        }

        private void CurrentMailDirectorytextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus();
            }
        }

        private void SpecifyXMLtxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   // If the enter key (carriage return) is pressed in the form, give focus to the OK button.
            {
                Ok.Focus();
            }
        }

        private void SpecifyXMLtxtbx_TextChanged(object sender, EventArgs e)
        {
            if (BrowseToXMLradiobutton.Checked == true)  // Only disable/enable the ok button if the radio button is checked for this option
            {
                if (File.Exists(SpecifyXMLtxtbx.Text))  // If the file exists, enable the ok button
                {
                    Ok.Enabled = true;
                }
                else  // Disable the ok button
                {
                    Ok.Enabled = false;
                }
            }
        }
        private void SpecifyQuantityradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SpecifyQuantityradiobtn.Checked == true)
            {
                if (Directory.Exists(CurrentMailDirectorytextbox.Text) && SpecifyMessageQuantitytxtbx.Text.Length > 0)
                {
                    Ok.Enabled = true;
                }
                else
                {
                    Ok.Enabled = false;
                }
            }
        }
        private void AllMessagesradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if (AllMessagesradiobtn.Checked == true)
            {
                if (Directory.Exists(CurrentMailDirectorytextbox.Text))  // Enable the ok button
                {
                    Ok.Enabled = true;
                }
                else  // Disalbe the ok button
                {
                    Ok.Enabled = false;
                }
            }
        }
        private void SpecifyMessageQuantitytxtbx_TextChanged(object sender, EventArgs e)
        {
            int input;
            bool isNumeric = int.TryParse(SpecifyMessageQuantitytxtbx.Text, out input);  // true=number; false=not numeric
            if (isNumeric == false)  // If the character entered is NOT a number 
            {
                if (SpecifyMessageQuantitytxtbx.Text.Length < 2)
                {
                    SpecifyMessageQuantitytxtbx.Text = "";  // If the length is 0 or 1, blank out the entry
                }
                else  // If the length is 2 or more characters, remove only the last character and place the cursor at the end
                {
                    SpecifyMessageQuantitytxtbx.Text = SpecifyMessageQuantitytxtbx.Text.Remove(SpecifyMessageQuantitytxtbx.Text.Length - 1, 1);
                    SpecifyMessageQuantitytxtbx.SelectionStart = SpecifyMessageQuantitytxtbx.Text.Length;
                }
            }

            if (SpecifyQuantityradiobtn.Checked == true) // This should be set automatically when the box is clicked
            
                if (Directory.Exists(CurrentMailDirectorytextbox.Text) && SpecifyMessageQuantitytxtbx.Text.Length > 0 && int.Parse(SpecifyMessageQuantitytxtbx.Text) != 0)
                {
                    Ok.Enabled = true;
                }
                else
                {
                    Ok.Enabled = false;
                }
            }
        }
    }


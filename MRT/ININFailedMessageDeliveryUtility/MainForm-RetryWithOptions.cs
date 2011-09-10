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
    public partial class MainForm_RetryWithOptions : Form
    {
        string MoveFrom;
        string MoveTo;
        int selectedRowCount;
        int XMLArrayListLength;
        public MainForm_RetryWithOptions(string MoveFromtemp, string MoveTotemp, int selectedRowCounttemp, int XMLArrayListLengthtemp)
        {
            InitializeComponent();
            ChangeToBasicOptions();  // Set the default to the basic view
            MoveFrom = MoveFromtemp;
            MoveTo = MoveTotemp;
            selectedRowCount = selectedRowCounttemp;
            XMLArrayListLength = XMLArrayListLengthtemp;
            MoveMessagesFromlabel.Text = MoveFrom;
            MoveMessagesTotxtbx.Text = MoveTo;
            SelectedMessagesInTheGridlabel.Text = selectedRowCount.ToString();  // Set the number of selected messages in the grid for status displaying purposes
            TotalMessagesInTheGridlabel.Text = XMLArrayListLength.ToString();  // Set the total messages in the array (should be same as grid view) to the label for status displaying purposes
            TotalNumberOfMessagesToRetrytxtbx.Text = XMLArrayListLength.ToString();  // Set the default textbox value
        }
        public bool UseAdvancedOptions()
        {
            return UseAdvancedOptionsckbx.Checked;
        }
        public string MessageTypeToRetry() // not implemented yet *** jam, it may return okay now, verify (all, voicemail, etc)
        {
            return MessageTypeToRetrycmbbx.SelectedText;
        }
        public int TotalNumberOfMessagesToRetry()  
        {
            return int.Parse(TotalNumberOfMessagesToRetrytxtbx.Text);  // Convert the value (string) to an int(eger) and return it.
        }
        public bool RetryConsecutively()  // true=retry all defined messages ASAP; false=retry based on an interval
        {
            return RetryConsecutivelyradiobtn.Checked;  // If checked, then true, if not, then false, and 'Retry over intervals should be processed in the calling object.
        }
        public int Throttle()
        {
            return int.Parse(Throttletxtbx.Text);  // This will be validated in the text_changed field to confirm this is numeric
        }
        // If RetryConsecutively==false (Retry over intervals radio button is selected), then the calling object will need the interval and number each interval to retry
        public int RetryIntervalSeconds()
        {
            return int.Parse(RetryIntervalSecondstxbx.Text);  // Return the integer of the retry interval (seconds)
        }
        public int NumberOfMessagesToRetryPerInterval()
        {
            return int.Parse(NumberOfMessagestoRetryPerIntervaltxtbx.Text);  // Return the integer of the message count number to retry each interval.
        }
        public bool OnlyRetryMessagesSelectedInTheMainGridView()  // true=use row selection; false=don't use row selection and use the total number of messages to retry in the form
        {
            return OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Checked;  //
        }
        public string GetMoveTo()
        {
            return MoveTo;
        }

        private void RetryMessagesbtn_Click(object sender, EventArgs e) // This will be disabled until the path exists
        {
                MoveTo = MoveMessagesTotxtbx.Text; // Set the path already validated
                TraceLogging.Verbose("MoveTo directory set to (in the form): " + MoveTo);
        }
        private void BasicAdvancedOptionbtn_Click(object sender, EventArgs e)
        {
            // When clicked, grow the length to expose the advanced section (move retry confirmation down)
            // Size of the form will be  537, 451
            if (BasicAdvancedOptionbtn.Text == "Advanced")
            {
                ChangeToAdvancedOptions();
                BasicAdvancedOptionbtn.Text = "Basic";
            }
            else if (BasicAdvancedOptionbtn.Text == "Basic")
            {
                ChangeToBasicOptions();
                BasicAdvancedOptionbtn.Text = "Advanced";
            }
        }
        private void ChangeToAdvancedOptions()
        {
           
            // Grow the length to expose the advanced section (move retry confirmation down); Size of the form will be 547, 461
            string CurrentHeightstring = this.Size.Height.ToString();  // Obtain the current height
            int CurrentHeightint = int.Parse(CurrentHeightstring);
            string CurrentWidthstring = this.Size.Width.ToString();  // Obtain the current width
            int ToWidth = 547;  // This shouldn't change in this form
            int ToHeight = 453;  // The form will grow to this
            this.MaximumSize = new Size(547, ToHeight);  // Increase the max to allow the programmatical resizing next.
            for (int i = CurrentHeightint; i < ToHeight; i = i + 5)
            {
                this.Size = new Size(ToWidth, i);  // Grow the height
                //System.Threading.Thread.Sleep(2);  // Time in milliseconds
            }
            this.MinimumSize = new Size(547, ToHeight);  // Don't allow the user to resize the form.  It needs to be in resizable mode so that I can programmatically resize still.
            
        }
        private void ChangeToBasicOptions()
        {
            // Shrink the form to only show the 'basic' options to retry; Size of the form will be 547, 226
            int ToWidth = 547;
            int ToHeight = 226;
            this.MinimumSize = new Size(ToWidth, ToHeight);  // Increase the minimum to allow the programmatical resizing next

            this.Size = new Size(ToWidth, ToHeight);  // Resize (smaller)
            this.MaximumSize = new Size(ToWidth, ToHeight);  // Don't allow the user to resize the form.  It needs to be in resizable mode so that I can programmatically resize still.
        }

        private void UseAdvancedOptionsckbx_CheckedChanged(object sender, EventArgs e)  // Enable the advanced options
        {
            if (UseAdvancedOptionsckbx.Checked == true)
            {
                RetryConsecutivelyradiobtn.Enabled = true;
                RetryOverIntervalsradiobtn.Enabled = true;
                OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Enabled = true;

                if (OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Checked == true)  // If enabled, the below should be disabled (still)
                {
                    TotalNumberOfMessagesToRetrytxtbx.Enabled = false;
                    TotalNumberOfMessagesToRetrytxtbx.ReadOnly = true;
                    MessageTypeToRetrycmbbx.Enabled = false;
                }
                else  // If the 'only retry messages selected..' is not enabled, then able subdialogues
                {
                    TotalNumberOfMessagesToRetrytxtbx.Enabled = true;
                    TotalNumberOfMessagesToRetrytxtbx.ReadOnly = false;
                    MessageTypeToRetrycmbbx.Enabled = true;
                }
                IgnoreMessagesThatWereSelectedIntheMainFridView.Enabled = true;
                if (RetryConsecutivelyradiobtn.Checked == true)  // If enabled, then the retry over interval boxes need to remain disabled
                {
                    RetryIntervalSecondstxbx.Enabled = false;
                    RetryIntervalSecondstxbx.ReadOnly = true;
                    NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = false;
                    NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = true;
                }
                else  // If not enabled, then the option to retry over intervals is enabled, and these related textboxes should be enabled again.
                {
                    RetryIntervalSecondstxbx.Enabled = true;
                    RetryIntervalSecondstxbx.ReadOnly = false;
                    NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = true;
                    NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = false;
                }
            }
            else if (UseAdvancedOptionsckbx.Checked == false)  // Deactivate all advanced options
            {
                RetryConsecutivelyradiobtn.Enabled = false;
                RetryOverIntervalsradiobtn.Enabled = false;
                OnlyRetryMessagesSelectedInTheMainGridViewradiobtn.Enabled = false;
                IgnoreMessagesThatWereSelectedIntheMainFridView.Enabled = false;
                TotalNumberOfMessagesToRetrytxtbx.Enabled = false;
                TotalNumberOfMessagesToRetrytxtbx.ReadOnly = true;
                MessageTypeToRetrycmbbx.Enabled = false;
                RetryIntervalSecondstxbx.Enabled = false;
                RetryIntervalSecondstxbx.ReadOnly = true;
                NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = false;
                NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = true;
            }
        }

        private void RetryOverIntervalsradiobtn_CheckedChanged(object sender, EventArgs e)  // If enabled, disable and enable textboxes based on context
        {
            if (RetryOverIntervalsradiobtn.Checked == true)  // Enable the below checkboxes
            {
                Throttletxtbx.Enabled = false;
                RetryIntervalSecondstxbx.Enabled = true;
                RetryIntervalSecondstxbx.ReadOnly = false;
                NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = true;
                NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = false;
                
            }
            else  // Disable the below checkboxes, because RetryConsecutively is enabled
            {
                Throttletxtbx.Enabled = true;
                RetryIntervalSecondstxbx.Enabled = false;
                RetryIntervalSecondstxbx.ReadOnly = true;
                NumberOfMessagestoRetryPerIntervaltxtbx.Enabled = false;
                NumberOfMessagestoRetryPerIntervaltxtbx.ReadOnly = true;
            }
        }

        private void IgnoreMessagesThatWereSelectedIntheMainFridView_CheckedChanged(object sender, EventArgs e) // If enabled, enable and disable the below boxes based on context
        {
            if (IgnoreMessagesThatWereSelectedIntheMainFridView.Checked == true)  // Enable the boxes
            {
                TotalNumberOfMessagesToRetrytxtbx.Enabled = true;
                TotalNumberOfMessagesToRetrytxtbx.ReadOnly = false;
                MessageTypeToRetrycmbbx.Enabled = true;
            }
            else  // Disable the boxes
            {
                TotalNumberOfMessagesToRetrytxtbx.Enabled = false;
                TotalNumberOfMessagesToRetrytxtbx.ReadOnly = true;
                MessageTypeToRetrycmbbx.Enabled = false;
            }
        }

        private void MoveMessagesTotxtbx_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(MoveMessagesTotxtbx.Text))  // Enable the Retry button
            {
                RetryMessagesbtn.Enabled = true;
            }
            else  // Disable the Retry button 
            {
                RetryMessagesbtn.Enabled = false;
            }
        }

        private void Throttletxtbx_Leave(object sender, EventArgs e)
        {
            if (Throttletxtbx.Text == "" || int.Parse(Throttletxtbx.Text) < 200)  // *** jam, When the textbox looses control, if the value is less than 200 milliseconds (for example), revert it back to the minimum (200 for now).
            {
                Throttletxtbx.Text = "200";
            }
        }
        private void Throttletxtbx_TextChanged(object sender, EventArgs e)  // *** Right now, if a space is inserted at the beginning or end, it will allow it (but not in the middle).  I will int.Parse this anyway which may take care truncating spaces.
        {
            int input;
            bool isNumeric = int.TryParse(Throttletxtbx.Text, out input);  // true=number; false=not numeric
            if (isNumeric == false)  // If the character entered is NOT a number 
            {
                if (Throttletxtbx.Text.Length < 2)
                {
                    Throttletxtbx.Text = "";  // If the length is 0 or 1, blank out the entry
                }
                else  // If the length is 2 or more characters, remove only the last character and place the cursor at the end
                {
                    int SelectionLocationWhenTextWasEntered = Throttletxtbx.SelectionStart; // Store the location of the curser when text was entered
                    Throttletxtbx.Text = Throttletxtbx.Text.Remove(Throttletxtbx.SelectionStart - 1, 1);
                    if (Throttletxtbx.SelectionStart == Throttletxtbx.Text.Length)  // If the curser is at the end, then move/keep it at the end (otherwise it will default to the beginning)
                    {
                        Throttletxtbx.SelectionStart = Throttletxtbx.Text.Length;
                    }
                    else // If the curser is NOT at the end, then keep it in it's respective location (otherwise it will default to the beginning)
                    {
                        Throttletxtbx.SelectionStart = SelectionLocationWhenTextWasEntered - 1;  // Jump/keep the curser where it is (otherwise it will default to the beginning)
                    }
                }
            }
        }

        private void RetryIntervalSecondstxbx_TextChanged(object sender, EventArgs e)
        {
            int input;
            bool isNumeric = int.TryParse(RetryIntervalSecondstxbx.Text, out input);  // true=number; false=not numeric
            if (isNumeric == false)  // If the character entered is NOT a number 
            {
                if (RetryIntervalSecondstxbx.Text.Length < 2)
                {
                    RetryIntervalSecondstxbx.Text = "";  // If the length is 0 or 1, blank out the entry
                }
                else  // If the length is 2 or more characters, remove only the last character and place the cursor at the end
                {
                    int SelectionLocationWhenTextWasEntered = RetryIntervalSecondstxbx.SelectionStart; // Store the location of the curser when text was entered
                    RetryIntervalSecondstxbx.Text = RetryIntervalSecondstxbx.Text.Remove(RetryIntervalSecondstxbx.SelectionStart - 1, 1);
                    if (RetryIntervalSecondstxbx.SelectionStart == RetryIntervalSecondstxbx.Text.Length)  // If the curser is at the end, then move/keep it at the end (otherwise it will default to the beginning)
                    {
                        RetryIntervalSecondstxbx.SelectionStart = RetryIntervalSecondstxbx.Text.Length;
                    }
                    else // If the curser is NOT at the end, then keep it in it's respective location (otherwise it will default to the beginning)
                    {
                        RetryIntervalSecondstxbx.SelectionStart = SelectionLocationWhenTextWasEntered - 1;  // Jump/keep the curser where it is (otherwise it will default to the beginning)
                    }
                }
            }
        }

        private void NumberOfMessagestoRetryPerIntervaltxtbx_TextChanged(object sender, EventArgs e)
        {
            int input;
            bool isNumeric = int.TryParse(NumberOfMessagestoRetryPerIntervaltxtbx.Text, out input);  // true=number; false=not numeric
            if (isNumeric == false)  // If the character entered is NOT a number 
            {
                if (NumberOfMessagestoRetryPerIntervaltxtbx.Text.Length < 2)
                {
                    NumberOfMessagestoRetryPerIntervaltxtbx.Text = "";  // If the length is 0 or 1, blank out the entry
                }
                else  // If the length is 2 or more characters, remove only the last character and place the cursor at the end
                {
                    int SelectionLocationWhenTextWasEntered = NumberOfMessagestoRetryPerIntervaltxtbx.SelectionStart; // Store the location of the curser when text was entered
                    NumberOfMessagestoRetryPerIntervaltxtbx.Text = NumberOfMessagestoRetryPerIntervaltxtbx.Text.Remove(NumberOfMessagestoRetryPerIntervaltxtbx.SelectionStart - 1, 1);
                    if (NumberOfMessagestoRetryPerIntervaltxtbx.SelectionStart == NumberOfMessagestoRetryPerIntervaltxtbx.Text.Length)  // If the curser is at the end, then move/keep it at the end (otherwise it will default to the beginning)
                    {
                        NumberOfMessagestoRetryPerIntervaltxtbx.SelectionStart = NumberOfMessagestoRetryPerIntervaltxtbx.Text.Length;
                    }
                    else // If the curser is NOT at the end, then keep it in it's respective location (otherwise it will default to the beginning)
                    {
                        NumberOfMessagestoRetryPerIntervaltxtbx.SelectionStart = SelectionLocationWhenTextWasEntered - 1;  // Jump/keep the curser where it is (otherwise it will default to the beginning)
                    }
                }
            }
        }

        private void TotalNumberOfMessagesToRetrytxtbx_Leave(object sender, EventArgs e)
        {
            if (TotalNumberOfMessagesToRetrytxtbx.Text == "" || int.Parse(TotalNumberOfMessagesToRetrytxtbx.Text) > XMLArrayListLength) // If the total count entered in the box is empty or greater than the grid num.
            {
                TotalNumberOfMessagesToRetrytxtbx.Text = XMLArrayListLength.ToString();  // Shrink the value to a valid (max) value when the control (textbox) looses focus.
            }
        }

        private void TotalNumberOfMessagesToRetrytxtbx_TextChanged(object sender, EventArgs e)
        {
            int input;
            bool isNumeric = int.TryParse(TotalNumberOfMessagesToRetrytxtbx.Text, out input);  // true=number; false=not numeric
            if (isNumeric == false)  // If the character entered is NOT a number 
            {
                if (TotalNumberOfMessagesToRetrytxtbx.Text.Length < 2)
                {
                    TotalNumberOfMessagesToRetrytxtbx.Text = "";  // If the length is 0 or 1, blank out the entry
                }
                else  // If the length is 2 or more characters, remove only the last character and place the cursor at the end
                {
                    int SelectionLocationWhenTextWasEntered = TotalNumberOfMessagesToRetrytxtbx.SelectionStart; // Store the location of the curser when text was entered
                    TotalNumberOfMessagesToRetrytxtbx.Text = TotalNumberOfMessagesToRetrytxtbx.Text.Remove(TotalNumberOfMessagesToRetrytxtbx.SelectionStart - 1, 1);
                    if (TotalNumberOfMessagesToRetrytxtbx.SelectionStart == TotalNumberOfMessagesToRetrytxtbx.Text.Length)  // If the curser is at the end, then move/keep it at the end (otherwise it will default to the beginning)
                    {
                        TotalNumberOfMessagesToRetrytxtbx.SelectionStart = TotalNumberOfMessagesToRetrytxtbx.Text.Length;
                    }
                    else // If the curser is NOT at the end, then keep it in it's respective location (otherwise it will default to the beginning)
                    {
                        TotalNumberOfMessagesToRetrytxtbx.SelectionStart = SelectionLocationWhenTextWasEntered - 1;  // Jump/keep the curser where it is (otherwise it will default to the beginning)
                    }
                }
            }
        }

        private void RetryIntervalSecondstxbx_Leave(object sender, EventArgs e)
        {
            if (RetryIntervalSecondstxbx.Text == "")  // If the textbox is empty when the control/focus is lost
            {
                RetryMessagesbtn.Enabled = false;  // Disable the Retry button to prevent from it being pressed with a blank value in the text box
            }
            else if(RetryIntervalSecondstxbx.Text != "" && NumberOfMessagestoRetryPerIntervaltxtbx.Text != "") // If the textbox is not empty for all textboxes needing validated, ensure the retry button is enabled.
            { 
                RetryMessagesbtn.Enabled = true; // Allow messages to be retried
            } 
        }

        private void NumberOfMessagestoRetryPerIntervaltxtbx_Leave(object sender, EventArgs e)
        {
            if (NumberOfMessagestoRetryPerIntervaltxtbx.Text == "")  // If the textbox is empty when the control/focus is lost
            {
                RetryMessagesbtn.Enabled = false;  // Disable the Retry button to prevent from it being pressed with a blank value in the text box
            }
            else if (RetryIntervalSecondstxbx.Text != "" && NumberOfMessagestoRetryPerIntervaltxtbx.Text != "") // If the textbox is not empty for all textboxes needing validated, ensure the retry button is enabled.
            {
                RetryMessagesbtn.Enabled = true;  // Allow messages to be retried
            } 
        }

        private void RetryMessagesbtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}






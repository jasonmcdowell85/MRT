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
    public partial class MainForm_RetryMessages_SuccessfullyMoved : Form
    {
        string MessageString = "";
        public MainForm_RetryMessages_SuccessfullyMoved()
        {
            InitializeComponent();
            SuccessfullyMovedMessagestxtbx.Text = "Messages being retried (moved to Outbox):\r\n\r\n";  // Update the form instantly *** doesn't seem to work
            MessageString = "Messages being retried (moved to Outbox):\r\n\r\n";  // Include at the beginning of the string to update at the end of the retries
        }
        public void AddMessageMoved(string MessageMoved)
        {
            MessageString = MessageString +  MessageMoved;  // Add the moved message string to the existing list   
            SuccessfullyMovedMessagestxtbx.Text = MessageString;  // Replace the textbox with the latest list.  I'm not sure how to update a new entry, so I'll update the entire textbox each time.
        }
        public void UpdateMessagesMovedCount(int CountMoved)  // Updates the status at the bottom of the form to show the count increase.  The entire string for the message is passed in.
        {
            MessagesMovedStatuslabel.Text = CountMoved.ToString();  // *** This is no longer real-time since the form updates too quickly and whites out the textboxes, which is unhelpful.  Display at the end instead.
        }
        // By default, these labels are all hidden now due to the form not updating them quickly enough (blanks it out with white).  It will be hidden and then made visible when all messages are moved to Outbox
        public void ShowMessagesMovedStatus()
        {
            MessagesMovedStatuslabel.Visible = true;
            outoflabel.Visible = true;
            TotalMessagesToMovelabel.Visible = true;
            messagesmovedlabel.Visible = true;
        }
        public void TotalMessagesToMove(int TotalMessages)
        {
            TotalMessagesToMovelabel.Text = TotalMessages.ToString();  // *** This is no longer real-time since the form updates too quickly and whites out the textboxes, which is unhelpful.  Display at the end instead.
        }
        private void SuccessfullyMovedMessagestxtbx_TextChanged(object sender, EventArgs e)
        { /*
            SuccessfullyMovedMessagestxtbx.SelectionStart = SuccessfullyMovedMessagestxtbx.Text.Length;
            SuccessfullyMovedMessagestxtbx.ScrollToCaret();
            SuccessfullyMovedMessagestxtbx.Refresh();*/
        }
    }
}



/*  This was an attempt to reset the progress bar to 0 but didn't work.  I'll do it right away in the mainform instead now.

            MainForm MainForm = new MainForm();  // Instantiate MainForm
            //if (MainForm.ProgressBarStatus() == 100)  // Check whether the status is at 100 (done processing)
            // The above line was to be used to only reset the progress bar when it was at 100%, however, the status method seems to only return 0, so unconditionally resetting it below will be done.
            {
                MainForm.ProgressBarReset();    // If the progress is at 100, done, then reset the value to 0.
                MainForm.HideSubject();
            }
*/
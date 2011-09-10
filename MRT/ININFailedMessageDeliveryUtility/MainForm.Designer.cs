namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discardAllChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSavingAllChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitWithoutSavingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voicemailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callRecordingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageBodytxtbx = new System.Windows.Forms.TextBox();
            this.MainDataGrid = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.Searchtxtbx = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlainTextBodyckbx = new System.Windows.Forms.CheckBox();
            this.HTMLBodyckbx = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PopOutBodychkbx = new System.Windows.Forms.CheckBox();
            this.RetryMessagestxtbx = new System.Windows.Forms.Button();
            this.testoutboxtxtbx = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HideBottomPanelchkbx = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainBindingNavigator)).BeginInit();
            this.MainBindingNavigator.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainBindingNavigator
            // 
            this.MainBindingNavigator.AddNewItem = null;
            this.MainBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.MainBindingNavigator.DeleteItem = null;
            this.MainBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.MainBindingNavigator.Location = new System.Drawing.Point(0, 447);
            this.MainBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.MainBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.MainBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.MainBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.MainBindingNavigator.Name = "MainBindingNavigator";
            this.MainBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.MainBindingNavigator.Size = new System.Drawing.Size(951, 25);
            this.MainBindingNavigator.TabIndex = 102;
            this.MainBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem.Click += new System.EventHandler(this.bindingNavigatorCountItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Click += new System.EventHandler(this.bindingNavigatorPositionItem_Click);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(825, 450);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(126, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 101;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(951, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCurrentMessageToolStripMenuItem,
            this.saveAllChangesToolStripMenuItem,
            this.discardAllChangesToolStripMenuItem,
            this.exitSavingAllChangesToolStripMenuItem,
            this.exitWithoutSavingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveCurrentMessageToolStripMenuItem
            // 
            this.saveCurrentMessageToolStripMenuItem.Name = "saveCurrentMessageToolStripMenuItem";
            this.saveCurrentMessageToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.saveCurrentMessageToolStripMenuItem.Text = "Save currently selected message";
            this.saveCurrentMessageToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentMessageToolStripMenuItem_Click);
            // 
            // saveAllChangesToolStripMenuItem
            // 
            this.saveAllChangesToolStripMenuItem.Name = "saveAllChangesToolStripMenuItem";
            this.saveAllChangesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.saveAllChangesToolStripMenuItem.Text = "Save all changes";
            this.saveAllChangesToolStripMenuItem.Click += new System.EventHandler(this.saveAllChangesToolStripMenuItem_Click);
            // 
            // discardAllChangesToolStripMenuItem
            // 
            this.discardAllChangesToolStripMenuItem.Name = "discardAllChangesToolStripMenuItem";
            this.discardAllChangesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.discardAllChangesToolStripMenuItem.Text = "Discard all changes";
            // 
            // exitSavingAllChangesToolStripMenuItem
            // 
            this.exitSavingAllChangesToolStripMenuItem.Name = "exitSavingAllChangesToolStripMenuItem";
            this.exitSavingAllChangesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exitSavingAllChangesToolStripMenuItem.Text = "Exit saving all changes";
            // 
            // exitWithoutSavingToolStripMenuItem
            // 
            this.exitWithoutSavingToolStripMenuItem.Name = "exitWithoutSavingToolStripMenuItem";
            this.exitWithoutSavingToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exitWithoutSavingToolStripMenuItem.Text = "Exit without saving";
            this.exitWithoutSavingToolStripMenuItem.Click += new System.EventHandler(this.exitWithoutSavingToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.settingsToolStripMenuItem.Text = "Message Retrieval Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem,
            this.messageFilterToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.columnsToolStripMenuItem.Text = "Column visibility";
            this.columnsToolStripMenuItem.Click += new System.EventHandler(this.columnsToolStripMenuItem_Click);
            // 
            // messageFilterToolStripMenuItem
            // 
            this.messageFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allMessagesToolStripMenuItem,
            this.voicemailsToolStripMenuItem,
            this.faxesToolStripMenuItem,
            this.callRecordingsToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.messageFilterToolStripMenuItem.Name = "messageFilterToolStripMenuItem";
            this.messageFilterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.messageFilterToolStripMenuItem.Text = "Message filter | View";
            // 
            // allMessagesToolStripMenuItem
            // 
            this.allMessagesToolStripMenuItem.Name = "allMessagesToolStripMenuItem";
            this.allMessagesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.allMessagesToolStripMenuItem.Text = "All messages";
            // 
            // voicemailsToolStripMenuItem
            // 
            this.voicemailsToolStripMenuItem.Name = "voicemailsToolStripMenuItem";
            this.voicemailsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.voicemailsToolStripMenuItem.Text = "Voicemails";
            // 
            // faxesToolStripMenuItem
            // 
            this.faxesToolStripMenuItem.Name = "faxesToolStripMenuItem";
            this.faxesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.faxesToolStripMenuItem.Text = "Faxes";
            // 
            // callRecordingsToolStripMenuItem
            // 
            this.callRecordingsToolStripMenuItem.Name = "callRecordingsToolStripMenuItem";
            this.callRecordingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.callRecordingsToolStripMenuItem.Text = "Call Recordings";
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aToolStripMenuItem.Text = "View Help";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MessageBodytxtbx
            // 
            this.MessageBodytxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageBodytxtbx.Location = new System.Drawing.Point(12, 2);
            this.MessageBodytxtbx.Multiline = true;
            this.MessageBodytxtbx.Name = "MessageBodytxtbx";
            this.MessageBodytxtbx.ReadOnly = true;
            this.MessageBodytxtbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageBodytxtbx.Size = new System.Drawing.Size(807, 133);
            this.MessageBodytxtbx.TabIndex = 102;
            // 
            // MainDataGrid
            // 
            this.MainDataGrid.AllowUserToAddRows = false;
            this.MainDataGrid.AllowUserToDeleteRows = false;
            this.MainDataGrid.AllowUserToOrderColumns = true;
            this.MainDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MainDataGrid.Location = new System.Drawing.Point(12, 60);
            this.MainDataGrid.Name = "MainDataGrid";
            this.MainDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.MainDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDataGrid.Size = new System.Drawing.Size(927, 240);
            this.MainDataGrid.TabIndex = 0;
            this.MainDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGrid_RowEnter);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Voicemails",
            "Faxes",
            "Recordings",
            "Notifications",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(380, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "default (All)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Message filter | View";
            // 
            // Searchbtn
            // 
            this.Searchbtn.Location = new System.Drawing.Point(737, 31);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(75, 23);
            this.Searchbtn.TabIndex = 4;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Searchtxtbx
            // 
            this.Searchtxtbx.Location = new System.Drawing.Point(510, 32);
            this.Searchtxtbx.Name = "Searchtxtbx";
            this.Searchtxtbx.Size = new System.Drawing.Size(221, 20);
            this.Searchtxtbx.TabIndex = 3;
            this.Searchtxtbx.Text = "Not implemented.";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(818, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(39, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "All";
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(869, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 60);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // PlainTextBodyckbx
            // 
            this.PlainTextBodyckbx.AutoSize = true;
            this.PlainTextBodyckbx.Checked = true;
            this.PlainTextBodyckbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlainTextBodyckbx.Location = new System.Drawing.Point(16, 32);
            this.PlainTextBodyckbx.Name = "PlainTextBodyckbx";
            this.PlainTextBodyckbx.Size = new System.Drawing.Size(95, 17);
            this.PlainTextBodyckbx.TabIndex = 15;
            this.PlainTextBodyckbx.Text = "Plain text body";
            this.PlainTextBodyckbx.UseVisualStyleBackColor = true;
            this.PlainTextBodyckbx.CheckedChanged += new System.EventHandler(this.PlainTextBodyckbx_CheckedChanged);
            // 
            // HTMLBodyckbx
            // 
            this.HTMLBodyckbx.AutoSize = true;
            this.HTMLBodyckbx.Location = new System.Drawing.Point(16, 55);
            this.HTMLBodyckbx.Name = "HTMLBodyckbx";
            this.HTMLBodyckbx.Size = new System.Drawing.Size(82, 17);
            this.HTMLBodyckbx.TabIndex = 16;
            this.HTMLBodyckbx.Text = "HTML body";
            this.HTMLBodyckbx.UseVisualStyleBackColor = true;
            this.HTMLBodyckbx.CheckedChanged += new System.EventHandler(this.HTMLBodyckbx_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.HideBottomPanelchkbx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PopOutBodychkbx);
            this.panel1.Controls.Add(this.HTMLBodyckbx);
            this.panel1.Controls.Add(this.PlainTextBodyckbx);
            this.panel1.Location = new System.Drawing.Point(825, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 137);
            this.panel1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Message body options";
            // 
            // PopOutBodychkbx
            // 
            this.PopOutBodychkbx.AutoSize = true;
            this.PopOutBodychkbx.Location = new System.Drawing.Point(16, 83);
            this.PopOutBodychkbx.Name = "PopOutBodychkbx";
            this.PopOutBodychkbx.Size = new System.Drawing.Size(89, 17);
            this.PopOutBodychkbx.TabIndex = 17;
            this.PopOutBodychkbx.Text = "Pop out body";
            this.PopOutBodychkbx.UseVisualStyleBackColor = true;
            this.PopOutBodychkbx.CheckedChanged += new System.EventHandler(this.PopOutBody_CheckedChanged);
            // 
            // RetryMessagestxtbx
            // 
            this.RetryMessagestxtbx.Location = new System.Drawing.Point(172, 29);
            this.RetryMessagestxtbx.Name = "RetryMessagestxtbx";
            this.RetryMessagestxtbx.Size = new System.Drawing.Size(93, 22);
            this.RetryMessagestxtbx.TabIndex = 1;
            this.RetryMessagestxtbx.Text = "Retry messages";
            this.toolTip1.SetToolTip(this.RetryMessagestxtbx, "1) Retry selected items in the grid\r\n2) Retry all items\r\n3) Retry a subset of ite" +
                    "ms\r\n\r\nBasic and Advanced options are available\r\nfor retrying messages.");
            this.RetryMessagestxtbx.UseVisualStyleBackColor = true;
            this.RetryMessagestxtbx.Click += new System.EventHandler(this.RetryMessagestxtbx_Click);
            // 
            // testoutboxtxtbx
            // 
            this.testoutboxtxtbx.Location = new System.Drawing.Point(582, 1);
            this.testoutboxtxtbx.Name = "testoutboxtxtbx";
            this.testoutboxtxtbx.Size = new System.Drawing.Size(221, 20);
            this.testoutboxtxtbx.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.MessageBodytxtbx);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 138);
            this.panel2.TabIndex = 43;
            // 
            // HideBottomPanelchkbx
            // 
            this.HideBottomPanelchkbx.AutoSize = true;
            this.HideBottomPanelchkbx.Location = new System.Drawing.Point(30, 103);
            this.HideBottomPanelchkbx.Name = "HideBottomPanelchkbx";
            this.HideBottomPanelchkbx.Size = new System.Drawing.Size(84, 30);
            this.HideBottomPanelchkbx.TabIndex = 102;
            this.HideBottomPanelchkbx.Text = "Hide Bottom\r\npanel\r\n";
            this.HideBottomPanelchkbx.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.testoutboxtxtbx);
            this.Controls.Add(this.RetryMessagestxtbx);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Searchtxtbx);
            this.Controls.Add(this.Searchbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.MainDataGrid);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.MainBindingNavigator);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Recovery Tool - 0.0.0.0 - development";
            ((System.ComponentModel.ISupportInitialize)(this.MainBindingNavigator)).EndInit();
            this.MainBindingNavigator.ResumeLayout(false);
            this.MainBindingNavigator.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitWithoutSavingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TextBox MessageBodytxtbx;
        private System.Windows.Forms.DataGridView MainDataGrid;  // *** jam changed to public
        private System.Windows.Forms.ToolStripMenuItem saveCurrentMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voicemailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faxesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callRecordingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Searchbtn;
        private System.Windows.Forms.TextBox Searchtxtbx;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox PlainTextBodyckbx;
        private System.Windows.Forms.CheckBox HTMLBodyckbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem discardAllChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitSavingAllChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.CheckBox PopOutBodychkbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator MainBindingNavigator;
        private System.Windows.Forms.Button RetryMessagestxtbx;
        private System.Windows.Forms.TextBox testoutboxtxtbx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox HideBottomPanelchkbx;
    }
}


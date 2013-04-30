namespace CinderellaLauncher
{
    partial class FGCheckIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGCheckIn));
            this.fgDGV = new System.Windows.Forms.DataGridView();
            this.selectLabel = new System.Windows.Forms.Label();
            this.checkInButton = new System.Windows.Forms.Button();
            this.friPMCheckInOutButton = new System.Windows.Forms.RadioButton();
            this.friPMVolunteerButton = new System.Windows.Forms.RadioButton();
            this.friPMPSButton = new System.Windows.Forms.RadioButton();
            this.friPMAlterationsButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chatNowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCheckInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCheckInToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFairyGodmotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fairyGodmotherCheckInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCheckInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fridayPMTab = new System.Windows.Forms.TabPage();
            this.clearButton1 = new System.Windows.Forms.Button();
            this.fridayShiftLabel = new System.Windows.Forms.Label();
            this.SatAMTab = new System.Windows.Forms.TabPage();
            this.clearButton2 = new System.Windows.Forms.Button();
            this.saturdayAMShiftLabel = new System.Windows.Forms.Label();
            this.satAMCheckInOutButton = new System.Windows.Forms.RadioButton();
            this.satAMPSButton = new System.Windows.Forms.RadioButton();
            this.satAMVolunteerButton = new System.Windows.Forms.RadioButton();
            this.satAMAlterationsButton = new System.Windows.Forms.RadioButton();
            this.satPMTab = new System.Windows.Forms.TabPage();
            this.clearButton3 = new System.Windows.Forms.Button();
            this.saturdayPMShiftLabel = new System.Windows.Forms.Label();
            this.satPMCheckInOutButton = new System.Windows.Forms.RadioButton();
            this.satPMPSButton = new System.Windows.Forms.RadioButton();
            this.satPMVolunteerButton = new System.Windows.Forms.RadioButton();
            this.satPMAlterationsButton = new System.Windows.Forms.RadioButton();
            this.searchLabel = new System.Windows.Forms.Label();
            this.lNameLabel = new System.Windows.Forms.Label();
            this.fNameLabel = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.refreshButtonFGCheckIn = new System.Windows.Forms.Button();
            this.shiftComboBox = new System.Windows.Forms.ComboBox();
            this.viewShiftLabel = new System.Windows.Forms.Label();
            this.BarcodeLabel = new System.Windows.Forms.Label();
            this.BarcodeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fgDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.fridayPMTab.SuspendLayout();
            this.SatAMTab.SuspendLayout();
            this.satPMTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // fgDGV
            // 
            this.fgDGV.AllowUserToAddRows = false;
            this.fgDGV.AllowUserToDeleteRows = false;
            this.fgDGV.AllowUserToResizeRows = false;
            this.fgDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.fgDGV.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fgDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fgDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fgDGV.Location = new System.Drawing.Point(16, 174);
            this.fgDGV.MultiSelect = false;
            this.fgDGV.Name = "fgDGV";
            this.fgDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fgDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fgDGV.RowHeadersVisible = false;
            this.fgDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.fgDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.fgDGV.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.fgDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            this.fgDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.fgDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fgDGV.Size = new System.Drawing.Size(865, 341);
            this.fgDGV.TabIndex = 0;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLabel.Location = new System.Drawing.Point(16, 146);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(199, 20);
            this.selectLabel.TabIndex = 1;
            this.selectLabel.Text = "Select Fairy Godmother";
            // 
            // checkInButton
            // 
            this.checkInButton.BackColor = System.Drawing.Color.Snow;
            this.checkInButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.checkInButton.FlatAppearance.BorderSize = 2;
            this.checkInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.checkInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.checkInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInButton.Location = new System.Drawing.Point(786, 637);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(95, 40);
            this.checkInButton.TabIndex = 6;
            this.checkInButton.Text = "Check-In";
            this.checkInButton.UseVisualStyleBackColor = false;
            this.checkInButton.Click += new System.EventHandler(this.checkInButton_Click);
            // 
            // friPMCheckInOutButton
            // 
            this.friPMCheckInOutButton.AutoSize = true;
            this.friPMCheckInOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friPMCheckInOutButton.Location = new System.Drawing.Point(6, 6);
            this.friPMCheckInOutButton.Name = "friPMCheckInOutButton";
            this.friPMCheckInOutButton.Size = new System.Drawing.Size(221, 24);
            this.friPMCheckInOutButton.TabIndex = 7;
            this.friPMCheckInOutButton.Text = "Check-in/Check-out Station";
            this.friPMCheckInOutButton.UseVisualStyleBackColor = true;
            this.friPMCheckInOutButton.Click += new System.EventHandler(this.friPMCheckInOutButton_Click);
            // 
            // friPMVolunteerButton
            // 
            this.friPMVolunteerButton.AutoSize = true;
            this.friPMVolunteerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friPMVolunteerButton.Location = new System.Drawing.Point(258, 6);
            this.friPMVolunteerButton.Name = "friPMVolunteerButton";
            this.friPMVolunteerButton.Size = new System.Drawing.Size(96, 24);
            this.friPMVolunteerButton.TabIndex = 8;
            this.friPMVolunteerButton.Text = "Volunteer";
            this.friPMVolunteerButton.UseVisualStyleBackColor = true;
            this.friPMVolunteerButton.Click += new System.EventHandler(this.friPMVolunteerButton_Click);
            // 
            // friPMPSButton
            // 
            this.friPMPSButton.AutoSize = true;
            this.friPMPSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friPMPSButton.Location = new System.Drawing.Point(6, 38);
            this.friPMPSButton.Name = "friPMPSButton";
            this.friPMPSButton.Size = new System.Drawing.Size(154, 24);
            this.friPMPSButton.TabIndex = 10;
            this.friPMPSButton.Text = "Personal Shopper";
            this.friPMPSButton.UseVisualStyleBackColor = true;
            this.friPMPSButton.Click += new System.EventHandler(this.friPMPSButton_Click);
            // 
            // friPMAlterationsButton
            // 
            this.friPMAlterationsButton.AutoSize = true;
            this.friPMAlterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friPMAlterationsButton.Location = new System.Drawing.Point(258, 38);
            this.friPMAlterationsButton.Name = "friPMAlterationsButton";
            this.friPMAlterationsButton.Size = new System.Drawing.Size(103, 24);
            this.friPMAlterationsButton.TabIndex = 11;
            this.friPMAlterationsButton.Text = "Alterations";
            this.friPMAlterationsButton.UseVisualStyleBackColor = true;
            this.friPMAlterationsButton.Click += new System.EventHandler(this.friPMAlterationsButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Snow;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.chatToolStripMenuItem1,
            this.undoCheckInToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 27);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(43, 23);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // chatToolStripMenuItem1
            // 
            this.chatToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatNowToolStripMenuItem1});
            this.chatToolStripMenuItem1.Name = "chatToolStripMenuItem1";
            this.chatToolStripMenuItem1.Size = new System.Drawing.Size(51, 23);
            this.chatToolStripMenuItem1.Text = "Chat";
            // 
            // chatNowToolStripMenuItem1
            // 
            this.chatNowToolStripMenuItem1.Name = "chatNowToolStripMenuItem1";
            this.chatNowToolStripMenuItem1.Size = new System.Drawing.Size(142, 24);
            this.chatNowToolStripMenuItem1.Text = "Chat Now";
            this.chatNowToolStripMenuItem1.Click += new System.EventHandler(this.chatNowToolStripMenuItem_Click);
            // 
            // undoCheckInToolStripMenuItem1
            // 
            this.undoCheckInToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoCheckInToolStripMenuItem2,
            this.addFairyGodmotherToolStripMenuItem,
            this.fairyGodmotherCheckInToolStripMenuItem});
            this.undoCheckInToolStripMenuItem1.Name = "undoCheckInToolStripMenuItem1";
            this.undoCheckInToolStripMenuItem1.Size = new System.Drawing.Size(137, 23);
            this.undoCheckInToolStripMenuItem1.Text = "Fairy Godmothers";
            // 
            // undoCheckInToolStripMenuItem2
            // 
            this.undoCheckInToolStripMenuItem2.Name = "undoCheckInToolStripMenuItem2";
            this.undoCheckInToolStripMenuItem2.Size = new System.Drawing.Size(246, 24);
            this.undoCheckInToolStripMenuItem2.Text = "Undo Check-In";
            this.undoCheckInToolStripMenuItem2.Click += new System.EventHandler(this.undoCheckInToolStripMenuItem2_Click);
            // 
            // addFairyGodmotherToolStripMenuItem
            // 
            this.addFairyGodmotherToolStripMenuItem.Name = "addFairyGodmotherToolStripMenuItem";
            this.addFairyGodmotherToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.addFairyGodmotherToolStripMenuItem.Text = "Add Fairy Godmother";
            this.addFairyGodmotherToolStripMenuItem.Click += new System.EventHandler(this.addFairyGodmotherToolStripMenuItem_Click);
            // 
            // fairyGodmotherCheckInToolStripMenuItem
            // 
            this.fairyGodmotherCheckInToolStripMenuItem.Name = "fairyGodmotherCheckInToolStripMenuItem";
            this.fairyGodmotherCheckInToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.fairyGodmotherCheckInToolStripMenuItem.Text = "Fairy Godmother Check In";
            this.fairyGodmotherCheckInToolStripMenuItem.Click += new System.EventHandler(this.fairyGodmotherCheckInToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(51, 23);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // userManualToolStripMenuItem1
            // 
            this.userManualToolStripMenuItem1.Name = "userManualToolStripMenuItem1";
            this.userManualToolStripMenuItem1.Size = new System.Drawing.Size(159, 24);
            this.userManualToolStripMenuItem1.Text = "User Manual";
            this.userManualToolStripMenuItem1.Click += new System.EventHandler(this.userManualToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(159, 24);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoCheckInToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // undoCheckInToolStripMenuItem
            // 
            this.undoCheckInToolStripMenuItem.Name = "undoCheckInToolStripMenuItem";
            this.undoCheckInToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.undoCheckInToolStripMenuItem.Text = "Undo Check-In";
            this.undoCheckInToolStripMenuItem.Click += new System.EventHandler(this.undoCheckInToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatNowToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // chatNowToolStripMenuItem
            // 
            this.chatNowToolStripMenuItem.Name = "chatNowToolStripMenuItem";
            this.chatNowToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.chatNowToolStripMenuItem.Text = "Chat Now";
            this.chatNowToolStripMenuItem.Click += new System.EventHandler(this.chatNowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userManualToolStripMenuItem.Text = "User Manual";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.fridayPMTab);
            this.tabControl1.Controls.Add(this.SatAMTab);
            this.tabControl1.Controls.Add(this.satPMTab);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(16, 542);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 140);
            this.tabControl1.TabIndex = 39;
            // 
            // fridayPMTab
            // 
            this.fridayPMTab.BackColor = System.Drawing.Color.Snow;
            this.fridayPMTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fridayPMTab.Controls.Add(this.clearButton1);
            this.fridayPMTab.Controls.Add(this.fridayShiftLabel);
            this.fridayPMTab.Controls.Add(this.friPMCheckInOutButton);
            this.fridayPMTab.Controls.Add(this.friPMAlterationsButton);
            this.fridayPMTab.Controls.Add(this.friPMPSButton);
            this.fridayPMTab.Controls.Add(this.friPMVolunteerButton);
            this.fridayPMTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridayPMTab.ForeColor = System.Drawing.Color.Black;
            this.fridayPMTab.Location = new System.Drawing.Point(4, 29);
            this.fridayPMTab.Name = "fridayPMTab";
            this.fridayPMTab.Padding = new System.Windows.Forms.Padding(3);
            this.fridayPMTab.Size = new System.Drawing.Size(377, 107);
            this.fridayPMTab.TabIndex = 0;
            this.fridayPMTab.Text = "Friday PM";
            // 
            // clearButton1
            // 
            this.clearButton1.BackColor = System.Drawing.Color.Snow;
            this.clearButton1.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.clearButton1.FlatAppearance.BorderSize = 2;
            this.clearButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.clearButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.clearButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton1.Location = new System.Drawing.Point(308, 64);
            this.clearButton1.Name = "clearButton1";
            this.clearButton1.Size = new System.Drawing.Size(59, 33);
            this.clearButton1.TabIndex = 13;
            this.clearButton1.Text = "Clear";
            this.clearButton1.UseVisualStyleBackColor = false;
            this.clearButton1.Click += new System.EventHandler(this.clearButton1_Click);
            // 
            // fridayShiftLabel
            // 
            this.fridayShiftLabel.AutoSize = true;
            this.fridayShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridayShiftLabel.Location = new System.Drawing.Point(117, 74);
            this.fridayShiftLabel.Name = "fridayShiftLabel";
            this.fridayShiftLabel.Size = new System.Drawing.Size(153, 20);
            this.fridayShiftLabel.TabIndex = 12;
            this.fridayShiftLabel.Text = "Friday PM Shift Role";
            // 
            // SatAMTab
            // 
            this.SatAMTab.BackColor = System.Drawing.Color.Snow;
            this.SatAMTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SatAMTab.Controls.Add(this.clearButton2);
            this.SatAMTab.Controls.Add(this.saturdayAMShiftLabel);
            this.SatAMTab.Controls.Add(this.satAMCheckInOutButton);
            this.SatAMTab.Controls.Add(this.satAMPSButton);
            this.SatAMTab.Controls.Add(this.satAMVolunteerButton);
            this.SatAMTab.Controls.Add(this.satAMAlterationsButton);
            this.SatAMTab.Location = new System.Drawing.Point(4, 29);
            this.SatAMTab.Name = "SatAMTab";
            this.SatAMTab.Padding = new System.Windows.Forms.Padding(3);
            this.SatAMTab.Size = new System.Drawing.Size(377, 107);
            this.SatAMTab.TabIndex = 1;
            this.SatAMTab.Text = "Saturday AM";
            // 
            // clearButton2
            // 
            this.clearButton2.BackColor = System.Drawing.Color.Snow;
            this.clearButton2.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.clearButton2.FlatAppearance.BorderSize = 2;
            this.clearButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.clearButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.clearButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton2.Location = new System.Drawing.Point(308, 64);
            this.clearButton2.Name = "clearButton2";
            this.clearButton2.Size = new System.Drawing.Size(59, 33);
            this.clearButton2.TabIndex = 50;
            this.clearButton2.Text = "Clear";
            this.clearButton2.UseVisualStyleBackColor = false;
            this.clearButton2.Click += new System.EventHandler(this.clearButton2_Click);
            // 
            // saturdayAMShiftLabel
            // 
            this.saturdayAMShiftLabel.AutoSize = true;
            this.saturdayAMShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturdayAMShiftLabel.Location = new System.Drawing.Point(94, 74);
            this.saturdayAMShiftLabel.Name = "saturdayAMShiftLabel";
            this.saturdayAMShiftLabel.Size = new System.Drawing.Size(175, 20);
            this.saturdayAMShiftLabel.TabIndex = 16;
            this.saturdayAMShiftLabel.Text = "Saturday AM Shift Role";
            // 
            // satAMCheckInOutButton
            // 
            this.satAMCheckInOutButton.AutoSize = true;
            this.satAMCheckInOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satAMCheckInOutButton.Location = new System.Drawing.Point(6, 6);
            this.satAMCheckInOutButton.Name = "satAMCheckInOutButton";
            this.satAMCheckInOutButton.Size = new System.Drawing.Size(221, 24);
            this.satAMCheckInOutButton.TabIndex = 12;
            this.satAMCheckInOutButton.TabStop = true;
            this.satAMCheckInOutButton.Text = "Check-in/Check-out Station";
            this.satAMCheckInOutButton.UseVisualStyleBackColor = true;
            this.satAMCheckInOutButton.Click += new System.EventHandler(this.satAMCheckInOutButton_Click);
            // 
            // satAMPSButton
            // 
            this.satAMPSButton.AutoSize = true;
            this.satAMPSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satAMPSButton.Location = new System.Drawing.Point(6, 38);
            this.satAMPSButton.Name = "satAMPSButton";
            this.satAMPSButton.Size = new System.Drawing.Size(154, 24);
            this.satAMPSButton.TabIndex = 14;
            this.satAMPSButton.TabStop = true;
            this.satAMPSButton.Text = "Personal Shopper";
            this.satAMPSButton.UseVisualStyleBackColor = true;
            this.satAMPSButton.Click += new System.EventHandler(this.satAMPSButton_Click);
            // 
            // satAMVolunteerButton
            // 
            this.satAMVolunteerButton.AutoSize = true;
            this.satAMVolunteerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satAMVolunteerButton.Location = new System.Drawing.Point(258, 6);
            this.satAMVolunteerButton.Name = "satAMVolunteerButton";
            this.satAMVolunteerButton.Size = new System.Drawing.Size(96, 24);
            this.satAMVolunteerButton.TabIndex = 13;
            this.satAMVolunteerButton.TabStop = true;
            this.satAMVolunteerButton.Text = "Volunteer";
            this.satAMVolunteerButton.UseVisualStyleBackColor = true;
            this.satAMVolunteerButton.Click += new System.EventHandler(this.satAMVolunteerButton_Click);
            // 
            // satAMAlterationsButton
            // 
            this.satAMAlterationsButton.AutoSize = true;
            this.satAMAlterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satAMAlterationsButton.Location = new System.Drawing.Point(258, 38);
            this.satAMAlterationsButton.Name = "satAMAlterationsButton";
            this.satAMAlterationsButton.Size = new System.Drawing.Size(103, 24);
            this.satAMAlterationsButton.TabIndex = 15;
            this.satAMAlterationsButton.TabStop = true;
            this.satAMAlterationsButton.Text = "Alterations";
            this.satAMAlterationsButton.UseVisualStyleBackColor = true;
            this.satAMAlterationsButton.Click += new System.EventHandler(this.satAMAlterationsButton_Click);
            // 
            // satPMTab
            // 
            this.satPMTab.BackColor = System.Drawing.Color.Snow;
            this.satPMTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.satPMTab.Controls.Add(this.clearButton3);
            this.satPMTab.Controls.Add(this.saturdayPMShiftLabel);
            this.satPMTab.Controls.Add(this.satPMCheckInOutButton);
            this.satPMTab.Controls.Add(this.satPMPSButton);
            this.satPMTab.Controls.Add(this.satPMVolunteerButton);
            this.satPMTab.Controls.Add(this.satPMAlterationsButton);
            this.satPMTab.Location = new System.Drawing.Point(4, 29);
            this.satPMTab.Name = "satPMTab";
            this.satPMTab.Padding = new System.Windows.Forms.Padding(3);
            this.satPMTab.Size = new System.Drawing.Size(377, 107);
            this.satPMTab.TabIndex = 2;
            this.satPMTab.Text = "Saturday PM";
            // 
            // clearButton3
            // 
            this.clearButton3.BackColor = System.Drawing.Color.Snow;
            this.clearButton3.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.clearButton3.FlatAppearance.BorderSize = 2;
            this.clearButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.clearButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.clearButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton3.Location = new System.Drawing.Point(308, 64);
            this.clearButton3.Name = "clearButton3";
            this.clearButton3.Size = new System.Drawing.Size(59, 33);
            this.clearButton3.TabIndex = 49;
            this.clearButton3.Text = "Clear";
            this.clearButton3.UseVisualStyleBackColor = false;
            this.clearButton3.Click += new System.EventHandler(this.clearButton3_Click);
            // 
            // saturdayPMShiftLabel
            // 
            this.saturdayPMShiftLabel.AutoSize = true;
            this.saturdayPMShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturdayPMShiftLabel.Location = new System.Drawing.Point(94, 74);
            this.saturdayPMShiftLabel.Name = "saturdayPMShiftLabel";
            this.saturdayPMShiftLabel.Size = new System.Drawing.Size(174, 20);
            this.saturdayPMShiftLabel.TabIndex = 16;
            this.saturdayPMShiftLabel.Text = "Saturday PM Shift Role";
            // 
            // satPMCheckInOutButton
            // 
            this.satPMCheckInOutButton.AutoSize = true;
            this.satPMCheckInOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satPMCheckInOutButton.Location = new System.Drawing.Point(6, 6);
            this.satPMCheckInOutButton.Name = "satPMCheckInOutButton";
            this.satPMCheckInOutButton.Size = new System.Drawing.Size(221, 24);
            this.satPMCheckInOutButton.TabIndex = 12;
            this.satPMCheckInOutButton.TabStop = true;
            this.satPMCheckInOutButton.Text = "Check-in/Check-out Station";
            this.satPMCheckInOutButton.UseVisualStyleBackColor = true;
            this.satPMCheckInOutButton.Click += new System.EventHandler(this.satPMCheckInOutButton_Click);
            // 
            // satPMPSButton
            // 
            this.satPMPSButton.AutoSize = true;
            this.satPMPSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satPMPSButton.Location = new System.Drawing.Point(6, 38);
            this.satPMPSButton.Name = "satPMPSButton";
            this.satPMPSButton.Size = new System.Drawing.Size(154, 24);
            this.satPMPSButton.TabIndex = 14;
            this.satPMPSButton.TabStop = true;
            this.satPMPSButton.Text = "Personal Shopper";
            this.satPMPSButton.UseVisualStyleBackColor = true;
            this.satPMPSButton.Click += new System.EventHandler(this.satPMPSButton_Click);
            // 
            // satPMVolunteerButton
            // 
            this.satPMVolunteerButton.AutoSize = true;
            this.satPMVolunteerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satPMVolunteerButton.Location = new System.Drawing.Point(258, 6);
            this.satPMVolunteerButton.Name = "satPMVolunteerButton";
            this.satPMVolunteerButton.Size = new System.Drawing.Size(96, 24);
            this.satPMVolunteerButton.TabIndex = 13;
            this.satPMVolunteerButton.TabStop = true;
            this.satPMVolunteerButton.Text = "Volunteer";
            this.satPMVolunteerButton.UseVisualStyleBackColor = true;
            this.satPMVolunteerButton.Click += new System.EventHandler(this.satPMVolunteerButton_Click);
            // 
            // satPMAlterationsButton
            // 
            this.satPMAlterationsButton.AutoSize = true;
            this.satPMAlterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satPMAlterationsButton.Location = new System.Drawing.Point(258, 38);
            this.satPMAlterationsButton.Name = "satPMAlterationsButton";
            this.satPMAlterationsButton.Size = new System.Drawing.Size(103, 24);
            this.satPMAlterationsButton.TabIndex = 15;
            this.satPMAlterationsButton.TabStop = true;
            this.satPMAlterationsButton.Text = "Alterations";
            this.satPMAlterationsButton.UseVisualStyleBackColor = true;
            this.satPMAlterationsButton.Click += new System.EventHandler(this.satPMAlterationsButton_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(12, 40);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(66, 20);
            this.searchLabel.TabIndex = 40;
            this.searchLabel.Text = "Search";
            // 
            // lNameLabel
            // 
            this.lNameLabel.AutoSize = true;
            this.lNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameLabel.Location = new System.Drawing.Point(41, 69);
            this.lNameLabel.Name = "lNameLabel";
            this.lNameLabel.Size = new System.Drawing.Size(90, 20);
            this.lNameLabel.TabIndex = 41;
            this.lNameLabel.Text = "Last Name:";
            // 
            // fNameLabel
            // 
            this.fNameLabel.AutoSize = true;
            this.fNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fNameLabel.Location = new System.Drawing.Point(41, 105);
            this.fNameLabel.Name = "fNameLabel";
            this.fNameLabel.Size = new System.Drawing.Size(90, 20);
            this.fNameLabel.TabIndex = 42;
            this.fNameLabel.Text = "First Name:";
            // 
            // lastNameBox
            // 
            this.lastNameBox.BackColor = System.Drawing.Color.Snow;
            this.lastNameBox.Location = new System.Drawing.Point(137, 69);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(306, 20);
            this.lastNameBox.TabIndex = 3;
            // 
            // firstNameBox
            // 
            this.firstNameBox.BackColor = System.Drawing.Color.Snow;
            this.firstNameBox.Location = new System.Drawing.Point(137, 105);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(306, 20);
            this.firstNameBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Snow;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(485, 69);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(82, 35);
            this.searchButton.TabIndex = 45;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // refreshButtonFGCheckIn
            // 
            this.refreshButtonFGCheckIn.BackColor = System.Drawing.Color.Snow;
            this.refreshButtonFGCheckIn.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.refreshButtonFGCheckIn.FlatAppearance.BorderSize = 2;
            this.refreshButtonFGCheckIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.refreshButtonFGCheckIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.refreshButtonFGCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButtonFGCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButtonFGCheckIn.Location = new System.Drawing.Point(791, 40);
            this.refreshButtonFGCheckIn.Name = "refreshButtonFGCheckIn";
            this.refreshButtonFGCheckIn.Size = new System.Drawing.Size(90, 32);
            this.refreshButtonFGCheckIn.TabIndex = 46;
            this.refreshButtonFGCheckIn.Text = "&Refresh";
            this.refreshButtonFGCheckIn.UseVisualStyleBackColor = false;
            this.refreshButtonFGCheckIn.Click += new System.EventHandler(this.refreshButtonFGCheckIn_Click);
            // 
            // shiftComboBox
            // 
            this.shiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftComboBox.FormattingEnabled = true;
            this.shiftComboBox.Items.AddRange(new object[] {
            "All Shifts",
            "Friday PM",
            "Saturday AM",
            "Saturday PM"});
            this.shiftComboBox.Location = new System.Drawing.Point(702, 147);
            this.shiftComboBox.Name = "shiftComboBox";
            this.shiftComboBox.Size = new System.Drawing.Size(179, 21);
            this.shiftComboBox.TabIndex = 47;
            this.shiftComboBox.SelectedIndexChanged += new System.EventHandler(this.shiftComboBox_SelectedIndexChanged);
            // 
            // viewShiftLabel
            // 
            this.viewShiftLabel.AutoSize = true;
            this.viewShiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewShiftLabel.Location = new System.Drawing.Point(605, 146);
            this.viewShiftLabel.Name = "viewShiftLabel";
            this.viewShiftLabel.Size = new System.Drawing.Size(88, 20);
            this.viewShiftLabel.TabIndex = 48;
            this.viewShiftLabel.Text = "View Shift: ";
            // 
            // BarcodeLabel
            // 
            this.BarcodeLabel.AutoSize = true;
            this.BarcodeLabel.Location = new System.Drawing.Point(420, 665);
            this.BarcodeLabel.Name = "BarcodeLabel";
            this.BarcodeLabel.Size = new System.Drawing.Size(32, 13);
            this.BarcodeLabel.TabIndex = 50;
            this.BarcodeLabel.Text = "Scan";
            // 
            // BarcodeTextBox
            // 
            this.BarcodeTextBox.Location = new System.Drawing.Point(474, 662);
            this.BarcodeTextBox.Name = "BarcodeTextBox";
            this.BarcodeTextBox.Size = new System.Drawing.Size(306, 20);
            this.BarcodeTextBox.TabIndex = 49;
            this.BarcodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeTextBox_KeyPress);
            // 
            // FGCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(902, 694);
            this.Controls.Add(this.BarcodeLabel);
            this.Controls.Add(this.BarcodeTextBox);
            this.Controls.Add(this.viewShiftLabel);
            this.Controls.Add(this.shiftComboBox);
            this.Controls.Add(this.refreshButtonFGCheckIn);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.fNameLabel);
            this.Controls.Add(this.lNameLabel);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkInButton);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.fgDGV);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FGCheckIn";
            this.Text = "Fairy Godmother Check-In";
            this.Load += new System.EventHandler(this.FGCheckin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.fridayPMTab.ResumeLayout(false);
            this.fridayPMTab.PerformLayout();
            this.SatAMTab.ResumeLayout(false);
            this.SatAMTab.PerformLayout();
            this.satPMTab.ResumeLayout(false);
            this.satPMTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        

        private System.Windows.Forms.DataGridView fgDGV;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.RadioButton friPMCheckInOutButton;
        private System.Windows.Forms.RadioButton friPMVolunteerButton;
        private System.Windows.Forms.RadioButton friPMPSButton;
        private System.Windows.Forms.RadioButton friPMAlterationsButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoCheckInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fridayPMTab;
        private System.Windows.Forms.TabPage SatAMTab;
        private System.Windows.Forms.RadioButton satAMCheckInOutButton;
        private System.Windows.Forms.RadioButton satAMPSButton;
        private System.Windows.Forms.RadioButton satAMVolunteerButton;
        private System.Windows.Forms.RadioButton satAMAlterationsButton;
        private System.Windows.Forms.TabPage satPMTab;
        private System.Windows.Forms.RadioButton satPMCheckInOutButton;
        private System.Windows.Forms.RadioButton satPMPSButton;
        private System.Windows.Forms.RadioButton satPMVolunteerButton;
        private System.Windows.Forms.RadioButton satPMAlterationsButton;
        private System.Windows.Forms.Label fridayShiftLabel;
        private System.Windows.Forms.Label saturdayAMShiftLabel;
        private System.Windows.Forms.Label saturdayPMShiftLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label lNameLabel;
        private System.Windows.Forms.Label fNameLabel;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button refreshButtonFGCheckIn;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chatNowToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoCheckInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoCheckInToolStripMenuItem2;
        private System.Windows.Forms.ComboBox shiftComboBox;
        private System.Windows.Forms.Label viewShiftLabel;
        private System.Windows.Forms.Button clearButton1;
        private System.Windows.Forms.Button clearButton2;
        private System.Windows.Forms.Button clearButton3;
        private System.Windows.Forms.ToolStripMenuItem addFairyGodmotherToolStripMenuItem;
        private System.Windows.Forms.Label BarcodeLabel;
        private System.Windows.Forms.TextBox BarcodeTextBox;
        private System.Windows.Forms.ToolStripMenuItem fairyGodmotherCheckInToolStripMenuItem;
    }
}
namespace CinderellaMGS
{
    partial class Checkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkout));
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.fgLastNameTB = new System.Windows.Forms.TextBox();
            this.shoeSizeCB = new System.Windows.Forms.ComboBox();
            this.dressSizeCB = new System.Windows.Forms.ComboBox();
            this.alteredCB = new System.Windows.Forms.ComboBox();
            this.notesTB = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sortCB = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.changeStatusCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shoppingCheck = new System.Windows.Forms.CheckBox();
            this.doneShoppingCheck = new System.Windows.Forms.CheckBox();
            this.checkedOutCheck = new System.Windows.Forms.CheckBox();
            this.statusTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dressAvailableTB = new System.Windows.Forms.MaskedTextBox();
            this.ampmCB = new System.Windows.Forms.ComboBox();
            this.dayAvailableCB = new System.Windows.Forms.ComboBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.counterLabel = new System.Windows.Forms.Label();
            this.fgFirstNameTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.fgNameListBox = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(350, 58);
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(92, 20);
            this.lastNameTB.TabIndex = 2;
            // 
            // fgLastNameTB
            // 
            this.fgLastNameTB.Location = new System.Drawing.Point(350, 128);
            this.fgLastNameTB.Name = "fgLastNameTB";
            this.fgLastNameTB.Size = new System.Drawing.Size(92, 20);
            this.fgLastNameTB.TabIndex = 5;
            // 
            // shoeSizeCB
            // 
            this.shoeSizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shoeSizeCB.FormattingEnabled = true;
            this.shoeSizeCB.Items.AddRange(new object[] {
            "NULL",
            "5",
            "5.5",
            "6",
            "6.5",
            "7",
            "7.5",
            "8",
            "8.5",
            "9",
            "9.5",
            "10",
            "10.5",
            "11",
            "12",
            "13"});
            this.shoeSizeCB.Location = new System.Drawing.Point(10, 31);
            this.shoeSizeCB.Name = "shoeSizeCB";
            this.shoeSizeCB.Size = new System.Drawing.Size(71, 21);
            this.shoeSizeCB.TabIndex = 1;
            // 
            // dressSizeCB
            // 
            this.dressSizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dressSizeCB.FormattingEnabled = true;
            this.dressSizeCB.Items.AddRange(new object[] {
            "NULL",
            "0",
            "2",
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32",
            "34",
            "36",
            "38"});
            this.dressSizeCB.Location = new System.Drawing.Point(99, 31);
            this.dressSizeCB.Name = "dressSizeCB";
            this.dressSizeCB.Size = new System.Drawing.Size(71, 21);
            this.dressSizeCB.TabIndex = 2;
            // 
            // alteredCB
            // 
            this.alteredCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alteredCB.FormattingEnabled = true;
            this.alteredCB.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.alteredCB.Location = new System.Drawing.Point(58, 71);
            this.alteredCB.Name = "alteredCB";
            this.alteredCB.Size = new System.Drawing.Size(71, 21);
            this.alteredCB.TabIndex = 3;
            // 
            // notesTB
            // 
            this.notesTB.Location = new System.Drawing.Point(350, 276);
            this.notesTB.Multiline = true;
            this.notesTB.Name = "notesTB";
            this.notesTB.Size = new System.Drawing.Size(185, 82);
            this.notesTB.TabIndex = 7;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.updateButton.Location = new System.Drawing.Point(350, 449);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(185, 33);
            this.updateButton.TabIndex = 11;
            this.updateButton.Text = "&Update Record";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "FG Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Shoe Size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.alteredCB);
            this.groupBox1.Controls.Add(this.dressSizeCB);
            this.groupBox1.Controls.Add(this.shoeSizeCB);
            this.groupBox1.Location = new System.Drawing.Point(350, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outfit Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Altered";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Dress Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Notes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Time Available (HH:MM FORMAT)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Cinderella";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Order By";
            // 
            // sortCB
            // 
            this.sortCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortCB.FormattingEnabled = true;
            this.sortCB.Items.AddRange(new object[] {
            "Alphabetical Descending",
            "Alphabetical Ascending",
            "Time In"});
            this.sortCB.Location = new System.Drawing.Point(175, 461);
            this.sortCB.Name = "sortCB";
            this.sortCB.Size = new System.Drawing.Size(139, 21);
            this.sortCB.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // changeStatusCB
            // 
            this.changeStatusCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.changeStatusCB.FormattingEnabled = true;
            this.changeStatusCB.Items.AddRange(new object[] {
            "Done Shopping",
            "Checked-Out"});
            this.changeStatusCB.Location = new System.Drawing.Point(350, 419);
            this.changeStatusCB.Name = "changeStatusCB";
            this.changeStatusCB.Size = new System.Drawing.Size(185, 21);
            this.changeStatusCB.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Change Status";
            // 
            // nameListBox
            // 
            this.nameListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.Location = new System.Drawing.Point(10, 58);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(161, 377);
            this.nameListBox.TabIndex = 1;
            this.nameListBox.SelectedIndexChanged += new System.EventHandler(this.nameListBox_SelectedIndexChanged);
            this.nameListBox.MouseEnter += new System.EventHandler(this.nameListBox_MouseEnter);
            this.nameListBox.MouseLeave += new System.EventHandler(this.nameListBox_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFieldsToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // resetFieldsToolStripMenuItem
            // 
            this.resetFieldsToolStripMenuItem.Name = "resetFieldsToolStripMenuItem";
            this.resetFieldsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetFieldsToolStripMenuItem.Text = "Reset Fields";
            this.resetFieldsToolStripMenuItem.Click += new System.EventHandler(this.resetFieldsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // shoppingCheck
            // 
            this.shoppingCheck.AutoSize = true;
            this.shoppingCheck.Checked = true;
            this.shoppingCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shoppingCheck.Location = new System.Drawing.Point(15, 445);
            this.shoppingCheck.Name = "shoppingCheck";
            this.shoppingCheck.Size = new System.Drawing.Size(71, 17);
            this.shoppingCheck.TabIndex = 12;
            this.shoppingCheck.Text = "Shopping";
            this.shoppingCheck.UseVisualStyleBackColor = true;
            this.shoppingCheck.CheckedChanged += new System.EventHandler(this.shoppingCheck_CheckedChanged);
            // 
            // doneShoppingCheck
            // 
            this.doneShoppingCheck.AutoSize = true;
            this.doneShoppingCheck.Location = new System.Drawing.Point(15, 461);
            this.doneShoppingCheck.Name = "doneShoppingCheck";
            this.doneShoppingCheck.Size = new System.Drawing.Size(100, 17);
            this.doneShoppingCheck.TabIndex = 13;
            this.doneShoppingCheck.Text = "Done Shopping";
            this.doneShoppingCheck.UseVisualStyleBackColor = true;
            this.doneShoppingCheck.CheckedChanged += new System.EventHandler(this.doneShoppingCheck_CheckedChanged);
            // 
            // checkedOutCheck
            // 
            this.checkedOutCheck.AutoSize = true;
            this.checkedOutCheck.Location = new System.Drawing.Point(15, 478);
            this.checkedOutCheck.Name = "checkedOutCheck";
            this.checkedOutCheck.Size = new System.Drawing.Size(89, 17);
            this.checkedOutCheck.TabIndex = 14;
            this.checkedOutCheck.Text = "Checked Out";
            this.checkedOutCheck.UseVisualStyleBackColor = true;
            this.checkedOutCheck.CheckedChanged += new System.EventHandler(this.checkedOutCheck_CheckedChanged);
            // 
            // statusTB
            // 
            this.statusTB.Location = new System.Drawing.Point(448, 84);
            this.statusTB.Name = "statusTB";
            this.statusTB.ReadOnly = true;
            this.statusTB.Size = new System.Drawing.Size(87, 20);
            this.statusTB.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(368, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Current Status";
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(448, 58);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(87, 20);
            this.firstNameTB.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(445, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "First Name";
            // 
            // dressAvailableTB
            // 
            this.dressAvailableTB.Location = new System.Drawing.Point(434, 380);
            this.dressAvailableTB.Mask = "90:00";
            this.dressAvailableTB.Name = "dressAvailableTB";
            this.dressAvailableTB.Size = new System.Drawing.Size(41, 20);
            this.dressAvailableTB.TabIndex = 8;
            this.dressAvailableTB.ValidatingType = typeof(System.DateTime);
            // 
            // ampmCB
            // 
            this.ampmCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ampmCB.FormattingEnabled = true;
            this.ampmCB.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.ampmCB.Location = new System.Drawing.Point(481, 380);
            this.ampmCB.Name = "ampmCB";
            this.ampmCB.Size = new System.Drawing.Size(54, 21);
            this.ampmCB.TabIndex = 9;
            // 
            // dayAvailableCB
            // 
            this.dayAvailableCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dayAvailableCB.FormattingEnabled = true;
            this.dayAvailableCB.Items.AddRange(new object[] {
            "Today",
            "Tomorrow"});
            this.dayAvailableCB.Location = new System.Drawing.Point(350, 380);
            this.dayAvailableCB.Name = "dayAvailableCB";
            this.dayAvailableCB.Size = new System.Drawing.Size(74, 21);
            this.dayAvailableCB.TabIndex = 31;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.Location = new System.Drawing.Point(135, 30);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(0, 24);
            this.counterLabel.TabIndex = 32;
            // 
            // fgFirstNameTB
            // 
            this.fgFirstNameTB.Location = new System.Drawing.Point(448, 128);
            this.fgFirstNameTB.Name = "fgFirstNameTB";
            this.fgFirstNameTB.Size = new System.Drawing.Size(87, 20);
            this.fgFirstNameTB.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(448, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "FG First Name";
            // 
            // fgNameListBox
            // 
            this.fgNameListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fgNameListBox.FormattingEnabled = true;
            this.fgNameListBox.Location = new System.Drawing.Point(171, 58);
            this.fgNameListBox.Name = "fgNameListBox";
            this.fgNameListBox.Size = new System.Drawing.Size(167, 377);
            this.fgNameListBox.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(254, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Fairy Godmother";
            // 
            // Checkout
            // 
            this.AcceptButton = this.updateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(567, 503);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.fgNameListBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.fgFirstNameTB);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.dayAvailableCB);
            this.Controls.Add(this.ampmCB);
            this.Controls.Add(this.dressAvailableTB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.statusTB);
            this.Controls.Add(this.checkedOutCheck);
            this.Controls.Add(this.doneShoppingCheck);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.shoppingCheck);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.changeStatusCB);
            this.Controls.Add(this.sortCB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.notesTB);
            this.Controls.Add(this.fgLastNameTB);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Checkout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.Checkout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lastNameTB;
        private System.Windows.Forms.TextBox fgLastNameTB;
        private System.Windows.Forms.ComboBox shoeSizeCB;
        private System.Windows.Forms.ComboBox dressSizeCB;
        private System.Windows.Forms.ComboBox alteredCB;
        private System.Windows.Forms.TextBox notesTB;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox sortCB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox changeStatusCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.CheckBox shoppingCheck;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.CheckBox doneShoppingCheck;
        private System.Windows.Forms.CheckBox checkedOutCheck;
        private System.Windows.Forms.ToolStripMenuItem resetFieldsToolStripMenuItem;
        private System.Windows.Forms.TextBox statusTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox dressAvailableTB;
        private System.Windows.Forms.ComboBox ampmCB;
        private System.Windows.Forms.ComboBox dayAvailableCB;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.TextBox fgFirstNameTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox fgNameListBox;
        private System.Windows.Forms.Label label14;
    }
}
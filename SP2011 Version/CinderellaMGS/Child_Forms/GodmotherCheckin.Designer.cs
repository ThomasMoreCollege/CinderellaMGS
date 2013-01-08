namespace CinderellaMGS
{
    partial class GodmotherCheckin
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
            this.sortByNameButton = new System.Windows.Forms.Button();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.checkInButton = new System.Windows.Forms.Button();
            this.checkInListBox = new System.Windows.Forms.ListBox();
            this.shiftCB = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addGodmotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sortByNameButton
            // 
            this.sortByNameButton.Location = new System.Drawing.Point(31, 295);
            this.sortByNameButton.Name = "sortByNameButton";
            this.sortByNameButton.Size = new System.Drawing.Size(202, 23);
            this.sortByNameButton.TabIndex = 8;
            this.sortByNameButton.Text = "Sort A-Z";
            this.sortByNameButton.UseVisualStyleBackColor = true;
            this.sortByNameButton.Click += new System.EventHandler(this.sortByNameButton_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(261, 252);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(121, 21);
            this.filterComboBox.TabIndex = 7;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged_1);
            // 
            // checkInButton
            // 
            this.checkInButton.Location = new System.Drawing.Point(279, 62);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(75, 23);
            this.checkInButton.TabIndex = 6;
            this.checkInButton.Text = "Check In";
            this.checkInButton.UseVisualStyleBackColor = false;
            this.checkInButton.Click += new System.EventHandler(this.checkInButton_Click_1);
            // 
            // checkInListBox
            // 
            this.checkInListBox.FormattingEnabled = true;
            this.checkInListBox.Location = new System.Drawing.Point(31, 38);
            this.checkInListBox.Name = "checkInListBox";
            this.checkInListBox.ScrollAlwaysVisible = true;
            this.checkInListBox.Size = new System.Drawing.Size(202, 251);
            this.checkInListBox.TabIndex = 5;
            // 
            // shiftCB
            // 
            this.shiftCB.FormattingEnabled = true;
            this.shiftCB.Location = new System.Drawing.Point(31, 329);
            this.shiftCB.Name = "shiftCB";
            this.shiftCB.Size = new System.Drawing.Size(202, 21);
            this.shiftCB.TabIndex = 11;
            this.shiftCB.SelectedIndexChanged += new System.EventHandler(this.shiftCB_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGodmotherToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // addGodmotherToolStripMenuItem
            // 
            this.addGodmotherToolStripMenuItem.Name = "addGodmotherToolStripMenuItem";
            this.addGodmotherToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addGodmotherToolStripMenuItem.Text = "Add &Godmother...";
            this.addGodmotherToolStripMenuItem.Click += new System.EventHandler(this.addGodmotherToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // GodmotherCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 362);
            this.Controls.Add(this.shiftCB);
            this.Controls.Add(this.sortByNameButton);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.checkInButton);
            this.Controls.Add(this.checkInListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GodmotherCheckin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GodmotherCheckin";
            this.Load += new System.EventHandler(this.GodmotherCheckin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sortByNameButton;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.ListBox checkInListBox;
        private System.Windows.Forms.ComboBox shiftCB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addGodmotherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}
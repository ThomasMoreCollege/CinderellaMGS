namespace CinderellaMGS
{
    partial class ManageGodmothers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageGodmothers));
            this.inactiveLabel = new System.Windows.Forms.Label();
            this.activeLabel = new System.Windows.Forms.Label();
            this.makeActiveButton = new System.Windows.Forms.Button();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.godmotherCheckinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGodmotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGodmotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.randomizeStartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.endShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.makeInactiveButton = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.inactiveLB = new System.Windows.Forms.ListBox();
            this.activeLB = new System.Windows.Forms.ListBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllGodmothersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waitingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentlyShoppingGB = new System.Windows.Forms.GroupBox();
            this.currentlyShoppingLB = new System.Windows.Forms.ListBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.cinderellaLB = new System.Windows.Forms.ListBox();
            this.shopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.godmotherLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.godmotherLB = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statsTB = new System.Windows.Forms.TextBox();
            this.Panel2.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.currentlyShoppingGB.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // inactiveLabel
            // 
            this.inactiveLabel.AutoSize = true;
            this.inactiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inactiveLabel.Location = new System.Drawing.Point(271, 16);
            this.inactiveLabel.Name = "inactiveLabel";
            this.inactiveLabel.Size = new System.Drawing.Size(102, 20);
            this.inactiveLabel.TabIndex = 18;
            this.inactiveLabel.Text = "Unavailable";
            // 
            // activeLabel
            // 
            this.activeLabel.AutoSize = true;
            this.activeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeLabel.Location = new System.Drawing.Point(5, 16);
            this.activeLabel.Name = "activeLabel";
            this.activeLabel.Size = new System.Drawing.Size(81, 20);
            this.activeLabel.TabIndex = 17;
            this.activeLabel.Text = "Available";
            // 
            // makeActiveButton
            // 
            this.makeActiveButton.Location = new System.Drawing.Point(216, 165);
            this.makeActiveButton.Name = "makeActiveButton";
            this.makeActiveButton.Size = new System.Drawing.Size(43, 23);
            this.makeActiveButton.TabIndex = 1;
            this.makeActiveButton.Text = "<----";
            this.makeActiveButton.UseVisualStyleBackColor = false;
            this.makeActiveButton.Click += new System.EventHandler(this.makeActiveButton_Click);
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.godmotherCheckinToolStripMenuItem,
            this.AddGodmotherToolStripMenuItem,
            this.deleteGodmotherToolStripMenuItem,
            this.toolStripSeparator2,
            this.randomizeStartToolStripMenuItem1,
            this.endShiftToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem1});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // godmotherCheckinToolStripMenuItem
            // 
            this.godmotherCheckinToolStripMenuItem.Name = "godmotherCheckinToolStripMenuItem";
            this.godmotherCheckinToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.godmotherCheckinToolStripMenuItem.Text = "Godmother Checkin...";
            this.godmotherCheckinToolStripMenuItem.Click += new System.EventHandler(this.godmotherCheckinToolStripMenuItem_Click);
            // 
            // AddGodmotherToolStripMenuItem
            // 
            this.AddGodmotherToolStripMenuItem.Name = "AddGodmotherToolStripMenuItem";
            this.AddGodmotherToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.AddGodmotherToolStripMenuItem.Text = "Add Godmother...";
            this.AddGodmotherToolStripMenuItem.Click += new System.EventHandler(this.addFairyGodmotherToolStripMenuItem_Click);
            // 
            // deleteGodmotherToolStripMenuItem
            // 
            this.deleteGodmotherToolStripMenuItem.Name = "deleteGodmotherToolStripMenuItem";
            this.deleteGodmotherToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteGodmotherToolStripMenuItem.Text = "Delete Godmother...";
            this.deleteGodmotherToolStripMenuItem.Click += new System.EventHandler(this.deleteFairyGodmotherToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // randomizeStartToolStripMenuItem1
            // 
            this.randomizeStartToolStripMenuItem1.Name = "randomizeStartToolStripMenuItem1";
            this.randomizeStartToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.randomizeStartToolStripMenuItem1.Text = "Begin Shift";
            this.randomizeStartToolStripMenuItem1.Click += new System.EventHandler(this.randomizeStartToolStripMenuItem_Click);
            // 
            // endShiftToolStripMenuItem
            // 
            this.endShiftToolStripMenuItem.Name = "endShiftToolStripMenuItem";
            this.endShiftToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.endShiftToolStripMenuItem.Text = "End Shift";
            this.endShiftToolStripMenuItem.Click += new System.EventHandler(this.endShiftToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem1.Text = "&Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // makeInactiveButton
            // 
            this.makeInactiveButton.Location = new System.Drawing.Point(216, 125);
            this.makeInactiveButton.Name = "makeInactiveButton";
            this.makeInactiveButton.Size = new System.Drawing.Size(43, 23);
            this.makeInactiveButton.TabIndex = 0;
            this.makeInactiveButton.Text = "---->";
            this.makeInactiveButton.UseVisualStyleBackColor = false;
            this.makeInactiveButton.Click += new System.EventHandler(this.makeInactiveButton_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.inactiveLB);
            this.Panel2.Location = new System.Drawing.Point(270, 39);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(200, 286);
            this.Panel2.TabIndex = 13;
            // 
            // inactiveLB
            // 
            this.inactiveLB.FormattingEnabled = true;
            this.inactiveLB.Location = new System.Drawing.Point(3, 3);
            this.inactiveLB.Name = "inactiveLB";
            this.inactiveLB.ScrollAlwaysVisible = true;
            this.inactiveLB.Size = new System.Drawing.Size(194, 277);
            this.inactiveLB.TabIndex = 0;
            // 
            // activeLB
            // 
            this.activeLB.FormattingEnabled = true;
            this.activeLB.Location = new System.Drawing.Point(3, 0);
            this.activeLB.Name = "activeLB";
            this.activeLB.ScrollAlwaysVisible = true;
            this.activeLB.Size = new System.Drawing.Size(194, 277);
            this.activeLB.TabIndex = 1;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(976, 24);
            this.MenuStrip1.TabIndex = 16;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllGodmothersToolStripMenuItem,
            this.waitingAreaToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // showAllGodmothersToolStripMenuItem
            // 
            this.showAllGodmothersToolStripMenuItem.CheckOnClick = true;
            this.showAllGodmothersToolStripMenuItem.Name = "showAllGodmothersToolStripMenuItem";
            this.showAllGodmothersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showAllGodmothersToolStripMenuItem.Text = "Show All Godmothers";
            this.showAllGodmothersToolStripMenuItem.Click += new System.EventHandler(this.showAllGodmothersToolStripMenuItem_Click);
            // 
            // waitingAreaToolStripMenuItem
            // 
            this.waitingAreaToolStripMenuItem.Name = "waitingAreaToolStripMenuItem";
            this.waitingAreaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.waitingAreaToolStripMenuItem.Text = "&Waiting Area";
            this.waitingAreaToolStripMenuItem.Click += new System.EventHandler(this.waitingAreaToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.activeLB);
            this.Panel1.Location = new System.Drawing.Point(5, 39);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(204, 286);
            this.Panel1.TabIndex = 12;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inactiveLabel);
            this.groupBox1.Controls.Add(this.activeLabel);
            this.groupBox1.Controls.Add(this.makeActiveButton);
            this.groupBox1.Controls.Add(this.makeInactiveButton);
            this.groupBox1.Controls.Add(this.Panel2);
            this.groupBox1.Controls.Add(this.Panel1);
            this.groupBox1.Location = new System.Drawing.Point(7, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Godmother Management";
            // 
            // currentlyShoppingGB
            // 
            this.currentlyShoppingGB.Controls.Add(this.currentlyShoppingLB);
            this.currentlyShoppingGB.Location = new System.Drawing.Point(7, 382);
            this.currentlyShoppingGB.Name = "currentlyShoppingGB";
            this.currentlyShoppingGB.Size = new System.Drawing.Size(422, 338);
            this.currentlyShoppingGB.TabIndex = 1;
            this.currentlyShoppingGB.TabStop = false;
            this.currentlyShoppingGB.Text = "Currently Shopping";
            // 
            // currentlyShoppingLB
            // 
            this.currentlyShoppingLB.FormattingEnabled = true;
            this.currentlyShoppingLB.Location = new System.Drawing.Point(15, 31);
            this.currentlyShoppingLB.Name = "currentlyShoppingLB";
            this.currentlyShoppingLB.ScrollAlwaysVisible = true;
            this.currentlyShoppingLB.Size = new System.Drawing.Size(358, 303);
            this.currentlyShoppingLB.TabIndex = 33;
            this.currentlyShoppingLB.Click += new System.EventHandler(this.godmotherCurrentlyShoppingLB_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.ForeColor = System.Drawing.Color.Maroon;
            this.outputLabel.Location = new System.Drawing.Point(41, 707);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(0, 13);
            this.outputLabel.TabIndex = 34;
            // 
            // cinderellaLB
            // 
            this.cinderellaLB.FormattingEnabled = true;
            this.cinderellaLB.Location = new System.Drawing.Point(211, 47);
            this.cinderellaLB.Name = "cinderellaLB";
            this.cinderellaLB.ScrollAlwaysVisible = true;
            this.cinderellaLB.Size = new System.Drawing.Size(194, 277);
            this.cinderellaLB.TabIndex = 28;
            this.cinderellaLB.Click += new System.EventHandler(this.cinderellaLB_Click);
            // 
            // shopButton
            // 
            this.shopButton.BackColor = System.Drawing.Color.LightSalmon;
            this.shopButton.Location = new System.Drawing.Point(416, 91);
            this.shopButton.Name = "shopButton";
            this.shopButton.Size = new System.Drawing.Size(48, 23);
            this.shopButton.TabIndex = 0;
            this.shopButton.Text = "Shop";
            this.shopButton.UseVisualStyleBackColor = false;
            this.shopButton.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Cinderellas";
            // 
            // godmotherLabel
            // 
            this.godmotherLabel.AutoSize = true;
            this.godmotherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godmotherLabel.Location = new System.Drawing.Point(15, 24);
            this.godmotherLabel.Name = "godmotherLabel";
            this.godmotherLabel.Size = new System.Drawing.Size(108, 20);
            this.godmotherLabel.TabIndex = 31;
            this.godmotherLabel.Text = "Godmothers";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.godmotherLB);
            this.panel3.Location = new System.Drawing.Point(15, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 286);
            this.panel3.TabIndex = 29;
            // 
            // godmotherLB
            // 
            this.godmotherLB.FormattingEnabled = true;
            this.godmotherLB.Location = new System.Drawing.Point(3, 0);
            this.godmotherLB.Name = "godmotherLB";
            this.godmotherLB.ScrollAlwaysVisible = true;
            this.godmotherLB.Size = new System.Drawing.Size(194, 277);
            this.godmotherLB.TabIndex = 1;
            this.godmotherLB.Click += new System.EventHandler(this.godmotherLB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cinderellaLB);
            this.groupBox3.Controls.Add(this.shopButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.godmotherLabel);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Location = new System.Drawing.Point(497, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 335);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shopping Management";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.statsTB);
            this.groupBox4.Location = new System.Drawing.Point(497, 384);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 334);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current Statistics";
            // 
            // statsTB
            // 
            this.statsTB.Location = new System.Drawing.Point(31, 47);
            this.statsTB.Multiline = true;
            this.statsTB.Name = "statsTB";
            this.statsTB.ReadOnly = true;
            this.statsTB.Size = new System.Drawing.Size(204, 277);
            this.statsTB.TabIndex = 0;
            // 
            // ManageGodmothers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 742);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.currentlyShoppingGB);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageGodmothers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageGodmothers";
            this.Load += new System.EventHandler(this.ManageGodmothers_Load);
            this.Panel2.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.currentlyShoppingGB.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inactiveLabel;
        private System.Windows.Forms.Label activeLabel;
        internal System.Windows.Forms.Button makeActiveButton;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGodmotherToolStripMenuItem;
        internal System.Windows.Forms.Button makeInactiveButton;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ListBox inactiveLB;
        internal System.Windows.Forms.ListBox activeLB;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox currentlyShoppingGB;
        private System.Windows.Forms.Label outputLabel;
        internal System.Windows.Forms.ListBox cinderellaLB;
        internal System.Windows.Forms.Button shopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label godmotherLabel;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.ListBox godmotherLB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox statsTB;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllGodmothersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGodmotherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem randomizeStartToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem waitingAreaToolStripMenuItem;
        internal System.Windows.Forms.ListBox currentlyShoppingLB;
        private System.Windows.Forms.ToolStripMenuItem endShiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem godmotherCheckinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}
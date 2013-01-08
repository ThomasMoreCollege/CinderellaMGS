namespace CinderellaLauncher
{
    partial class AdminMenu
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
            this.statusControlButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCinderella = new System.Windows.Forms.Button();
            this.importGodMothers = new System.Windows.Forms.Button();
            this.databaseMgtButton = new System.Windows.Forms.Button();
            this.accessAllButton = new System.Windows.Forms.Button();
            this.viewCinderellasButton = new System.Windows.Forms.Button();
            this.pairingButton = new System.Windows.Forms.Button();
            this.masterSearchButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusControlButton
            // 
            this.statusControlButton.BackColor = System.Drawing.Color.DarkGray;
            this.statusControlButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.statusControlButton.FlatAppearance.BorderSize = 2;
            this.statusControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusControlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusControlButton.Location = new System.Drawing.Point(51, 44);
            this.statusControlButton.Name = "statusControlButton";
            this.statusControlButton.Size = new System.Drawing.Size(163, 57);
            this.statusControlButton.TabIndex = 12;
            this.statusControlButton.Text = "FG_Status Control";
            this.statusControlButton.UseVisualStyleBackColor = false;
            this.statusControlButton.Click += new System.EventHandler(this.statusControlButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.chatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatNowToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // chatNowToolStripMenuItem
            // 
            this.chatNowToolStripMenuItem.Name = "chatNowToolStripMenuItem";
            this.chatNowToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.chatNowToolStripMenuItem.Text = "Chat Now";
            this.chatNowToolStripMenuItem.Click += new System.EventHandler(this.chatNowToolStripMenuItem_Click);
            // 
            // importCinderella
            // 
            this.importCinderella.BackColor = System.Drawing.Color.DarkGray;
            this.importCinderella.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.importCinderella.FlatAppearance.BorderSize = 2;
            this.importCinderella.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importCinderella.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importCinderella.Location = new System.Drawing.Point(328, 123);
            this.importCinderella.Name = "importCinderella";
            this.importCinderella.Size = new System.Drawing.Size(163, 57);
            this.importCinderella.TabIndex = 14;
            this.importCinderella.Text = "Import Cinderellas";
            this.importCinderella.UseVisualStyleBackColor = false;
            this.importCinderella.Click += new System.EventHandler(this.importCinderella_Click);
            // 
            // importGodMothers
            // 
            this.importGodMothers.BackColor = System.Drawing.Color.DarkGray;
            this.importGodMothers.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.importGodMothers.FlatAppearance.BorderSize = 2;
            this.importGodMothers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importGodMothers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importGodMothers.Location = new System.Drawing.Point(328, 211);
            this.importGodMothers.Name = "importGodMothers";
            this.importGodMothers.Size = new System.Drawing.Size(163, 57);
            this.importGodMothers.TabIndex = 15;
            this.importGodMothers.Text = "Import Fairy Godmothers";
            this.importGodMothers.UseVisualStyleBackColor = false;
            this.importGodMothers.Click += new System.EventHandler(this.importGodMothers_Click);
            // 
            // databaseMgtButton
            // 
            this.databaseMgtButton.BackColor = System.Drawing.Color.DarkGray;
            this.databaseMgtButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.databaseMgtButton.FlatAppearance.BorderSize = 2;
            this.databaseMgtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.databaseMgtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseMgtButton.Location = new System.Drawing.Point(51, 126);
            this.databaseMgtButton.Name = "databaseMgtButton";
            this.databaseMgtButton.Size = new System.Drawing.Size(163, 57);
            this.databaseMgtButton.TabIndex = 14;
            this.databaseMgtButton.Text = "Database Management";
            this.databaseMgtButton.UseVisualStyleBackColor = false;
            this.databaseMgtButton.Click += new System.EventHandler(this.databaseMgtButton_Click);
            // 
            // accessAllButton
            // 
            this.accessAllButton.BackColor = System.Drawing.Color.DarkGray;
            this.accessAllButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.accessAllButton.FlatAppearance.BorderSize = 2;
            this.accessAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accessAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessAllButton.Location = new System.Drawing.Point(326, 298);
            this.accessAllButton.Name = "accessAllButton";
            this.accessAllButton.Size = new System.Drawing.Size(163, 57);
            this.accessAllButton.TabIndex = 15;
            this.accessAllButton.Text = "Access All Forms";
            this.accessAllButton.UseVisualStyleBackColor = false;
            this.accessAllButton.Click += new System.EventHandler(this.accessAllButton_Click);
            // 
            // viewCinderellasButton
            // 
            this.viewCinderellasButton.BackColor = System.Drawing.Color.DarkGray;
            this.viewCinderellasButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.viewCinderellasButton.FlatAppearance.BorderSize = 2;
            this.viewCinderellasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewCinderellasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCinderellasButton.Location = new System.Drawing.Point(326, 44);
            this.viewCinderellasButton.Name = "viewCinderellasButton";
            this.viewCinderellasButton.Size = new System.Drawing.Size(163, 57);
            this.viewCinderellasButton.TabIndex = 16;
            this.viewCinderellasButton.Text = "View Cinderellas";
            this.viewCinderellasButton.UseVisualStyleBackColor = false;
            this.viewCinderellasButton.Click += new System.EventHandler(this.viewCinderellasButton_Click);
            // 
            // pairingButton
            // 
            this.pairingButton.BackColor = System.Drawing.Color.DarkGray;
            this.pairingButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.pairingButton.FlatAppearance.BorderSize = 2;
            this.pairingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pairingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairingButton.Location = new System.Drawing.Point(51, 211);
            this.pairingButton.Name = "pairingButton";
            this.pairingButton.Size = new System.Drawing.Size(163, 57);
            this.pairingButton.TabIndex = 18;
            this.pairingButton.Text = "Pairing";
            this.pairingButton.UseVisualStyleBackColor = false;
            this.pairingButton.Click += new System.EventHandler(this.pairingButton_Click);
            // 
            // masterSearchButton
            // 
            this.masterSearchButton.BackColor = System.Drawing.Color.DarkGray;
            this.masterSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.masterSearchButton.FlatAppearance.BorderSize = 2;
            this.masterSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.masterSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterSearchButton.Location = new System.Drawing.Point(51, 298);
            this.masterSearchButton.Name = "masterSearchButton";
            this.masterSearchButton.Size = new System.Drawing.Size(163, 57);
            this.masterSearchButton.TabIndex = 19;
            this.masterSearchButton.Text = "Master Search";
            this.masterSearchButton.UseVisualStyleBackColor = false;
            this.masterSearchButton.Click += new System.EventHandler(this.masterSearchButton_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(551, 380);
            this.Controls.Add(this.masterSearchButton);
            this.Controls.Add(this.pairingButton);
            this.Controls.Add(this.viewCinderellasButton);
            this.Controls.Add(this.importGodMothers);
            this.Controls.Add(this.importCinderella);
            this.Controls.Add(this.accessAllButton);
            this.Controls.Add(this.databaseMgtButton);
            this.Controls.Add(this.statusControlButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMenu";
            this.Text = "Administrator Menu";
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statusControlButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button importCinderella;
        private System.Windows.Forms.Button importGodMothers;
        private System.Windows.Forms.Button databaseMgtButton;
        private System.Windows.Forms.Button accessAllButton;
        private System.Windows.Forms.Button viewCinderellasButton;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatNowToolStripMenuItem;
        private System.Windows.Forms.Button pairingButton;
        private System.Windows.Forms.Button masterSearchButton;
    }
}
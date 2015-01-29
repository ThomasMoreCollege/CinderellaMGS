namespace CinderellaLauncher
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCinderellaMGSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinderellaCheckinButton = new System.Windows.Forms.Button();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.alterationsButton = new System.Windows.Forms.Button();
            this.shoppingMgtButton = new System.Windows.Forms.Button();
            this.matchMakingButton = new System.Windows.Forms.Button();
            this.addCinderellaButton = new System.Windows.Forms.Button();
            this.PSCheckin = new System.Windows.Forms.Button();
            this.viewCinderellasButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Snow;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.printToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 23);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutCinderellaMGSToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutCinderellaMGSToolStripMenuItem
            // 
            this.aboutCinderellaMGSToolStripMenuItem.Name = "aboutCinderellaMGSToolStripMenuItem";
            this.aboutCinderellaMGSToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.aboutCinderellaMGSToolStripMenuItem.Text = "About CinderellaMGS";
            this.aboutCinderellaMGSToolStripMenuItem.Click += new System.EventHandler(this.aboutCinderellaMGSToolStripMenuItem_Click);
            // 
            // cinderellaCheckinButton
            // 
            this.cinderellaCheckinButton.BackColor = System.Drawing.Color.Snow;
            this.cinderellaCheckinButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.cinderellaCheckinButton.FlatAppearance.BorderSize = 2;
            this.cinderellaCheckinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cinderellaCheckinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.cinderellaCheckinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cinderellaCheckinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinderellaCheckinButton.Location = new System.Drawing.Point(12, 39);
            this.cinderellaCheckinButton.Name = "cinderellaCheckinButton";
            this.cinderellaCheckinButton.Size = new System.Drawing.Size(163, 57);
            this.cinderellaCheckinButton.TabIndex = 1;
            this.cinderellaCheckinButton.Text = "Cinderella Check-In";
            this.cinderellaCheckinButton.UseVisualStyleBackColor = false;
            this.cinderellaCheckinButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkOutButton
            // 
            this.checkOutButton.BackColor = System.Drawing.Color.Snow;
            this.checkOutButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.checkOutButton.FlatAppearance.BorderSize = 2;
            this.checkOutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.checkOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.checkOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutButton.Location = new System.Drawing.Point(261, 39);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(163, 57);
            this.checkOutButton.TabIndex = 2;
            this.checkOutButton.Text = "Cinderella Check-Out";
            this.checkOutButton.UseVisualStyleBackColor = false;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // alterationsButton
            // 
            this.alterationsButton.BackColor = System.Drawing.Color.Snow;
            this.alterationsButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.alterationsButton.FlatAppearance.BorderSize = 2;
            this.alterationsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.alterationsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.alterationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterationsButton.Location = new System.Drawing.Point(12, 165);
            this.alterationsButton.Name = "alterationsButton";
            this.alterationsButton.Size = new System.Drawing.Size(163, 57);
            this.alterationsButton.TabIndex = 3;
            this.alterationsButton.Text = "Alterations";
            this.alterationsButton.UseVisualStyleBackColor = false;
            this.alterationsButton.Click += new System.EventHandler(this.alterationsButton_Click);
            // 
            // shoppingMgtButton
            // 
            this.shoppingMgtButton.BackColor = System.Drawing.Color.Snow;
            this.shoppingMgtButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.shoppingMgtButton.FlatAppearance.BorderSize = 2;
            this.shoppingMgtButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.shoppingMgtButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.shoppingMgtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shoppingMgtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingMgtButton.Location = new System.Drawing.Point(261, 165);
            this.shoppingMgtButton.Name = "shoppingMgtButton";
            this.shoppingMgtButton.Size = new System.Drawing.Size(163, 57);
            this.shoppingMgtButton.TabIndex = 6;
            this.shoppingMgtButton.Text = "Shopping Management";
            this.shoppingMgtButton.UseVisualStyleBackColor = false;
            this.shoppingMgtButton.Click += new System.EventHandler(this.managePSButton_Click);
            // 
            // matchMakingButton
            // 
            this.matchMakingButton.BackColor = System.Drawing.Color.Snow;
            this.matchMakingButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.matchMakingButton.FlatAppearance.BorderSize = 2;
            this.matchMakingButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.matchMakingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.matchMakingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.matchMakingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchMakingButton.Location = new System.Drawing.Point(261, 228);
            this.matchMakingButton.Name = "matchMakingButton";
            this.matchMakingButton.Size = new System.Drawing.Size(163, 57);
            this.matchMakingButton.TabIndex = 7;
            this.matchMakingButton.Text = "Pairing";
            this.matchMakingButton.UseVisualStyleBackColor = false;
            this.matchMakingButton.Click += new System.EventHandler(this.matchMakingButton_Click);
            // 
            // addCinderellaButton
            // 
            this.addCinderellaButton.BackColor = System.Drawing.Color.Snow;
            this.addCinderellaButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.addCinderellaButton.FlatAppearance.BorderSize = 2;
            this.addCinderellaButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addCinderellaButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.addCinderellaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCinderellaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCinderellaButton.Location = new System.Drawing.Point(261, 102);
            this.addCinderellaButton.Name = "addCinderellaButton";
            this.addCinderellaButton.Size = new System.Drawing.Size(163, 57);
            this.addCinderellaButton.TabIndex = 8;
            this.addCinderellaButton.Text = "Add Cinderella";
            this.addCinderellaButton.UseVisualStyleBackColor = false;
            this.addCinderellaButton.Click += new System.EventHandler(this.addCinderellaButton_Click);
            // 
            // PSCheckin
            // 
            this.PSCheckin.BackColor = System.Drawing.Color.Snow;
            this.PSCheckin.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.PSCheckin.FlatAppearance.BorderSize = 2;
            this.PSCheckin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.PSCheckin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.PSCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PSCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSCheckin.Location = new System.Drawing.Point(12, 102);
            this.PSCheckin.Name = "PSCheckin";
            this.PSCheckin.Size = new System.Drawing.Size(163, 57);
            this.PSCheckin.TabIndex = 9;
            this.PSCheckin.Text = "Fairy Godmother Check-In";
            this.PSCheckin.UseVisualStyleBackColor = false;
            this.PSCheckin.Click += new System.EventHandler(this.PSCheckin_Click);
            // 
            // viewCinderellasButton
            // 
            this.viewCinderellasButton.BackColor = System.Drawing.Color.Snow;
            this.viewCinderellasButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.viewCinderellasButton.FlatAppearance.BorderSize = 2;
            this.viewCinderellasButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.viewCinderellasButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.viewCinderellasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewCinderellasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCinderellasButton.Location = new System.Drawing.Point(12, 228);
            this.viewCinderellasButton.Name = "viewCinderellasButton";
            this.viewCinderellasButton.Size = new System.Drawing.Size(163, 57);
            this.viewCinderellasButton.TabIndex = 10;
            this.viewCinderellasButton.Text = "View Cinderellas";
            this.viewCinderellasButton.UseVisualStyleBackColor = false;
            this.viewCinderellasButton.Click += new System.EventHandler(this.viewCinderellasButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.BackColor = System.Drawing.Color.Snow;
            this.adminButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.adminButton.FlatAppearance.BorderSize = 2;
            this.adminButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.adminButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminButton.Location = new System.Drawing.Point(137, 293);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(163, 57);
            this.adminButton.TabIndex = 11;
            this.adminButton.Text = "Administration";
            this.adminButton.UseVisualStyleBackColor = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(436, 362);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.viewCinderellasButton);
            this.Controls.Add(this.PSCheckin);
            this.Controls.Add(this.addCinderellaButton);
            this.Controls.Add(this.matchMakingButton);
            this.Controls.Add(this.shoppingMgtButton);
            this.Controls.Add(this.alterationsButton);
            this.Controls.Add(this.checkOutButton);
            this.Controls.Add(this.cinderellaCheckinButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCinderellaMGSToolStripMenuItem;
        private System.Windows.Forms.Button cinderellaCheckinButton;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.Button alterationsButton;
        private System.Windows.Forms.Button shoppingMgtButton;
        private System.Windows.Forms.Button matchMakingButton;
        private System.Windows.Forms.Button addCinderellaButton;
        private System.Windows.Forms.Button PSCheckin;
        private System.Windows.Forms.Button viewCinderellasButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    }
}
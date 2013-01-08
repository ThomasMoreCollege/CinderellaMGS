namespace CinderellaLauncher
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.advancedButton = new System.Windows.Forms.Button();
            this.dbPasswordBox = new System.Windows.Forms.TextBox();
            this.dbUsernameBox = new System.Windows.Forms.TextBox();
            this.dbPortBox = new System.Windows.Forms.TextBox();
            this.dbServerBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBaseLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.connectionInfoBox = new System.Windows.Forms.TextBox();
            this.clearConfigLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dbDatabaseBox = new System.Windows.Forms.TextBox();
            this.adminAccessButton = new System.Windows.Forms.RadioButton();
            this.userAccessButton = new System.Windows.Forms.RadioButton();
            this.cindCheckInButton = new System.Windows.Forms.Button();
            this.shoppMgtButton = new System.Windows.Forms.Button();
            this.alterationsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fgCheckinButton = new System.Windows.Forms.Button();
            this.cindCheckOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(51, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 17);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(55, 49);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.Color.Snow;
            this.usernameBox.Location = new System.Drawing.Point(134, 23);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(126, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.Snow;
            this.passwordBox.Location = new System.Drawing.Point(134, 49);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(126, 20);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Snow;
            this.submitButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.submitButton.FlatAppearance.BorderSize = 2;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(266, 36);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(86, 30);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.ForeColor = System.Drawing.Color.Red;
            this.MessageLabel.Location = new System.Drawing.Point(297, 254);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(0, 13);
            this.MessageLabel.TabIndex = 8;
            // 
            // advancedButton
            // 
            this.advancedButton.BackColor = System.Drawing.Color.Snow;
            this.advancedButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.advancedButton.FlatAppearance.BorderSize = 2;
            this.advancedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advancedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedButton.Location = new System.Drawing.Point(12, 312);
            this.advancedButton.Name = "advancedButton";
            this.advancedButton.Size = new System.Drawing.Size(127, 30);
            this.advancedButton.TabIndex = 9;
            this.advancedButton.Text = "&Advanced >>";
            this.advancedButton.UseVisualStyleBackColor = false;
            this.advancedButton.Click += new System.EventHandler(this.advancedButton_Click);
            // 
            // dbPasswordBox
            // 
            this.dbPasswordBox.BackColor = System.Drawing.Color.Snow;
            this.dbPasswordBox.Location = new System.Drawing.Point(421, 477);
            this.dbPasswordBox.Name = "dbPasswordBox";
            this.dbPasswordBox.Size = new System.Drawing.Size(233, 20);
            this.dbPasswordBox.TabIndex = 22;
            this.dbPasswordBox.UseSystemPasswordChar = true;
            // 
            // dbUsernameBox
            // 
            this.dbUsernameBox.BackColor = System.Drawing.Color.Snow;
            this.dbUsernameBox.Location = new System.Drawing.Point(421, 451);
            this.dbUsernameBox.Name = "dbUsernameBox";
            this.dbUsernameBox.Size = new System.Drawing.Size(233, 20);
            this.dbUsernameBox.TabIndex = 21;
            // 
            // dbPortBox
            // 
            this.dbPortBox.BackColor = System.Drawing.Color.Snow;
            this.dbPortBox.Location = new System.Drawing.Point(421, 425);
            this.dbPortBox.Name = "dbPortBox";
            this.dbPortBox.Size = new System.Drawing.Size(233, 20);
            this.dbPortBox.TabIndex = 20;
            // 
            // dbServerBox
            // 
            this.dbServerBox.BackColor = System.Drawing.Color.Snow;
            this.dbServerBox.Location = new System.Drawing.Point(421, 399);
            this.dbServerBox.Name = "dbServerBox";
            this.dbServerBox.Size = new System.Drawing.Size(233, 20);
            this.dbServerBox.TabIndex = 19;
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.Snow;
            this.connectButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.connectButton.FlatAppearance.BorderSize = 2;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(421, 546);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(86, 30);
            this.connectButton.TabIndex = 17;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Password: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Username: ";
            // 
            // dataBaseLabel
            // 
            this.dataBaseLabel.AutoSize = true;
            this.dataBaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBaseLabel.Location = new System.Drawing.Point(338, 507);
            this.dataBaseLabel.Name = "dataBaseLabel";
            this.dataBaseLabel.Size = new System.Drawing.Size(87, 20);
            this.dataBaseLabel.TabIndex = 14;
            this.dataBaseLabel.Text = "Database: ";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(373, 428);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(46, 20);
            this.portLabel.TabIndex = 13;
            this.portLabel.Text = "Port: ";
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLabel.Location = new System.Drawing.Point(357, 399);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(63, 20);
            this.serverLabel.TabIndex = 12;
            this.serverLabel.Text = "Server: ";
            // 
            // connectionInfoBox
            // 
            this.connectionInfoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionInfoBox.Location = new System.Drawing.Point(40, 395);
            this.connectionInfoBox.Multiline = true;
            this.connectionInfoBox.Name = "connectionInfoBox";
            this.connectionInfoBox.Size = new System.Drawing.Size(288, 174);
            this.connectionInfoBox.TabIndex = 23;
            // 
            // clearConfigLink
            // 
            this.clearConfigLink.AutoSize = true;
            this.clearConfigLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearConfigLink.Location = new System.Drawing.Point(557, 530);
            this.clearConfigLink.Name = "clearConfigLink";
            this.clearConfigLink.Size = new System.Drawing.Size(96, 20);
            this.clearConfigLink.TabIndex = 24;
            this.clearConfigLink.TabStop = true;
            this.clearConfigLink.Text = "Clear Config";
            this.clearConfigLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearConfigLink_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dbDatabaseBox
            // 
            this.dbDatabaseBox.BackColor = System.Drawing.Color.Snow;
            this.dbDatabaseBox.Location = new System.Drawing.Point(421, 507);
            this.dbDatabaseBox.Name = "dbDatabaseBox";
            this.dbDatabaseBox.Size = new System.Drawing.Size(233, 20);
            this.dbDatabaseBox.TabIndex = 26;
            // 
            // adminAccessButton
            // 
            this.adminAccessButton.AutoSize = true;
            this.adminAccessButton.Location = new System.Drawing.Point(300, 217);
            this.adminAccessButton.Name = "adminAccessButton";
            this.adminAccessButton.Size = new System.Drawing.Size(92, 17);
            this.adminAccessButton.TabIndex = 27;
            this.adminAccessButton.TabStop = true;
            this.adminAccessButton.Text = "Admin Access";
            this.adminAccessButton.UseVisualStyleBackColor = true;
            this.adminAccessButton.CheckedChanged += new System.EventHandler(this.adminAccessButton_CheckedChanged);
            // 
            // userAccessButton
            // 
            this.userAccessButton.AutoSize = true;
            this.userAccessButton.Location = new System.Drawing.Point(300, 12);
            this.userAccessButton.Name = "userAccessButton";
            this.userAccessButton.Size = new System.Drawing.Size(85, 17);
            this.userAccessButton.TabIndex = 28;
            this.userAccessButton.TabStop = true;
            this.userAccessButton.Text = "User Access";
            this.userAccessButton.UseVisualStyleBackColor = true;
            // 
            // cindCheckInButton
            // 
            this.cindCheckInButton.BackColor = System.Drawing.Color.Snow;
            this.cindCheckInButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.cindCheckInButton.FlatAppearance.BorderSize = 2;
            this.cindCheckInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cindCheckInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cindCheckInButton.Location = new System.Drawing.Point(8, 15);
            this.cindCheckInButton.Name = "cindCheckInButton";
            this.cindCheckInButton.Size = new System.Drawing.Size(210, 35);
            this.cindCheckInButton.TabIndex = 29;
            this.cindCheckInButton.Text = "Cinderella Check-In";
            this.cindCheckInButton.UseVisualStyleBackColor = false;
            this.cindCheckInButton.Click += new System.EventHandler(this.cindCheckInOutButton_Click);
            // 
            // shoppMgtButton
            // 
            this.shoppMgtButton.BackColor = System.Drawing.Color.Snow;
            this.shoppMgtButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.shoppMgtButton.FlatAppearance.BorderSize = 2;
            this.shoppMgtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shoppMgtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppMgtButton.Location = new System.Drawing.Point(224, 56);
            this.shoppMgtButton.Name = "shoppMgtButton";
            this.shoppMgtButton.Size = new System.Drawing.Size(210, 35);
            this.shoppMgtButton.TabIndex = 30;
            this.shoppMgtButton.Text = "Shopping Management";
            this.shoppMgtButton.UseVisualStyleBackColor = false;
            this.shoppMgtButton.Click += new System.EventHandler(this.shoppMgtButton_Click);
            // 
            // alterationsButton
            // 
            this.alterationsButton.BackColor = System.Drawing.Color.Snow;
            this.alterationsButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.alterationsButton.FlatAppearance.BorderSize = 2;
            this.alterationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterationsButton.Location = new System.Drawing.Point(116, 97);
            this.alterationsButton.Name = "alterationsButton";
            this.alterationsButton.Size = new System.Drawing.Size(210, 35);
            this.alterationsButton.TabIndex = 32;
            this.alterationsButton.Text = "Alterations";
            this.alterationsButton.UseVisualStyleBackColor = false;
            this.alterationsButton.Click += new System.EventHandler(this.alterationsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.usernameBox);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(300, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 100);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.fgCheckinButton);
            this.panel2.Controls.Add(this.cindCheckOutButton);
            this.panel2.Controls.Add(this.cindCheckInButton);
            this.panel2.Controls.Add(this.shoppMgtButton);
            this.panel2.Controls.Add(this.alterationsButton);
            this.panel2.Location = new System.Drawing.Point(300, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 148);
            this.panel2.TabIndex = 35;
            // 
            // fgCheckinButton
            // 
            this.fgCheckinButton.BackColor = System.Drawing.Color.Snow;
            this.fgCheckinButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.fgCheckinButton.FlatAppearance.BorderSize = 2;
            this.fgCheckinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fgCheckinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fgCheckinButton.Location = new System.Drawing.Point(8, 56);
            this.fgCheckinButton.Name = "fgCheckinButton";
            this.fgCheckinButton.Size = new System.Drawing.Size(210, 35);
            this.fgCheckinButton.TabIndex = 34;
            this.fgCheckinButton.Text = "FairyGodmother Check-In";
            this.fgCheckinButton.UseVisualStyleBackColor = false;
            this.fgCheckinButton.Click += new System.EventHandler(this.fgCheckinButton_Click);
            // 
            // cindCheckOutButton
            // 
            this.cindCheckOutButton.BackColor = System.Drawing.Color.Snow;
            this.cindCheckOutButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.cindCheckOutButton.FlatAppearance.BorderSize = 2;
            this.cindCheckOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cindCheckOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cindCheckOutButton.Location = new System.Drawing.Point(224, 15);
            this.cindCheckOutButton.Name = "cindCheckOutButton";
            this.cindCheckOutButton.Size = new System.Drawing.Size(210, 35);
            this.cindCheckOutButton.TabIndex = 33;
            this.cindCheckOutButton.Text = "Cinderella Check-Out";
            this.cindCheckOutButton.UseVisualStyleBackColor = false;
            this.cindCheckOutButton.Click += new System.EventHandler(this.cindCheckOutButton_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(760, 358);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userAccessButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dbDatabaseBox);
            this.Controls.Add(this.clearConfigLink);
            this.Controls.Add(this.connectionInfoBox);
            this.Controls.Add(this.adminAccessButton);
            this.Controls.Add(this.dbPasswordBox);
            this.Controls.Add(this.dbUsernameBox);
            this.Controls.Add(this.dbPortBox);
            this.Controls.Add(this.dbServerBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataBaseLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.advancedButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "CinderellaMGS Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button advancedButton;
        private System.Windows.Forms.TextBox dbPasswordBox;
        private System.Windows.Forms.TextBox dbUsernameBox;
        private System.Windows.Forms.TextBox dbPortBox;
        private System.Windows.Forms.TextBox dbServerBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dataBaseLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TextBox connectionInfoBox;
        private System.Windows.Forms.LinkLabel clearConfigLink;
        private System.Windows.Forms.TextBox dbDatabaseBox;
        private System.Windows.Forms.RadioButton adminAccessButton;
        private System.Windows.Forms.RadioButton userAccessButton;
        private System.Windows.Forms.Button cindCheckInButton;
        private System.Windows.Forms.Button shoppMgtButton;
        private System.Windows.Forms.Button alterationsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cindCheckOutButton;
        private System.Windows.Forms.Button fgCheckinButton;
    }
}
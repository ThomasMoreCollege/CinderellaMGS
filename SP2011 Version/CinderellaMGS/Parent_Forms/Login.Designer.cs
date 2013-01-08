namespace CinderellaMGS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.logoPB = new System.Windows.Forms.PictureBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.ribbonPB = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.resetBT = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPB)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPB
            // 
            this.logoPB.Image = ((System.Drawing.Image)(resources.GetObject("logoPB.Image")));
            this.logoPB.Location = new System.Drawing.Point(5, 16);
            this.logoPB.Name = "logoPB";
            this.logoPB.Size = new System.Drawing.Size(231, 196);
            this.logoPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPB.TabIndex = 13;
            this.logoPB.TabStop = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(269, 86);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(97, 24);
            this.PasswordLabel.TabIndex = 12;
            this.PasswordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(266, 49);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(102, 24);
            this.usernameLabel.TabIndex = 11;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(375, 91);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(156, 20);
            this.passwordTB.TabIndex = 9;
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(375, 53);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(156, 20);
            this.usernameTB.TabIndex = 8;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(456, 135);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 10;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // ribbonPB
            // 
            this.ribbonPB.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPB.Image")));
            this.ribbonPB.Location = new System.Drawing.Point(378, 68);
            this.ribbonPB.Name = "ribbonPB";
            this.ribbonPB.Size = new System.Drawing.Size(202, 134);
            this.ribbonPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ribbonPB.TabIndex = 14;
            this.ribbonPB.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(330, 18);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 13);
            this.timeLabel.TabIndex = 15;
            // 
            // resetBT
            // 
            this.resetBT.AutoSize = true;
            this.resetBT.Location = new System.Drawing.Point(485, 199);
            this.resetBT.Name = "resetBT";
            this.resetBT.Size = new System.Drawing.Size(102, 13);
            this.resetBT.TabIndex = 16;
            this.resetBT.TabStop = true;
            this.resetBT.Text = "Reset Server Config";
            this.resetBT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetBT_LinkClicked);
            // 
            // Login
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 215);
            this.Controls.Add(this.resetBT);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.logoPB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.ribbonPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.logoPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPB;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.PictureBox ribbonPB;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.LinkLabel resetBT;

    }
}
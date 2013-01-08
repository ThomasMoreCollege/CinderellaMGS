namespace CinderellaMGS
{
    partial class User_Mngt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Mngt));
            this.userLB = new System.Windows.Forms.ComboBox();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.fnameLabel = new System.Windows.Forms.Label();
            this.fnameTB = new System.Windows.Forms.TextBox();
            this.lnameTB = new System.Windows.Forms.TextBox();
            this.lnameLabel = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.lastLoginTB = new System.Windows.Forms.TextBox();
            this.lastLoginLabel = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.detailsGB = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.roleLabel = new System.Windows.Forms.Label();
            this.rolesLB = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsGB.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userLB
            // 
            this.userLB.FormattingEnabled = true;
            this.userLB.Location = new System.Drawing.Point(44, 62);
            this.userLB.Name = "userLB";
            this.userLB.Size = new System.Drawing.Size(203, 21);
            this.userLB.TabIndex = 2;
            this.userLB.Visible = false;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(99, 28);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(203, 28);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // fnameLabel
            // 
            this.fnameLabel.AutoSize = true;
            this.fnameLabel.Location = new System.Drawing.Point(40, 69);
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(60, 13);
            this.fnameLabel.TabIndex = 12;
            this.fnameLabel.Text = "First Name:";
            // 
            // fnameTB
            // 
            this.fnameTB.Location = new System.Drawing.Point(119, 62);
            this.fnameTB.Name = "fnameTB";
            this.fnameTB.Size = new System.Drawing.Size(169, 20);
            this.fnameTB.TabIndex = 4;
            // 
            // lnameTB
            // 
            this.lnameTB.Location = new System.Drawing.Point(119, 87);
            this.lnameTB.Name = "lnameTB";
            this.lnameTB.Size = new System.Drawing.Size(169, 20);
            this.lnameTB.TabIndex = 5;
            // 
            // lnameLabel
            // 
            this.lnameLabel.AutoSize = true;
            this.lnameLabel.Location = new System.Drawing.Point(40, 94);
            this.lnameLabel.Name = "lnameLabel";
            this.lnameLabel.Size = new System.Drawing.Size(61, 13);
            this.lnameLabel.TabIndex = 13;
            this.lnameLabel.Text = "Last Name:";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(119, 36);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(169, 20);
            this.usernameTB.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(40, 43);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 11;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(119, 133);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(169, 20);
            this.passwordTB.TabIndex = 6;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(40, 136);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Password:";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(63, 310);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Visible = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(227, 310);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lastLoginTB
            // 
            this.lastLoginTB.Location = new System.Drawing.Point(119, 265);
            this.lastLoginTB.Name = "lastLoginTB";
            this.lastLoginTB.ReadOnly = true;
            this.lastLoginTB.Size = new System.Drawing.Size(169, 20);
            this.lastLoginTB.TabIndex = 14;
            // 
            // lastLoginLabel
            // 
            this.lastLoginLabel.AutoSize = true;
            this.lastLoginLabel.Location = new System.Drawing.Point(40, 272);
            this.lastLoginLabel.Name = "lastLoginLabel";
            this.lastLoginLabel.Size = new System.Drawing.Size(59, 13);
            this.lastLoginLabel.TabIndex = 13;
            this.lastLoginLabel.Text = "Last Login:";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(262, 60);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Visible = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // detailsGB
            // 
            this.detailsGB.Controls.Add(this.deleteButton);
            this.detailsGB.Controls.Add(this.roleLabel);
            this.detailsGB.Controls.Add(this.rolesLB);
            this.detailsGB.Controls.Add(this.usernameTB);
            this.detailsGB.Controls.Add(this.fnameLabel);
            this.detailsGB.Controls.Add(this.lastLoginTB);
            this.detailsGB.Controls.Add(this.fnameTB);
            this.detailsGB.Controls.Add(this.lastLoginLabel);
            this.detailsGB.Controls.Add(this.lnameLabel);
            this.detailsGB.Controls.Add(this.cancelButton);
            this.detailsGB.Controls.Add(this.lnameTB);
            this.detailsGB.Controls.Add(this.submitButton);
            this.detailsGB.Controls.Add(this.usernameLabel);
            this.detailsGB.Controls.Add(this.passwordTB);
            this.detailsGB.Controls.Add(this.passwordLabel);
            this.detailsGB.Location = new System.Drawing.Point(12, 84);
            this.detailsGB.Name = "detailsGB";
            this.detailsGB.Size = new System.Drawing.Size(350, 369);
            this.detailsGB.TabIndex = 4;
            this.detailsGB.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(144, 310);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(40, 180);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(43, 13);
            this.roleLabel.TabIndex = 0;
            this.roleLabel.Text = "Role(s):";
            // 
            // rolesLB
            // 
            this.rolesLB.FormattingEnabled = true;
            this.rolesLB.Location = new System.Drawing.Point(119, 180);
            this.rolesLB.Name = "rolesLB";
            this.rolesLB.ScrollAlwaysVisible = true;
            this.rolesLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.rolesLB.Size = new System.Drawing.Size(170, 69);
            this.rolesLB.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(378, 24);
            this.menuStrip1.TabIndex = 5;
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.modifyUserToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newUserToolStripMenuItem.Text = "New User";
            // 
            // modifyUserToolStripMenuItem
            // 
            this.modifyUserToolStripMenuItem.Name = "modifyUserToolStripMenuItem";
            this.modifyUserToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.modifyUserToolStripMenuItem.Text = "Modify User";
            // 
            // User_Mngt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 459);
            this.Controls.Add(this.detailsGB);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.userLB);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User_Mngt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.detailsGB.ResumeLayout(false);
            this.detailsGB.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox userLB;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label fnameLabel;
        private System.Windows.Forms.TextBox fnameTB;
        private System.Windows.Forms.TextBox lnameTB;
        private System.Windows.Forms.Label lnameLabel;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox lastLoginTB;
        private System.Windows.Forms.Label lastLoginLabel;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox detailsGB;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.ListBox rolesLB;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyUserToolStripMenuItem;
    }
}
namespace CinderellaLauncher
{
    partial class StatusControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusControl));
            this.resetButton = new System.Windows.Forms.Button();
            this.searchDGV = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unavailableButton = new System.Windows.Forms.RadioButton();
            this.pairedButton = new System.Windows.Forms.RadioButton();
            this.shoppingButton = new System.Windows.Forms.RadioButton();
            this.availableButton = new System.Windows.Forms.RadioButton();
            this.alterationsButton = new System.Windows.Forms.RadioButton();
            this.pendingButton = new System.Windows.Forms.RadioButton();
            this.setStatusButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.DarkGray;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.resetButton.FlatAppearance.BorderSize = 2;
            this.resetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(492, 46);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(82, 35);
            this.resetButton.TabIndex = 22;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // searchDGV
            // 
            this.searchDGV.AllowUserToAddRows = false;
            this.searchDGV.AllowUserToDeleteRows = false;
            this.searchDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.searchDGV.BackgroundColor = System.Drawing.Color.White;
            this.searchDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDGV.Location = new System.Drawing.Point(17, 113);
            this.searchDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchDGV.MultiSelect = false;
            this.searchDGV.Name = "searchDGV";
            this.searchDGV.RowHeadersVisible = false;
            this.searchDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchDGV.Size = new System.Drawing.Size(434, 231);
            this.searchDGV.TabIndex = 21;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.DarkGray;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.searchButton.FlatAppearance.BorderSize = 2;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(352, 46);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 35);
            this.searchButton.TabIndex = 20;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(115, 83);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(217, 20);
            this.firstNameBox.TabIndex = 19;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(115, 46);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(217, 20);
            this.lastNameBox.TabIndex = 18;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(13, 44);
            this.lastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(94, 20);
            this.lastNameLabel.TabIndex = 24;
            this.lastNameLabel.Text = "Last Name: ";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(13, 81);
            this.firstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(94, 20);
            this.firstNameLabel.TabIndex = 23;
            this.firstNameLabel.Text = "First Name: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 25;
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
            // unavailableButton
            // 
            this.unavailableButton.AutoSize = true;
            this.unavailableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unavailableButton.Location = new System.Drawing.Point(469, 129);
            this.unavailableButton.Name = "unavailableButton";
            this.unavailableButton.Size = new System.Drawing.Size(122, 21);
            this.unavailableButton.TabIndex = 26;
            this.unavailableButton.TabStop = true;
            this.unavailableButton.Text = "Unavailable (1)";
            this.unavailableButton.UseVisualStyleBackColor = true;
            // 
            // pairedButton
            // 
            this.pairedButton.AutoSize = true;
            this.pairedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pairedButton.Location = new System.Drawing.Point(469, 152);
            this.pairedButton.Name = "pairedButton";
            this.pairedButton.Size = new System.Drawing.Size(89, 21);
            this.pairedButton.TabIndex = 27;
            this.pairedButton.TabStop = true;
            this.pairedButton.Text = "Paired (2)";
            this.pairedButton.UseVisualStyleBackColor = true;
            // 
            // shoppingButton
            // 
            this.shoppingButton.AutoSize = true;
            this.shoppingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingButton.Location = new System.Drawing.Point(469, 175);
            this.shoppingButton.Name = "shoppingButton";
            this.shoppingButton.Size = new System.Drawing.Size(108, 21);
            this.shoppingButton.TabIndex = 28;
            this.shoppingButton.TabStop = true;
            this.shoppingButton.Text = "Shopping (3)";
            this.shoppingButton.UseVisualStyleBackColor = true;
            // 
            // availableButton
            // 
            this.availableButton.AutoSize = true;
            this.availableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableButton.Location = new System.Drawing.Point(469, 198);
            this.availableButton.Name = "availableButton";
            this.availableButton.Size = new System.Drawing.Size(105, 21);
            this.availableButton.TabIndex = 29;
            this.availableButton.TabStop = true;
            this.availableButton.Text = "Available (4)";
            this.availableButton.UseVisualStyleBackColor = true;
            // 
            // alterationsButton
            // 
            this.alterationsButton.AutoSize = true;
            this.alterationsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterationsButton.Location = new System.Drawing.Point(469, 221);
            this.alterationsButton.Name = "alterationsButton";
            this.alterationsButton.Size = new System.Drawing.Size(115, 21);
            this.alterationsButton.TabIndex = 30;
            this.alterationsButton.TabStop = true;
            this.alterationsButton.Text = "Alterations (5)";
            this.alterationsButton.UseVisualStyleBackColor = true;
            // 
            // pendingButton
            // 
            this.pendingButton.AutoSize = true;
            this.pendingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingButton.Location = new System.Drawing.Point(469, 244);
            this.pendingButton.Name = "pendingButton";
            this.pendingButton.Size = new System.Drawing.Size(100, 21);
            this.pendingButton.TabIndex = 31;
            this.pendingButton.TabStop = true;
            this.pendingButton.Text = "Pending (6)";
            this.pendingButton.UseVisualStyleBackColor = true;
            // 
            // setStatusButton
            // 
            this.setStatusButton.BackColor = System.Drawing.Color.DarkGray;
            this.setStatusButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.setStatusButton.FlatAppearance.BorderSize = 2;
            this.setStatusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.setStatusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.setStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setStatusButton.Location = new System.Drawing.Point(474, 289);
            this.setStatusButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setStatusButton.Name = "setStatusButton";
            this.setStatusButton.Size = new System.Drawing.Size(97, 37);
            this.setStatusButton.TabIndex = 32;
            this.setStatusButton.Text = "Set Status";
            this.setStatusButton.UseVisualStyleBackColor = false;
            this.setStatusButton.Click += new System.EventHandler(this.setStatusButton_Click);
            // 
            // StatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(600, 361);
            this.Controls.Add(this.setStatusButton);
            this.Controls.Add(this.pendingButton);
            this.Controls.Add(this.alterationsButton);
            this.Controls.Add(this.availableButton);
            this.Controls.Add(this.shoppingButton);
            this.Controls.Add(this.pairedButton);
            this.Controls.Add(this.unavailableButton);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.searchDGV);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StatusControl";
            this.Text = "Fairy Godmother Status Control";
            this.Load += new System.EventHandler(this.StatusControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.DataGridView searchDGV;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RadioButton unavailableButton;
        private System.Windows.Forms.RadioButton pairedButton;
        private System.Windows.Forms.RadioButton shoppingButton;
        private System.Windows.Forms.RadioButton availableButton;
        private System.Windows.Forms.RadioButton alterationsButton;
        private System.Windows.Forms.RadioButton pendingButton;
        private System.Windows.Forms.Button setStatusButton;
    }
}
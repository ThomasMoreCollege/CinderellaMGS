namespace CinderellaLauncher
{
    partial class DBManagement
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBPurgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullPurgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFairyGodmothersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCinderellasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.queryBox = new System.Windows.Forms.TextBox();
            this.runQueryButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.functionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 0;
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
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBPurgeToolStripMenuItem,
            this.fullPurgeToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteFairyGodmothersToolStripMenuItem,
            this.deleteCinderellasToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // dBPurgeToolStripMenuItem
            // 
            this.dBPurgeToolStripMenuItem.Name = "dBPurgeToolStripMenuItem";
            this.dBPurgeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.dBPurgeToolStripMenuItem.Text = "Lite Purge";
            this.dBPurgeToolStripMenuItem.Click += new System.EventHandler(this.dBPurgeToolStripMenuItem_Click);
            // 
            // fullPurgeToolStripMenuItem
            // 
            this.fullPurgeToolStripMenuItem.Image = global::CinderellaLauncher.Properties.Resources.close64;
            this.fullPurgeToolStripMenuItem.Name = "fullPurgeToolStripMenuItem";
            this.fullPurgeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.fullPurgeToolStripMenuItem.Text = "Full Purge";
            this.fullPurgeToolStripMenuItem.Click += new System.EventHandler(this.fullPurgeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // deleteFairyGodmothersToolStripMenuItem
            // 
            this.deleteFairyGodmothersToolStripMenuItem.Name = "deleteFairyGodmothersToolStripMenuItem";
            this.deleteFairyGodmothersToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteFairyGodmothersToolStripMenuItem.Text = "Delete Fairy Godmothers";
            this.deleteFairyGodmothersToolStripMenuItem.Click += new System.EventHandler(this.deleteFairyGodmothersToolStripMenuItem_Click);
            // 
            // deleteCinderellasToolStripMenuItem
            // 
            this.deleteCinderellasToolStripMenuItem.Name = "deleteCinderellasToolStripMenuItem";
            this.deleteCinderellasToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteCinderellasToolStripMenuItem.Text = "Delete Cinderellas";
            this.deleteCinderellasToolStripMenuItem.Click += new System.EventHandler(this.deleteCinderellasToolStripMenuItem_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 180);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(664, 179);
            this.dgv.TabIndex = 1;
            // 
            // queryBox
            // 
            this.queryBox.Location = new System.Drawing.Point(12, 65);
            this.queryBox.Multiline = true;
            this.queryBox.Name = "queryBox";
            this.queryBox.Size = new System.Drawing.Size(473, 76);
            this.queryBox.TabIndex = 2;
            // 
            // runQueryButton
            // 
            this.runQueryButton.BackColor = System.Drawing.Color.DarkGray;
            this.runQueryButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.runQueryButton.FlatAppearance.BorderSize = 2;
            this.runQueryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.runQueryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.runQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runQueryButton.Location = new System.Drawing.Point(509, 76);
            this.runQueryButton.Name = "runQueryButton";
            this.runQueryButton.Size = new System.Drawing.Size(111, 52);
            this.runQueryButton.TabIndex = 3;
            this.runQueryButton.Text = "Run Query";
            this.runQueryButton.UseVisualStyleBackColor = false;
            this.runQueryButton.Click += new System.EventHandler(this.runQueryButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.DarkGray;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.clearButton.FlatAppearance.BorderSize = 2;
            this.clearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(635, 84);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(63, 37);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // DBManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(737, 393);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.runQueryButton);
            this.Controls.Add(this.queryBox);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DBManagement";
            this.Text = "Data Base Management";
            this.Load += new System.EventHandler(this.DBManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBPurgeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox queryBox;
        private System.Windows.Forms.Button runQueryButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem deleteCinderellasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullPurgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteFairyGodmothersToolStripMenuItem;
    }
}
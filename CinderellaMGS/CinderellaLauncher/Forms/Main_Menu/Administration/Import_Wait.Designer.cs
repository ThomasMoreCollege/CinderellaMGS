namespace CinderellaLauncher.Forms.Administration
{
    partial class Import_Wait
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
            this.okbutton1 = new System.Windows.Forms.Button();
            this.importfinishedlabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okbutton1
            // 
            this.okbutton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.okbutton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbutton1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.okbutton1.FlatAppearance.BorderSize = 2;
            this.okbutton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.okbutton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.okbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okbutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okbutton1.Location = new System.Drawing.Point(137, 261);
            this.okbutton1.Name = "okbutton1";
            this.okbutton1.Size = new System.Drawing.Size(75, 23);
            this.okbutton1.TabIndex = 0;
            this.okbutton1.Text = "OK";
            this.okbutton1.UseVisualStyleBackColor = false;
            // 
            // importfinishedlabel1
            // 
            this.importfinishedlabel1.AutoSize = true;
            this.importfinishedlabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importfinishedlabel1.Location = new System.Drawing.Point(56, 95);
            this.importfinishedlabel1.Name = "importfinishedlabel1";
            this.importfinishedlabel1.Size = new System.Drawing.Size(244, 25);
            this.importfinishedlabel1.TabIndex = 1;
            this.importfinishedlabel1.Text = "Import Has Completed";
            // 
            // Import_Wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 308);
            this.Controls.Add(this.importfinishedlabel1);
            this.Controls.Add(this.okbutton1);
            this.Name = "Import_Wait";
            this.Text = "Import_Wait";
            this.Load += new System.EventHandler(this.Import_Wait_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okbutton1;
        private System.Windows.Forms.Label importfinishedlabel1;
    }
}
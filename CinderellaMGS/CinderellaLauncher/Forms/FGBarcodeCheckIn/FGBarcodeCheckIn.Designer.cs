namespace CinderellaLauncher
{
    partial class FGCheckInBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGCheckInBarcode));
            this.label1 = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.DisplayCindi = new System.Windows.Forms.Label();
            this.BarcodeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(64, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check In Barcode Scanner";
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(123, 139);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(0, 13);
            this.timeLbl.TabIndex = 5;
            // 
            // DisplayCindi
            // 
            this.DisplayCindi.AutoSize = true;
            this.DisplayCindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayCindi.Location = new System.Drawing.Point(121, 102);
            this.DisplayCindi.Name = "DisplayCindi";
            this.DisplayCindi.Size = new System.Drawing.Size(0, 13);
            this.DisplayCindi.TabIndex = 4;
            // 
            // BarcodeTextBox
            // 
            this.BarcodeTextBox.Location = new System.Drawing.Point(142, 195);
            this.BarcodeTextBox.Name = "BarcodeTextBox";
            this.BarcodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.BarcodeTextBox.TabIndex = 1;
            this.BarcodeTextBox.TextChanged += new System.EventHandler(this.BarcodeTextBox_TextChanged);
            this.BarcodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarcodeTextBox_KeyPress);
            // 
            // FGCheckInBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(386, 364);
            this.Controls.Add(this.BarcodeTextBox);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.DisplayCindi);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FGCheckInBarcode";
            this.Text = "Fairy Godmother Check In Barcode";
            this.Load += new System.EventHandler(this.FGCheckInBarcode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Label DisplayCindi;
        private System.Windows.Forms.TextBox BarcodeTextBox;
    }
}
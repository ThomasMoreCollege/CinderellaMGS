

namespace CinderellaLauncher
{
    partial class CinderellaCheckInBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CinderellaCheckInBarcode));
            this.CheckInTitleLbl = new System.Windows.Forms.Label();
            this.CinderellaCheckInBarcodeTextbox = new System.Windows.Forms.TextBox();
            this.DisplayCindi = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckInTitleLbl
            // 
            this.CheckInTitleLbl.AutoSize = true;
            this.CheckInTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInTitleLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CheckInTitleLbl.Location = new System.Drawing.Point(64, 50);
            this.CheckInTitleLbl.Name = "CheckInTitleLbl";
            this.CheckInTitleLbl.Size = new System.Drawing.Size(271, 25);
            this.CheckInTitleLbl.TabIndex = 0;
            this.CheckInTitleLbl.Text = "Check In Barcode Scanner";
            // 
            // CinderellaCheckInBarcodeTextbox
            // 
            this.CinderellaCheckInBarcodeTextbox.Location = new System.Drawing.Point(12, 207);
            this.CinderellaCheckInBarcodeTextbox.Name = "CinderellaCheckInBarcodeTextbox";
            this.CinderellaCheckInBarcodeTextbox.Size = new System.Drawing.Size(380, 20);
            this.CinderellaCheckInBarcodeTextbox.TabIndex = 1;
            this.CinderellaCheckInBarcodeTextbox.TextChanged += new System.EventHandler(this.CinderellaCheckInBarcodeTextbox_TextChanged);
            this.CinderellaCheckInBarcodeTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CinderellaCheckInBarcodeTextbox_KeyPress);
            // 
            // DisplayCindi
            // 
            this.DisplayCindi.AutoSize = true;
            this.DisplayCindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayCindi.Location = new System.Drawing.Point(108, 113);
            this.DisplayCindi.Name = "DisplayCindi";
            this.DisplayCindi.Size = new System.Drawing.Size(0, 13);
            this.DisplayCindi.TabIndex = 2;
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(110, 150);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(0, 13);
            this.timeLbl.TabIndex = 3;
            // 
            // CinderellaCheckInBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(404, 239);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.DisplayCindi);
            this.Controls.Add(this.CinderellaCheckInBarcodeTextbox);
            this.Controls.Add(this.CheckInTitleLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CinderellaCheckInBarcode";
            this.Text = "Cinderella Check In Barcode";
            this.Load += new System.EventHandler(this.CinderellaCheckInBarcode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CheckInTitleLbl;
        private System.Windows.Forms.TextBox CinderellaCheckInBarcodeTextbox;
        private System.Windows.Forms.Label DisplayCindi;
        private System.Windows.Forms.Label timeLbl;
    }
}
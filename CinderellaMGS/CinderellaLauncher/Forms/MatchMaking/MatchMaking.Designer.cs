namespace CinderellaLauncher
{
    partial class MatchMaking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchMaking));
            this.personalShoppersLabel = new System.Windows.Forms.Label();
            this.cinderellasLabel = new System.Windows.Forms.Label();
            this.personalShopperListBox = new System.Windows.Forms.ListBox();
            this.cinderellaListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TMCLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personalShoppersLabel
            // 
            this.personalShoppersLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.personalShoppersLabel.AutoSize = true;
            this.personalShoppersLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalShoppersLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.personalShoppersLabel.Location = new System.Drawing.Point(64, 23);
            this.personalShoppersLabel.Name = "personalShoppersLabel";
            this.personalShoppersLabel.Size = new System.Drawing.Size(343, 41);
            this.personalShoppersLabel.TabIndex = 0;
            this.personalShoppersLabel.Text = "Personal Shoppers";
            // 
            // cinderellasLabel
            // 
            this.cinderellasLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cinderellasLabel.AutoSize = true;
            this.cinderellasLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinderellasLabel.Location = new System.Drawing.Point(131, 23);
            this.cinderellasLabel.Name = "cinderellasLabel";
            this.cinderellasLabel.Size = new System.Drawing.Size(216, 41);
            this.cinderellasLabel.TabIndex = 1;
            this.cinderellasLabel.Text = "Cinderellas";
            // 
            // personalShopperListBox
            // 
            this.personalShopperListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personalShopperListBox.BackColor = System.Drawing.Color.Snow;
            this.personalShopperListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.personalShopperListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalShopperListBox.FormattingEnabled = true;
            this.personalShopperListBox.ItemHeight = 37;
            this.personalShopperListBox.Location = new System.Drawing.Point(54, 73);
            this.personalShopperListBox.Name = "personalShopperListBox";
            this.personalShopperListBox.Size = new System.Drawing.Size(365, 485);
            this.personalShopperListBox.TabIndex = 1;
            this.personalShopperListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.personalShopperListBox_DrawItem);
            // 
            // cinderellaListBox
            // 
            this.cinderellaListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cinderellaListBox.BackColor = System.Drawing.Color.Snow;
            this.cinderellaListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cinderellaListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinderellaListBox.FormattingEnabled = true;
            this.cinderellaListBox.ItemHeight = 37;
            this.cinderellaListBox.Location = new System.Drawing.Point(48, 73);
            this.cinderellaListBox.Name = "cinderellaListBox";
            this.cinderellaListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cinderellaListBox.Size = new System.Drawing.Size(365, 514);
            this.cinderellaListBox.TabIndex = 3;
            this.cinderellaListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cinderellaListBox_DrawItem);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::CinderellaLauncher.Properties.Resources.logoSmallTransparent;
            this.pictureBox1.Location = new System.Drawing.Point(283, 592);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::CinderellaLauncher.Properties.Resources.TMCshield;
            this.pictureBox2.Location = new System.Drawing.Point(54, 593);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TMCLabel);
            this.splitContainer1.Panel1.Controls.Add(this.personalShoppersLabel);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.personalShopperListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cinderellasLabel);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.cinderellaListBox);
            this.splitContainer1.Size = new System.Drawing.Size(933, 694);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 6;
            // 
            // TMCLabel
            // 
            this.TMCLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TMCLabel.AutoSize = true;
            this.TMCLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TMCLabel.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMCLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.TMCLabel.Location = new System.Drawing.Point(132, 615);
            this.TMCLabel.Name = "TMCLabel";
            this.TMCLabel.Size = new System.Drawing.Size(287, 33);
            this.TMCLabel.TabIndex = 6;
            this.TMCLabel.Text = "Thomas More College";
            // 
            // MatchMaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(933, 694);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatchMaking";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Pairing";
            this.Load += new System.EventHandler(this.MatchMaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label personalShoppersLabel;
        private System.Windows.Forms.Label cinderellasLabel;
        private System.Windows.Forms.ListBox personalShopperListBox;
        private System.Windows.Forms.ListBox cinderellaListBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label TMCLabel;
        
    }
}
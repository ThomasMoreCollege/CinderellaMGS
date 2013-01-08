namespace CinderellaLauncher
{
    partial class UndoCinderellaCheckIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UndoCinderellaCheckIn));
            this.refreshButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.undoDGV = new System.Windows.Forms.DataGridView();
            this.cinderellaCheckedInLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.undoDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Snow;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.refreshButton.FlatAppearance.BorderSize = 2;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(415, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(88, 31);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.BackColor = System.Drawing.Color.Snow;
            this.undoButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.undoButton.FlatAppearance.BorderSize = 2;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoButton.Location = new System.Drawing.Point(214, 330);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 32);
            this.undoButton.TabIndex = 1;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = false;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // undoDGV
            // 
            this.undoDGV.AllowUserToAddRows = false;
            this.undoDGV.AllowUserToDeleteRows = false;
            this.undoDGV.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.undoDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.undoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.undoDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.undoDGV.Location = new System.Drawing.Point(8, 65);
            this.undoDGV.MultiSelect = false;
            this.undoDGV.Name = "undoDGV";
            this.undoDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.undoDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.undoDGV.RowHeadersVisible = false;
            this.undoDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.undoDGV.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.undoDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            this.undoDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.undoDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.undoDGV.Size = new System.Drawing.Size(495, 259);
            this.undoDGV.TabIndex = 2;
            // 
            // cinderellaCheckedInLabel
            // 
            this.cinderellaCheckedInLabel.AutoSize = true;
            this.cinderellaCheckedInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinderellaCheckedInLabel.Location = new System.Drawing.Point(4, 32);
            this.cinderellaCheckedInLabel.Name = "cinderellaCheckedInLabel";
            this.cinderellaCheckedInLabel.Size = new System.Drawing.Size(195, 20);
            this.cinderellaCheckedInLabel.TabIndex = 3;
            this.cinderellaCheckedInLabel.Text = "Checked-In Cinderellas";
            // 
            // UndoCinderellaCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(513, 377);
            this.Controls.Add(this.cinderellaCheckedInLabel);
            this.Controls.Add(this.undoDGV);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.refreshButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UndoCinderellaCheckIn";
            this.Text = "Undo Checked-In Cinderellas";
            this.Load += new System.EventHandler(this.UndoCinderellaCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.undoDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.DataGridView undoDGV;
        private System.Windows.Forms.Label cinderellaCheckedInLabel;
    }
}
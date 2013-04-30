namespace CinderellaLauncher
{
    partial class UndoCheckIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UndoCheckIn));
            this.fairyGodmothersDGV = new System.Windows.Forms.DataGridView();
            this.fairyGodmothersLabel = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.refreshButtonUndoCheckIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fairyGodmothersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // fairyGodmothersDGV
            // 
            this.fairyGodmothersDGV.AllowUserToAddRows = false;
            this.fairyGodmothersDGV.AllowUserToDeleteRows = false;
            this.fairyGodmothersDGV.AllowUserToOrderColumns = true;
            this.fairyGodmothersDGV.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fairyGodmothersDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fairyGodmothersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fairyGodmothersDGV.Location = new System.Drawing.Point(12, 61);
            this.fairyGodmothersDGV.Name = "fairyGodmothersDGV";
            this.fairyGodmothersDGV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fairyGodmothersDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fairyGodmothersDGV.RowHeadersVisible = false;
            this.fairyGodmothersDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.fairyGodmothersDGV.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fairyGodmothersDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.fairyGodmothersDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleVioletRed;
            this.fairyGodmothersDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.fairyGodmothersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fairyGodmothersDGV.Size = new System.Drawing.Size(489, 291);
            this.fairyGodmothersDGV.TabIndex = 0;
            // 
            // fairyGodmothersLabel
            // 
            this.fairyGodmothersLabel.AutoSize = true;
            this.fairyGodmothersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fairyGodmothersLabel.Location = new System.Drawing.Point(8, 32);
            this.fairyGodmothersLabel.Name = "fairyGodmothersLabel";
            this.fairyGodmothersLabel.Size = new System.Drawing.Size(249, 20);
            this.fairyGodmothersLabel.TabIndex = 1;
            this.fairyGodmothersLabel.Text = "Checked-In Fairy Godmothers";
            // 
            // undoButton
            // 
            this.undoButton.BackColor = System.Drawing.Color.Snow;
            this.undoButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.undoButton.FlatAppearance.BorderSize = 2;
            this.undoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.undoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoButton.Location = new System.Drawing.Point(205, 358);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(86, 30);
            this.undoButton.TabIndex = 3;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = false;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // refreshButtonUndoCheckIn
            // 
            this.refreshButtonUndoCheckIn.BackColor = System.Drawing.Color.Snow;
            this.refreshButtonUndoCheckIn.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.refreshButtonUndoCheckIn.FlatAppearance.BorderSize = 2;
            this.refreshButtonUndoCheckIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.refreshButtonUndoCheckIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.refreshButtonUndoCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButtonUndoCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButtonUndoCheckIn.Location = new System.Drawing.Point(411, 12);
            this.refreshButtonUndoCheckIn.Name = "refreshButtonUndoCheckIn";
            this.refreshButtonUndoCheckIn.Size = new System.Drawing.Size(90, 32);
            this.refreshButtonUndoCheckIn.TabIndex = 4;
            this.refreshButtonUndoCheckIn.Text = "Refresh";
            this.refreshButtonUndoCheckIn.UseVisualStyleBackColor = false;
            this.refreshButtonUndoCheckIn.Click += new System.EventHandler(this.refreshButtonUndoCheckIn_Click);
            // 
            // UndoCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(513, 399);
            this.Controls.Add(this.refreshButtonUndoCheckIn);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.fairyGodmothersLabel);
            this.Controls.Add(this.fairyGodmothersDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UndoCheckIn";
            this.Text = "Undo Checked-In Fairy Godmother";
            this.Load += new System.EventHandler(this.UndoCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fairyGodmothersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView fairyGodmothersDGV;
        private System.Windows.Forms.Label fairyGodmothersLabel;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button refreshButtonUndoCheckIn;
    }
}
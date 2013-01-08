namespace CinderellaMGS
{
    partial class ExecuteQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteQuery));
            this.queryTB = new System.Windows.Forms.TextBox();
            this.executeBT = new System.Windows.Forms.Button();
            this.clearBT = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // queryTB
            // 
            this.queryTB.Location = new System.Drawing.Point(12, 12);
            this.queryTB.Multiline = true;
            this.queryTB.Name = "queryTB";
            this.queryTB.Size = new System.Drawing.Size(380, 217);
            this.queryTB.TabIndex = 0;
            // 
            // executeBT
            // 
            this.executeBT.BackColor = System.Drawing.Color.LightSkyBlue;
            this.executeBT.Location = new System.Drawing.Point(51, 249);
            this.executeBT.Name = "executeBT";
            this.executeBT.Size = new System.Drawing.Size(75, 23);
            this.executeBT.TabIndex = 1;
            this.executeBT.Text = "Execute";
            this.executeBT.UseVisualStyleBackColor = false;
            this.executeBT.Click += new System.EventHandler(this.executeBT_Click);
            // 
            // clearBT
            // 
            this.clearBT.BackColor = System.Drawing.Color.LightSkyBlue;
            this.clearBT.Location = new System.Drawing.Point(162, 249);
            this.clearBT.Name = "clearBT";
            this.clearBT.Size = new System.Drawing.Size(75, 23);
            this.clearBT.TabIndex = 2;
            this.clearBT.Text = "Clear";
            this.clearBT.UseVisualStyleBackColor = false;
            this.clearBT.Click += new System.EventHandler(this.clearBT_Click);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.ForeColor = System.Drawing.Color.Maroon;
            this.output.Location = new System.Drawing.Point(12, 282);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(0, 13);
            this.output.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.closeButton.Location = new System.Drawing.Point(271, 249);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(296, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "List of Table Names";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ExecuteQuery
            // 
            this.AcceptButton = this.executeBT;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.output);
            this.Controls.Add(this.clearBT);
            this.Controls.Add(this.executeBT);
            this.Controls.Add(this.queryTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExecuteQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExecuteQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox queryTB;
        private System.Windows.Forms.Button executeBT;
        private System.Windows.Forms.Button clearBT;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
    }
}
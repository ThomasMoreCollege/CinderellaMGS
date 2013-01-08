namespace CinderellaLauncher
{
    partial class changeAppointmentTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeAppointmentTime));
            this.newApptTimeLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.newApptDateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.currentButton = new System.Windows.Forms.RadioButton();
            this.manualButton = new System.Windows.Forms.RadioButton();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // newApptTimeLabel
            // 
            this.newApptTimeLabel.AutoSize = true;
            this.newApptTimeLabel.Enabled = false;
            this.newApptTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newApptTimeLabel.Location = new System.Drawing.Point(42, 97);
            this.newApptTimeLabel.Name = "newApptTimeLabel";
            this.newApptTimeLabel.Size = new System.Drawing.Size(177, 20);
            this.newApptTimeLabel.TabIndex = 2;
            this.newApptTimeLabel.Text = "New Appointment Time:";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Snow;
            this.submitButton.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.submitButton.FlatAppearance.BorderSize = 2;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(180, 197);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(86, 30);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // newApptDateLabel
            // 
            this.newApptDateLabel.AutoSize = true;
            this.newApptDateLabel.Enabled = false;
            this.newApptDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newApptDateLabel.Location = new System.Drawing.Point(42, 60);
            this.newApptDateLabel.Name = "newApptDateLabel";
            this.newApptDateLabel.Size = new System.Drawing.Size(161, 20);
            this.newApptDateLabel.TabIndex = 9;
            this.newApptDateLabel.Text = "Date of Appointment:";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "yyyy-MM-dd";
            this.datePicker.Enabled = false;
            this.datePicker.Location = new System.Drawing.Point(226, 60);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(186, 20);
            this.datePicker.TabIndex = 10;
            // 
            // currentButton
            // 
            this.currentButton.AutoSize = true;
            this.currentButton.Checked = true;
            this.currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentButton.Location = new System.Drawing.Point(16, 146);
            this.currentButton.Name = "currentButton";
            this.currentButton.Size = new System.Drawing.Size(221, 24);
            this.currentButton.TabIndex = 11;
            this.currentButton.TabStop = true;
            this.currentButton.Text = "Use Current Time and Date";
            this.currentButton.UseVisualStyleBackColor = true;
            // 
            // manualButton
            // 
            this.manualButton.AutoSize = true;
            this.manualButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualButton.Location = new System.Drawing.Point(16, 24);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(187, 24);
            this.manualButton.TabIndex = 12;
            this.manualButton.TabStop = true;
            this.manualButton.Text = "Manual Time and Date";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.CheckedChanged += new System.EventHandler(this.manualButton_CheckedChanged);
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "HH:mm:ss";
            this.timePicker.Enabled = false;
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(226, 96);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(186, 20);
            this.timePicker.TabIndex = 13;
            // 
            // changeAppointmentTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(451, 239);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.manualButton);
            this.Controls.Add(this.currentButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.newApptDateLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.newApptTimeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "changeAppointmentTime";
            this.Text = "Change Appointment Time";
            this.Load += new System.EventHandler(this.changeAppointmentTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newApptTimeLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label newApptDateLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.RadioButton currentButton;
        private System.Windows.Forms.RadioButton manualButton;
        private System.Windows.Forms.DateTimePicker timePicker;
    }
}
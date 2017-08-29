namespace DoctorPanel
{
    partial class DoctorAddTimeSlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorAddTimeSlot));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timeDoctorEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDayDescription = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timeDoctorBegining = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSunday = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.btnSaturday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnWendsday = new System.Windows.Forms.Button();
            this.btnThursday = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnAddDuty = new System.Windows.Forms.Button();
            this.btnUpdateDuty = new System.Windows.Forms.Button();
            this.txtDoctorTicket = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 559);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.panel3.Controls.Add(this.lblDashboard);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(742, 40);
            this.panel3.TabIndex = 24;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(12, 9);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(179, 22);
            this.lblDashboard.TabIndex = 7;
            this.lblDashboard.Text = "Working Time Slot";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDoctorTicket);
            this.panel2.Controls.Add(this.btnUpdateDuty);
            this.panel2.Controls.Add(this.btnAddDuty);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.lblDayDescription);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(54, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 203);
            this.panel2.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.timeDoctorEnd);
            this.panel5.Location = new System.Drawing.Point(328, 89);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(108, 26);
            this.panel5.TabIndex = 27;
            // 
            // timeDoctorEnd
            // 
            this.timeDoctorEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.timeDoctorEnd.Enabled = false;
            this.timeDoctorEnd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDoctorEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeDoctorEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeDoctorEnd.Location = new System.Drawing.Point(-1, -2);
            this.timeDoctorEnd.Name = "timeDoctorEnd";
            this.timeDoctorEnd.ShowUpDown = true;
            this.timeDoctorEnd.Size = new System.Drawing.Size(133, 27);
            this.timeDoctorEnd.TabIndex = 25;
            this.timeDoctorEnd.Value = new System.DateTime(2017, 8, 29, 0, 0, 0, 0);
            // 
            // lblDayDescription
            // 
            this.lblDayDescription.AutoSize = true;
            this.lblDayDescription.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayDescription.Location = new System.Drawing.Point(171, 13);
            this.lblDayDescription.Name = "lblDayDescription";
            this.lblDayDescription.Size = new System.Drawing.Size(246, 26);
            this.lblDayDescription.TabIndex = 6;
            this.lblDayDescription.Text = "Select A Day To Edit or Add";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.timeDoctorBegining);
            this.panel4.Location = new System.Drawing.Point(328, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 30);
            this.panel4.TabIndex = 26;
            // 
            // timeDoctorBegining
            // 
            this.timeDoctorBegining.Cursor = System.Windows.Forms.Cursors.Default;
            this.timeDoctorBegining.Enabled = false;
            this.timeDoctorBegining.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDoctorBegining.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeDoctorBegining.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timeDoctorBegining.Location = new System.Drawing.Point(-1, -2);
            this.timeDoctorBegining.Name = "timeDoctorBegining";
            this.timeDoctorBegining.ShowUpDown = true;
            this.timeDoctorBegining.Size = new System.Drawing.Size(133, 27);
            this.timeDoctorBegining.TabIndex = 24;
            this.timeDoctorBegining.Value = new System.DateTime(2017, 8, 29, 0, 0, 0, 0);
            this.timeDoctorBegining.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tickets Per Day : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service End Time : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Begining Time : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSunday);
            this.groupBox1.Controls.Add(this.btnMonday);
            this.groupBox1.Controls.Add(this.btnSaturday);
            this.groupBox1.Controls.Add(this.btnTuesday);
            this.groupBox1.Controls.Add(this.btnFriday);
            this.groupBox1.Controls.Add(this.btnWendsday);
            this.groupBox1.Controls.Add(this.btnThursday);
            this.groupBox1.Location = new System.Drawing.Point(54, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 124);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Days";
            // 
            // btnSunday
            // 
            this.btnSunday.BackColor = System.Drawing.Color.White;
            this.btnSunday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSunday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSunday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSunday.Location = new System.Drawing.Point(547, 38);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(60, 60);
            this.btnSunday.TabIndex = 21;
            this.btnSunday.Text = "Sun";
            this.btnSunday.UseVisualStyleBackColor = false;
            this.btnSunday.Click += new System.EventHandler(this.btnSunday_Click);
            // 
            // btnMonday
            // 
            this.btnMonday.BackColor = System.Drawing.Color.White;
            this.btnMonday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMonday.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMonday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonday.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMonday.Location = new System.Drawing.Point(14, 38);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(60, 60);
            this.btnMonday.TabIndex = 0;
            this.btnMonday.Text = "Mon";
            this.btnMonday.UseVisualStyleBackColor = false;
            this.btnMonday.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSaturday
            // 
            this.btnSaturday.BackColor = System.Drawing.Color.White;
            this.btnSaturday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaturday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaturday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSaturday.Location = new System.Drawing.Point(462, 38);
            this.btnSaturday.Name = "btnSaturday";
            this.btnSaturday.Size = new System.Drawing.Size(60, 60);
            this.btnSaturday.TabIndex = 20;
            this.btnSaturday.Text = "Sat";
            this.btnSaturday.UseVisualStyleBackColor = false;
            this.btnSaturday.Click += new System.EventHandler(this.btnSaturday_Click);
            // 
            // btnTuesday
            // 
            this.btnTuesday.BackColor = System.Drawing.Color.White;
            this.btnTuesday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTuesday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuesday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnTuesday.Location = new System.Drawing.Point(102, 38);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(60, 60);
            this.btnTuesday.TabIndex = 16;
            this.btnTuesday.Text = "Tue";
            this.btnTuesday.UseVisualStyleBackColor = false;
            this.btnTuesday.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFriday
            // 
            this.btnFriday.BackColor = System.Drawing.Color.White;
            this.btnFriday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFriday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFriday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnFriday.Location = new System.Drawing.Point(373, 38);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(60, 60);
            this.btnFriday.TabIndex = 19;
            this.btnFriday.Text = "Fri";
            this.btnFriday.UseVisualStyleBackColor = false;
            this.btnFriday.Click += new System.EventHandler(this.btnFriday_Click);
            // 
            // btnWendsday
            // 
            this.btnWendsday.BackColor = System.Drawing.Color.White;
            this.btnWendsday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWendsday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWendsday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnWendsday.Location = new System.Drawing.Point(192, 38);
            this.btnWendsday.Name = "btnWendsday";
            this.btnWendsday.Size = new System.Drawing.Size(60, 60);
            this.btnWendsday.TabIndex = 17;
            this.btnWendsday.Text = "Wen";
            this.btnWendsday.UseVisualStyleBackColor = false;
            this.btnWendsday.Click += new System.EventHandler(this.btnWendsday_Click);
            // 
            // btnThursday
            // 
            this.btnThursday.BackColor = System.Drawing.Color.White;
            this.btnThursday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThursday.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThursday.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnThursday.Location = new System.Drawing.Point(282, 38);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(60, 60);
            this.btnThursday.TabIndex = 18;
            this.btnThursday.Text = "Thu";
            this.btnThursday.UseVisualStyleBackColor = false;
            this.btnThursday.Click += new System.EventHandler(this.btnThursday_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DoctorPanel.Properties.Resources.ACMA_logo_1;
            this.pictureBox3.Location = new System.Drawing.Point(531, 473);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(164, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // btnAddDuty
            // 
            this.btnAddDuty.Location = new System.Drawing.Point(414, 156);
            this.btnAddDuty.Name = "btnAddDuty";
            this.btnAddDuty.Size = new System.Drawing.Size(86, 32);
            this.btnAddDuty.TabIndex = 28;
            this.btnAddDuty.Text = "Add Time";
            this.btnAddDuty.UseVisualStyleBackColor = true;
            this.btnAddDuty.Visible = false;
            this.btnAddDuty.Click += new System.EventHandler(this.btnAddDuty_Click);
            // 
            // btnUpdateDuty
            // 
            this.btnUpdateDuty.Location = new System.Drawing.Point(414, 156);
            this.btnUpdateDuty.Name = "btnUpdateDuty";
            this.btnUpdateDuty.Size = new System.Drawing.Size(86, 32);
            this.btnUpdateDuty.TabIndex = 29;
            this.btnUpdateDuty.Text = "Update Time";
            this.btnUpdateDuty.UseVisualStyleBackColor = true;
            this.btnUpdateDuty.Visible = false;
            this.btnUpdateDuty.Click += new System.EventHandler(this.btnUpdateDuty_Click);
            // 
            // txtDoctorTicket
            // 
            this.txtDoctorTicket.Enabled = false;
            this.txtDoctorTicket.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorTicket.Location = new System.Drawing.Point(327, 121);
            this.txtDoctorTicket.Name = "txtDoctorTicket";
            this.txtDoctorTicket.Size = new System.Drawing.Size(48, 26);
            this.txtDoctorTicket.TabIndex = 25;
            // 
            // DoctorAddTimeSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 559);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DoctorAddTimeSlot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorAddTimeSlot";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.Button btnSaturday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnWendsday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDayDescription;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.DateTimePicker timeDoctorBegining;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker timeDoctorEnd;
        private System.Windows.Forms.Button btnUpdateDuty;
        private System.Windows.Forms.Button btnAddDuty;
        private System.Windows.Forms.NumericUpDown txtDoctorTicket;
    }
}
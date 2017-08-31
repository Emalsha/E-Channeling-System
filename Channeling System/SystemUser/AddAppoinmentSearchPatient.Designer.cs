namespace SystemUser
{
    partial class AddAppoinmentSearchPatient
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
            this.components = new System.ComponentModel.Container();
            this.btnreload = new System.Windows.Forms.Button();
            this.txtnicnumber = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txttelephone = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnaddpatient = new System.Windows.Forms.Button();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnic = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbl_doctoruid = new System.Windows.Forms.Label();
            this.lblday = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lbldesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnreload
            // 
            this.btnreload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnreload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnreload.Image = global::SystemUser.Properties.Resources.refresh;
            this.btnreload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnreload.Location = new System.Drawing.Point(316, 409);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(103, 28);
            this.btnreload.TabIndex = 33;
            this.btnreload.Text = "Reload Search";
            this.btnreload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreload.UseVisualStyleBackColor = false;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // txtnicnumber
            // 
            this.txtnicnumber.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnicnumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtnicnumber.Location = new System.Drawing.Point(203, 266);
            this.txtnicnumber.Name = "txtnicnumber";
            this.txtnicnumber.Size = new System.Drawing.Size(216, 25);
            this.txtnicnumber.TabIndex = 29;
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtname.Location = new System.Drawing.Point(203, 219);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(216, 25);
            this.txtname.TabIndex = 28;
            // 
            // txttelephone
            // 
            this.txttelephone.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelephone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txttelephone.Location = new System.Drawing.Point(203, 310);
            this.txttelephone.Name = "txttelephone";
            this.txttelephone.Size = new System.Drawing.Size(216, 25);
            this.txttelephone.TabIndex = 30;
            // 
            // btnaddpatient
            // 
            this.btnaddpatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnaddpatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddpatient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnaddpatient.Image = global::SystemUser.Properties.Resources.new_user;
            this.btnaddpatient.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaddpatient.Location = new System.Drawing.Point(203, 409);
            this.btnaddpatient.Name = "btnaddpatient";
            this.btnaddpatient.Size = new System.Drawing.Size(95, 28);
            this.btnaddpatient.TabIndex = 32;
            this.btnaddpatient.Text = "Add Patient";
            this.btnaddpatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddpatient.UseVisualStyleBackColor = false;
            this.btnaddpatient.Click += new System.EventHandler(this.btnaddpatient_Click);
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtaddress.Location = new System.Drawing.Point(203, 356);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(216, 25);
            this.txtaddress.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(44, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "Resident Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(44, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Telephone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(44, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "NIC Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(44, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Full Name";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblname.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblname.Location = new System.Drawing.Point(159, 59);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(0, 22);
            this.lblname.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SystemUser.Properties.Resources.user_search;
            this.pictureBox1.Location = new System.Drawing.Point(405, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsearch.Image = global::SystemUser.Properties.Resources.search;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsearch.Location = new System.Drawing.Point(163, 142);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(147, 28);
            this.btnsearch.TabIndex = 21;
            this.btnsearch.Text = "Search Patient by NIC";
            this.btnsearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Search Patient";
            // 
            // txtnic
            // 
            this.txtnic.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtnic.Location = new System.Drawing.Point(130, 95);
            this.txtnic.Name = "txtnic";
            this.txtnic.Size = new System.Drawing.Size(215, 29);
            this.txtnic.TabIndex = 20;
            this.txtnic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 46);
            this.panel1.TabIndex = 19;
            // 
            // lbl_doctoruid
            // 
            this.lbl_doctoruid.AutoSize = true;
            this.lbl_doctoruid.Location = new System.Drawing.Point(600, 46);
            this.lbl_doctoruid.Name = "lbl_doctoruid";
            this.lbl_doctoruid.Size = new System.Drawing.Size(35, 13);
            this.lbl_doctoruid.TabIndex = 34;
            this.lbl_doctoruid.Text = "label6";
            // 
            // lblday
            // 
            this.lblday.AutoSize = true;
            this.lblday.Location = new System.Drawing.Point(600, 82);
            this.lblday.Name = "lblday";
            this.lblday.Size = new System.Drawing.Size(35, 13);
            this.lblday.TabIndex = 35;
            this.lblday.Text = "label6";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(600, 111);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(35, 13);
            this.lbltime.TabIndex = 36;
            this.lbltime.Text = "label6";
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Location = new System.Drawing.Point(610, 142);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(35, 13);
            this.lbldesc.TabIndex = 37;
            this.lbldesc.Text = "label6";
            // 
            // AddAppoinmentSearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(464, 207);
            this.Controls.Add(this.lbldesc);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lblday);
            this.Controls.Add(this.lbl_doctoruid);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.txtnicnumber);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txttelephone);
            this.Controls.Add(this.btnaddpatient);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtnic);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddAppoinmentSearchPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddAppoinmentSearchPatient";
            this.Load += new System.EventHandler(this.AddAppoinmentSearchPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.TextBox txtnicnumber;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txttelephone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnaddpatient;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbl_doctoruid;
        private System.Windows.Forms.Label lblday;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lbldesc;

    }
}
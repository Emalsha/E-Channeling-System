using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemUser
{
    public partial class PrintReceipt : Form
    {
        public PrintReceipt(int patient_id_, int doctor_id, string day, string time, string description)
        {
            InitializeComponent();

            lbl_cat.Text = patient_id_.ToString();
            lbl_d_id.Text = doctor_id.ToString();
            lbl_date.Text = day;
            lbl_time.Text = time;
            lbl_cat.Text = description;

        }

        private void PrintReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}

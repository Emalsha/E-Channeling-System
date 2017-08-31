using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SystemUser.SystemModel;

namespace SystemUser
{
    public partial class CancelAppoinment : Form
    {
        public CancelAppoinment()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SystemController SearchAppoinment = new SystemController();

            string appoinment_id = txtappoinmentId.Text;
            int appoinment_id_ = Convert.ToInt32(appoinment_id);

            List<SearchDoctorModel> ByAppoinmentId = SearchAppoinment.SearchAppoinmentToCanel(appoinment_id_);

            if (ByAppoinmentId.Count == 1)
            {
                this.Height = 400;

                foreach (SearchDoctorModel dataRow in ByAppoinmentId)
                {
                    lbl_app_id.Text = dataRow.Appoinment_id.ToString();
                    lbl_p_name.Text = dataRow.Patient_name;
                    lbl_d_name.Text = dataRow.Doctor_name;
                    lbl_catogery.Text = dataRow.Catogery;
                    

                }
            }else
            {
                MessageBox.Show("No any active appoinment records found in this ID!","Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Height = 242;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appoinment_id = txtappoinmentId.Text;
            int appoinment_id_ = Convert.ToInt32(appoinment_id);

            SystemController CancelAppoinment = new SystemController();
            CancelAppoinment.UpdateAppoinmentStatus(appoinment_id_);

            this.Height = 242;
            txtappoinmentId.Text = "";
        }
    }
}

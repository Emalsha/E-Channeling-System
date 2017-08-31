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
using DoctorPanel.Models;
using SystemUser.SystemModel;

namespace SystemUser
{
    public partial class RemovePatient : Form
    {
        public RemovePatient()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SystemController SearchPatientByNic = new SystemController();

            string nic = txtnic.Text;

            List<SearchDoctorModel> BypatientNic = SearchPatientByNic.SearchAllPatient(nic);

            if (BypatientNic.Count > 0)
            {
                listView1.Items.Clear();

                foreach (SearchDoctorModel dataRow in BypatientNic)
                {
                    ListViewItem ListItem = new ListViewItem(dataRow.P_fullname);
                    ListItem.SubItems.Add(dataRow.P_nic);
                    ListItem.SubItems.Add(dataRow.P_telephone.ToString());
                    ListItem.SubItems.Add(dataRow.P_address);

                    listView1.Items.Add(ListItem);
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string nic = listView1.SelectedItems[0].SubItems[1].Text.ToString();

            var dResult = MessageBox.Show("Do you want to delete this patient form the system?", "Delete Authentication", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dResult == DialogResult.Yes)
            {
                SystemController deletePatient = new SystemController();
                deletePatient.RemovePatient(nic);
                listView1.Refresh();
            }
        }
    }
}

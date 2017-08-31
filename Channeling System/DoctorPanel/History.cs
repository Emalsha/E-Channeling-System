using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoctorPanel.Models;

namespace DoctorPanel
{
    public partial class History : Form
    {
        private int doctorId;
        public History(int doctorId_)
        {
            InitializeComponent();
            doctorId = doctorId_;
            ViewHistory(doctorId);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewHistory(doctorId);
        }

        private void ViewHistory(int doctorId)
        {
            DoctorController dc = new DoctorController();
            List<DoctorToday> docList = dc.DoctorHistory(doctorId); // Use login doctor id...
            if (docList.Count() > 0)
            {
                lstHistor.Items.Clear();
                int i = 1;
                foreach (DoctorToday dataItem in docList)
                {   
                    ListViewItem item = new ListViewItem(dataItem.Appinment_id.ToString());
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add(dataItem.Patient_name);
                    item.SubItems.Add(dataItem.Appoinment_created_date.ToString("mm/dd/yyyy"));
                    item.SubItems.Add(dataItem.Appoinment_time);
                    item.SubItems.Add(dataItem.Catogery);
                    item.SubItems.Add(dataItem.State == 1 ? "Active" : "Canceled");

                    lstHistor.Items.Add(item);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Sorry, No appoinments to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstHistor.Items.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemUser.SystemModel;

namespace SystemUser
{
    public partial class RemoveDoctor : Form
    {
        public RemoveDoctor()
        {
            InitializeComponent();
        }

        private void btnAddDoctorCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoctorSearch_Click(object sender, EventArgs e)
        {
            string doctorName = txtDoctorSearch.Text;

            SystemController SearchDoctorName = new SystemController();

            List<SearchDoctorModel> byDoctorName = SearchDoctorName.SearchDoctorByName(doctorName);
            if (byDoctorName.Count() > 0)
            {
                listViewDoctor.Items.Clear();

                foreach (SearchDoctorModel dataRow in byDoctorName)
                {
                    ListViewItem ListItem = new ListViewItem(dataRow.Doctor_id.ToString());
                    ListItem.SubItems.Add(dataRow.Fullname);
                    ListItem.SubItems.Add(dataRow.Descriptionl);
                    ListItem.SubItems.Add(dataRow.Room_number.ToString());
                    

                    listViewDoctor.Items.Add(ListItem);
                }
            }
        }

        private void listViewDoctor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string msg = "Do you want to delete "+listViewDoctor.SelectedItems[0].SubItems[1].Text+" from the system.";
            var msgBox = MessageBox.Show(msg,"Delete Doctor !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (msgBox == System.Windows.Forms.DialogResult.Yes)
            {
                SystemController sc = new SystemController();
                string res = sc.RemoveDoctor(int.Parse(listViewDoctor.SelectedItems[0].SubItems[0].Text));

                MessageBox.Show(res);
                listViewDoctor.Items.Clear();
            }
        }
    }
}

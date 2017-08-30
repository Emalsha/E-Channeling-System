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
    public partial class AddAppointmentDoctorInfo : Form
    {
        public AddAppointmentDoctorInfo(string doctor_id, string doctor_name, string weekedn, string room, string desc)
        {
            InitializeComponent();
            
        }

        private void AddAppointmentDoctorInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

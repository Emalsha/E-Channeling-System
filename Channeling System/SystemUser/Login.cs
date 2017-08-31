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

namespace SystemUser
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SystemController login = new SystemController();
            string username = txtusername.Text;
            string password = txtpassword.Text;
            bool auth = login.login_auth(username, password);

            if (auth)
            {
                Dashboard dboard = new Dashboard();
                dboard.Closed += (s, arg) => this.Close();
                dboard.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Wrong Username or Password! Make sure your authentication values correct.", "Error in login!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

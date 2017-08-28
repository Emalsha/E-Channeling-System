using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoctorPanel
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Focus();
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text.Trim();
            string pword = txtPassword.Text.Trim();

            if (uname == "" || pword == "")
            {
                MessageBox.Show("Please enter Username and Password.");
            }
            else
            {
                DoctorController controller = new DoctorController();
                int num = controller.DoctorLogin(uname, pword);

                if (num == -2)
                {
                    MessageBox.Show("Exception ");
                }
                else if (num == 0)
                {
                    MessageBox.Show("Sorry, Wrong username and password.");
                }
                else
                {
                    this.Hide();
                    DoctorHome home = new DoctorHome(num);
                    home.Closed += (s, arg) => this.Close();
                    home.Show();
                }

            }

        }


       

        
    }
}

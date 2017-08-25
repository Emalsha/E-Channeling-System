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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        Timer timerStart = new Timer();

        private void start_Load(object sender, EventArgs e)
        {
            timerStart.Interval = 1500;
            timerStart.Tick += new EventHandler(OnTimer);
            timerStart.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            timerStart.Stop();
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Closed += (s, arg) => this.Close();
            loginForm.Show();
            
        }

    }
}

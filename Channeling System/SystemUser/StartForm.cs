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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Step = 10;
            timer1.Start();  // start the timer

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep(); // or progressBar1.Value++;
            if (progressBar1.Value == 100)  // check with the value
            {
                new Login().Show();
                timer1.Stop();
                this.Hide();
            }
        }

        
    }
}

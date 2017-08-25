using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SystemUser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Dashboard());
=======
            Application.Run(new StartForm());
>>>>>>> parent of 4ee73b6... login form competed
        }
    }
}

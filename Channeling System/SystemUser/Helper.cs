using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SystemUser
{
    public class Helper
    {
        public static string con_string(string name) 
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

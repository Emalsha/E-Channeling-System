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


        //Emalsha
        public static string GetString()
        {
            return "Data Source=CMBTRNDB02/APP8SP2;Persist Security Info=True;User ID=ifsapp;Password=ifsapp;";
        }
    }
}

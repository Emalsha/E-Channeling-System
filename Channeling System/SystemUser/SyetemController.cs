using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;

namespace SystemUser
{
    public class SyetemController
    {
        string oracleDB = Helper.con_string("acma_db");
        OracleCommand cmd = new OracleCommand();


        public void login_auth(string username, string password)
        {
            OracleConnection connect = new OracleConnection(oracleDB);
            cmd.Connection = connect;
            connect.Open();
            
            cmd.CommandText = "acma_reception_login";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("logid", OracleDbType.Decimal, ParameterDirection.ReturnValue);
            cmd.Parameters.Add("user", OracleDbType.Varchar2, username, ParameterDirection.Input);
            cmd.Parameters.Add("pass", OracleDbType.Varchar2, password, ParameterDirection.Input);
            
            cmd.ExecuteNonQuery();
            try
            {     
                int response = int.Parse(cmd.Parameters["logid"].Value.ToString());
                if (response == 0 )
                {
                 MessageBox.Show("Wrong Username or Password! Make sure your authentication values correct.","Error in login!",MessageBoxButtons.OK,MessageBoxIcon.Error);       
                }
                else
                {
                    new Dashboard().Show();
                }
            }
           
            finally
            {
                connect.Dispose();
                Login log_o = new Login();
                log_o.Hide();
            }

        }

        public string SearchPatientByNIC(string nic)
        {
            OracleConnection connect = new OracleConnection(oracleDB);

            cmd.Connection = connect;
            connect.Open();
            cmd.CommandText = "acma_patient_search_by_nic";
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.Add("patientname", OracleDbType.Varchar2, ParameterDirection.ReturnValue);

            OracleParameter p_name = new OracleParameter();
            p_name.Size = 64;
            p_name.ParameterName = "patientname";
            p_name.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(p_name);

            cmd.Parameters.Add("user_no", OracleDbType.Varchar2,nic, ParameterDirection.Input);

            cmd.ExecuteNonQuery();

            string text = cmd.Parameters["patientname"].Value.ToString();

            return text;
            
        }

        public static addNewPatient(string fullname, string nic, string telephone, string address)
        {
        
        }

    }
}

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
    public class ClassLogin
    {
        public void login_auth(string username, string password)
        {
            string oracleDB = Helper.con_string("acma_db");
            OracleConnection connect = new OracleConnection(oracleDB);
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = connect;
            cmd.CommandText = "acma_reception_login";
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                connect.Open();
                cmd.Parameters.Add(new OracleParameter("user", username));
                cmd.Parameters.Add(new OracleParameter("pass", password));
                //cmd.Parameters.Add("return_value", OracleDbType.Int32, ParameterDirection.ReturnValue);
                //int result = Convert.ToInt32(cmd.Parameters["return_value"].Value);
                cmd.Parameters.Add("log_id", OracleDbType.RefCursor);

                cmd.Parameters["log_id"].Direction = ParameterDirection.ReturnValue;
                var log_id = Convert.ToString(cmd.Parameters["log_id"].Value);
                
                OracleDataReader oReader = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(log_id);

                
            }
            

            finally
            {
                connect.Clone();
            }

        }
    }
}

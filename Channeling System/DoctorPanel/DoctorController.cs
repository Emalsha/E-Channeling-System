using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DoctorPanel
{
    class DoctorController
    {
        public int DoctorLogin(string username, string password)
        {
            using (OracleConnection con = new OracleConnection(DBString.GetString()))
            {
                con.Open();
                string qry = "ACMA_DOCTOR_LOGIN";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("response", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                    cmd.Parameters.Add("username_", OracleDbType.Varchar2, username,ParameterDirection.Input);
                    cmd.Parameters.Add("password_", OracleDbType.Varchar2, password , ParameterDirection.Input);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        int res = int.Parse(cmd.Parameters["response"].Value.ToString());
                        if (res == 0 || res == -1 || res == -2)
                        {
                            return 0;
                        }
                        else
                        {
                            return res;
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        return -2;
                    }
                    
                }
            }
        }

    }
}

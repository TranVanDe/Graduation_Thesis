using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FootballManagement
{
    class DatabaseHandle
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IBAC4RM\TVD;Initial Catalog=FootBallManagement;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sqlAdap = new SqlDataAdapter();    

        //Check Account
        public bool CheckAccount(string username,string password)
        {
            DataTable dt = new DataTable();
            conn.Open();

            //Get data from Database
            string query = "select username,password from [User]";
            cmd.Connection = conn;
            cmd.CommandText = query;
            sqlAdap.SelectCommand = cmd;

            //Fill data to DataTable
            sqlAdap.Fill(dt);

            //Check username and password
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (username.Equals(dt.Rows[i][0].ToString()) && password.Equals(dt.Rows[i][1].ToString()))
                {
                    conn.Close();
                    return true;
                }
            }

            conn.Close();
            return false;
        }
    }
}

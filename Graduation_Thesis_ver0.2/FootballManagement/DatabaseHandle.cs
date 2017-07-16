using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FootballManagement
{
    class DatabaseHandle
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IBAC4RM\TVD;Initial Catalog=FootBallManagement;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sqlAdap = new SqlDataAdapter();

        #region Check Account
        public bool CheckAccount(string username, string password)
        {
            DataTable dt = new DataTable();
            conn.Open();

            //Get data from Database
            string query = "select username,password from account";
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
        #endregion

        #region Get data from Account table
        public void ShowAcount(ref ListView l)
        {
            conn.Open();
            DataTable dt = new DataTable();

            string query = "select * from Account";
            cmd.Connection = conn;
            cmd.CommandText = query;

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
            sqlAdapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] arr = new string[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[j] = dt.Rows[i][j].ToString();
                }
                ListViewItem items = new ListViewItem(arr);
                l.Items.Add(items);
            }

            conn.Close();
        }
        #endregion

        #region Delete data from Account table
        public void DeleteAllAcount()
        {

        }
        #endregion

        #region insert data in account table
        public void AddAccount(string user, string pass, string type)
        {
            conn.Open();
            string query = "insert account values ('" + user + "' ,'" + pass + "','" + type + "')";
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion
    }
}

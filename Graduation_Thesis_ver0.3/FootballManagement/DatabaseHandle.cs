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

        #region Check Username already exist
        public bool CheckUser(string user)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string query = "select username from Account";
            cmd.Connection = conn;
            cmd.CommandText = query;
            sqlAdap.SelectCommand = cmd;
            sqlAdap.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (user.Equals(dt.Rows[i][0]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckUserEdit(string id, string user)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string query = "select username from Account where id <> " + id;
            cmd.Connection = conn;
            cmd.CommandText = query;
            sqlAdap.SelectCommand = cmd;
            sqlAdap.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (user.Equals(dt.Rows[i][0]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Check login is user or manager
        public int CheckLogIn(string user, string pass)
        {
            conn.Open();
            DataTable dt = new DataTable();

            string query = "select username,[password],[type] from Account";
            cmd.Connection = conn;
            cmd.CommandText = query;
            sqlAdap.SelectCommand = cmd;
            sqlAdap.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                //user return 0, manager return 1
                if (user.Equals(dt.Rows[i][0].ToString()) && pass.Equals(dt.Rows[i][1].ToString()))
                {
                    string s = dt.Rows[i][2].ToString().Trim();

                    if (s.Equals("Manager"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;

                    }
                }
            }

            //Not user or manager return -1
            return -1;
        }
        #endregion

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

        #region Show all Account
        public DataTable ShowAllAcount()
        {
            conn.Open();
            DataTable dt = new DataTable();

            string query = "EXEC usp_ShowAllAcount";
            cmd.Connection = conn;
            cmd.CommandText = query;

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
            sqlAdapter.Fill(dt);
            conn.Close();
            return dt;
        }
        #endregion

        #region Delete Account
        public void DeleteAcount(string id)
        {
            conn.Open();

            string query = "EXEC dbo.usp_DeleteAccount " + id;
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region Add Account
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

        #region Edit Account
        public void EditAccount(string id, string user, string pass, string type)
        {
            conn.Open();

            string query = "EXEC usp_UpdateAccount " + id + ",'" + user + "','" + pass + "','" + type + "'";

            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        #endregion

        #region Encrypt Password
        public static string EncryptPassword(string s)
        {
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballManagement
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        DatabaseHandle dh = new DatabaseHandle();

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            //blank in Username
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Blank username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
            else
            {
                //Blank in Password
                string pass = txtPass.Text;
                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Blank password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                }
                //Not blank
                else
                {
                    //Is a User
                    if (dh.CheckAccount(user, pass))
                    {
                        //Show Management Form
                        frmMain frmMain = new frmMain();
                        this.Hide();
                        frmMain.ShowDialog();
                        this.Close();
                    }
                    //Not a User
                    else
                    {
                        MessageBox.Show("Fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUser.ResetText();
                        txtPass.ResetText();
                        txtUser.Focus();
                    }
                }
            }

        }
    }
}

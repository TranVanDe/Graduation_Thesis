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

        #region Click Log In
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
                    //Is Mangager
                    if(dh.CheckLogIn(user,pass) == 1)
                    {
                        frmMain frmMain = new frmMain();
                        frmMain.ShowDialog();
                        this.Close();
                    }
                    //Is User
                    else if(dh.CheckLogIn(user,pass) == 0)
                    {
                        frmMain frmMain = new frmMain();
                        frmMain.manager = false;
                        frmMain.ShowDialog();
                        this.Close();
                    }
                    //Not User or Manager
                    else
                    {
                        MessageBox.Show("Invalid Field !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUser.Clear();
                        txtUser.Focus();
                        txtPass.Clear();
                    }
                }
            }
        }
        #endregion

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = chkPass.Checked ? false : true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog();
        }
    }
}


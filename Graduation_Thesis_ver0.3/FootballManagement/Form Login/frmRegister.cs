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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        DatabaseHandle dh = new DatabaseHandle();
        private void btnOK_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            //User is empty
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Username Empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }

            //User already exist
            else if (dh.CheckUser(user))
            {
                MessageBox.Show("Username already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Clear();
                txtUser.Focus();
                txtReType.Clear();
                txtPass.Clear();
            }

            //User is valid
            else
            {
                string pass = txtPass.Text;

                //Password is empty
                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Password Empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                }

                //Password not enough 8 character
                else if (pass.Length < 8)
                {
                    MessageBox.Show("Password at least 8 character!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtReType.Clear();
                    txtPass.Focus();
                }

                //Password wrong
                else if (!pass.Equals(txtReType.Text))
                {
                    MessageBox.Show("Wrong password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtReType.Clear();
                    txtPass.Focus();
                }

                //User and Pass valid
                else
                {
                    string type = cbType.Text;
                    DialogResult dialog = MessageBox.Show("Are you sure ?", "Inform", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        dh.AddAccount(user, pass, type);
                        MessageBox.Show("Sucessfull!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                }
            }
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = chkPass.Checked ? false : true;
            this.txtReType.UseSystemPasswordChar = chkPass.Checked ? false : true;
        }
    }
}

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
    public partial class frmUserEdit : Form
    {
        public frmUserEdit()
        {
            InitializeComponent();
        }

        DatabaseHandle dh = new DatabaseHandle();
        public string id = string.Empty;
        public string user = string.Empty;
        public string pass = string.Empty;
        public string type = string.Empty;

        #region Load edit form
        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            txtUser.Text = user;
            txtPass.Text = pass;
            cbType.Text = type;
            txtReType.Text = pass;
        }
        #endregion

        #region Check show password checkbox
        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = chkPass.Checked ? false : true;
            this.txtReType.UseSystemPasswordChar = chkPass.Checked ? false : true;
        }
        #endregion

        #region Click edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            user = txtUser.Text;

            //User is empty
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Username Empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }

            //User is already exist
            else if (dh.CheckUserEdit(id,user))
            {
                MessageBox.Show("Username already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }

            //User is valid
            else
            {
                pass = txtPass.Text;
                
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
                    txtPass.Focus();
                }

                //Password wrong
                else if (!pass.Equals(txtReType.Text))
                {
                    MessageBox.Show("Wrong password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtPass.Focus();
                    txtReType.Clear();
                }

                //User and Pass valid
                else
                {
                    type = cbType.Text;
                    DialogResult dialog = MessageBox.Show("Are you sure ?", "Inform", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        dh.EditAccount(id, user, pass, type);
                        MessageBox.Show("Sucessfull!", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Close();
                    }
                }
            }
        }
        #endregion
    }
}

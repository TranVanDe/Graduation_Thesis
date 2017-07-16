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
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }
        DatabaseHandle dh = new DatabaseHandle();

        #region when check show password
        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPass.UseSystemPasswordChar = chkPass.Checked ? false : true;
        }
        #endregion

        #region click Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Username Empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Focus();
            }
            else
            {
                string pass = txtPass.Text;
                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Password Empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                }
                else
                {
                    string type = cbType.Text;
                    dh.AddAccount(user, pass, type);
                    MessageBox.Show("Sucessfull !", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        #endregion
    }
}

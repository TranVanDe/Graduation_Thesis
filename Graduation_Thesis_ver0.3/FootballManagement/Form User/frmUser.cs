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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        DatabaseHandle dh = new DatabaseHandle();

        #region Load form User
        private void frmUser_Load(object sender, EventArgs e)
        {
            dgvUser.DataSource = dh.ShowAllAcount();
        }
        #endregion

        #region Click Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserAdd frm = new frmUserAdd();
            frm.ShowDialog();
        }
        #endregion

        #region Click Refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvUser.DataSource = dh.ShowAllAcount();
        }

        #endregion

        #region Click Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //row selected
            if (dgvUser.SelectedRows.Count == 1)
            {
                for (int i = 0; i < dgvUser.Rows.Count - 1; i++)
                {
                    //Choose row in datagridview
                    if (dgvUser.Rows[i].Selected)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure !", "Inform", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dialog == DialogResult.Yes)
                        {
                            string id = dgvUser.Rows[i].Cells[0].Value.ToString();
                            dh.DeleteAcount(id);
                            dgvUser.DataSource = dh.ShowAllAcount();
                        }
                        break;
                    }
                }
            }
            //not row selected
            else
            {
                MessageBox.Show("Please choose Account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Click Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 1)
            {
                for (int i = 0; i < dgvUser.Rows.Count - 1; i++)
                {
                    //Choose row in datagridview 
                    if (dgvUser.Rows[i].Selected)
                    {
                        frmUserEdit frmUserEdit = new frmUserEdit();
                        frmUserEdit.id = dgvUser.Rows[i].Cells[0].Value.ToString();
                        frmUserEdit.user = dgvUser.Rows[i].Cells[1].Value.ToString(); 
                        frmUserEdit.pass = dgvUser.Rows[i].Cells[2].Value.ToString(); 
                        frmUserEdit.type = dgvUser.Rows[i].Cells[3].Value.ToString();
                        frmUserEdit.ShowDialog();
                        break;
                    }
                }
            }
            //Not yet choose row
            else
            {
                MessageBox.Show("Please select a row !", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion
    }
}

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
            dh.ShowAcount(ref lvwUser);
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
            DeleteListview(ref lvwUser);
            dh.ShowAcount(ref lvwUser);
        }
        #endregion

        public static void DeleteListview(ref ListView l)
        {
            for (int i = 0; i < l.Items.Count; i++)
            {
                l.Items[i].Remove();
            }
        }
    }
}

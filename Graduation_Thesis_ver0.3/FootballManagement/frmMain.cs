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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public bool manager = true;

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            frmUser.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if(manager == false)
            {
                this.btnUser.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLogIn frmLogIn = new frmLogIn();
            this.Hide();
            frmLogIn.ShowDialog();
            this.Close();
        }

        private void btnUser_MouseMove(object sender, MouseEventArgs e)
        {
            lblUser.ForeColor = Color.Aqua;
        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            lblUser.ForeColor = Color.White;
        }

        private void btnPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            lblPlayer.ForeColor = Color.Aqua;
        }

        private void btnPlayer_MouseLeave(object sender, EventArgs e)
        {
            lblPlayer.ForeColor = Color.White;
        }

        private void btnTeam_MouseMove(object sender, MouseEventArgs e)
        {
            lblTeam.ForeColor = Color.Aqua;
        }

        private void btnTeam_MouseLeave(object sender, EventArgs e)
        {
            lblTeam.ForeColor = Color.White;
        }

        private void btnChampion_MouseMove(object sender, MouseEventArgs e)
        {
            lblChampion.ForeColor = Color.Aqua;
        }

        private void btnChampion_MouseLeave(object sender, EventArgs e)
        {
            lblChampion.ForeColor = Color.White;
        }

        private void btnSchedule_MouseMove(object sender, MouseEventArgs e)
        {
            lblSchedule.ForeColor = Color.Aqua;
        }

        private void btnSchedule_MouseLeave(object sender, EventArgs e)
        {
            lblSchedule.ForeColor = Color.White;
        }

        private void btnSearch_MouseMove(object sender, MouseEventArgs e)
        {
            lblSearch.ForeColor = Color.Aqua;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.White;
        }

        private void btnStatistic_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatistic.ForeColor = Color.Aqua;
        }

        private void btnStatistic_MouseLeave(object sender, EventArgs e)
        {
            lblStatistic.ForeColor = Color.White;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            lblExit.ForeColor = Color.Aqua;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.White;
        }
    }
}

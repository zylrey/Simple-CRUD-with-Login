using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PST
{
    public partial class frmLogin : Form
    {
        SQLConfig config = new SQLConfig();
        string sql;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbl_pst WHERE username = '"+ txtUsername.Text +"' and password = '"+ txtPassword.Text +"'";
            config.singleResult(sql);
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("You must fill up all the textbox.");
            }
            if(config.dt.Rows.Count > 0)
            {
                MessageBox.Show("Successfully LOGIN!");
                this.Hide();
                new frmDashboard().Show();
            }
            else
            {
                MessageBox.Show("Unknown User Data.");            
            }
        }
    }
}

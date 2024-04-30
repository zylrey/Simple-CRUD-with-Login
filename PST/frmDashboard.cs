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
    public partial class frmDashboard : Form
    {
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            sql = "SELECT id as 'ID', username as 'USERNAME', password as 'PASSWORD' FROM tbl_pst";
            config.Load_DTG(sql, dataGridView1);
            funct.ResponsiveDtg(dataGridView1);
        }

        public void clear()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Fill up all textbox.");
            }
            else
            {
                sql = "INSERT INTO tbl_pst(id,username,password) VALUES ('"+ txtID.Text +"', '"+ txtUsername.Text +"', '"+ txtPassword.Text +"')";
                config.singleResult(sql);
                refresh();
                clear();
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbl_pst WHERE id = '"+ dataGridView1.CurrentRow.Cells[0].Value +"'";
            config.singleResult(sql);
            if (config.dt.Rows.Count > 0)
            {
                txtID.Text = config.dt.Rows[0].Field<int>("id").ToString();
                txtUsername.Text = config.dt.Rows[0].Field<string>("username").ToString();
                txtPassword.Text = config.dt.Rows[0].Field<string>("password").ToString();
            }
            else
            {
                clear();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Fill up all textbox.");
            }
            else
            {
                sql = "UPDATE tbl_pst SET id ='" + txtID.Text + "',username ='" + txtUsername.Text + "',password='" + txtPassword.Text + "' WHERE id = '"+ txtID.Text +"'";
                config.singleResult(sql);
                refresh();
                clear();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you fucking sure of this?","CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dg == DialogResult.Yes)
            {
                sql = "DELETE FROM tbl_pst WHERE id = '"+ dataGridView1.CurrentRow.Cells[0].Value +"'";
                config.Load_DTG(sql, dataGridView1);
                MessageBox.Show("User has been REMOVE!!!!!");

                refresh();
            }
            else if (dg == DialogResult.No)
            {
                refresh();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}

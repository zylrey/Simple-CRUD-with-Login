using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace PST
{
    class SQLConfig
    {
        private SqlConnection con = new SqlConnection(@"Data Source=ZYL\SQLEXPRESS;Initial Catalog=pst_db;Integrated Security = True");
        private SqlCommand cmd;
        private SqlDataAdapter da;
        public DataTable dt;
        usableFunction funct = new usableFunction();

        public void Load_DTG(string sql, DataGridView dtg)
        {
            try
            {
                //con.Open();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();


                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
                dtg.DataSource = dt;


                funct.ResponsiveDtg(dtg);
                //dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                da.Dispose();
                con.Close();
            }

        }

        public void singleResult(string sql)

        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();


                cmd.Connection = con;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                da.Dispose();
                con.Close();
            }
        }
    }
}

using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        SalesDb db;
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet set = null;

        public Form1()
        {
            InitializeComponent();
            //string connectionString = ConfigurationManager.ConnectionStrings["SalesDbConnectionString"].ConnectionString;
            //db = new SalesDb(connectionString);
            string cs = ConfigurationManager.ConnectionStrings["SalesDbConnectionString"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        private void load_sales_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetAll();
        }

        private void fill_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = textBox1.Text;
                da = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);

                set = new DataSet();
                da.Fill(set, "MyTable");                            
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = set.Tables["MyTable"];  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(set, "MyTable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            int rowIdx = dataGridView1.CurrentCell.RowIndex;
            DataRowView drv = (DataRowView)dataGridView1.Rows[rowIdx].DataBoundItem;
            DataRow dr = drv.Row;
            dr.Delete();
        }

    }
}
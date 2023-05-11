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

namespace DisconnectedMode
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet set = null;
        public Form1()
        {
            InitializeComponent();
            string cs = ConfigurationManager.ConnectionStrings["SportShopDb"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = textBox1.Text;
                da = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);

                set = new DataSet(); 
                da.Fill(set, "MyTable");                            // da.Fill(set);
                dataGridView1.DataSource = null; dataGridView1.DataSource = set.Tables["MyTable"];   // dataGridView1.DataSource = set.Tables[0];            }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}

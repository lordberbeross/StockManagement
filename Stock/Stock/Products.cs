using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Products : Form
    {
        public Products()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                SqlConnection con = Connections.GetConnection();
                con.Open();
                bool status = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                var sqlQuery = "";
                if (ifRecordExists(con, textBox1.Text))
                {
                    sqlQuery = @"UPDATE [dbo].[Products] SET [ProductClass] = '" + textBox2.Text + "' , [ProductName] = '" + textBox3.Text + "' ,[ProductPrice] = '" + textBox4.Text + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [dbo].[Products] ([ProductCode],[ProductClass],[ProductName],[ProductPrice],[ProductStatus]) VALUES 
                        ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + status + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //reader

                loadData();
                reset();
            }
           
        }
        public void loadData()
        {
            SqlConnection con = Connections.GetConnection();
    
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
  FROM[dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductClass"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["ProductPrice"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[4].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[4].Value = "Inactive";
                }
                

            }
        } 
        private bool ifRecordExists(SqlConnection sql,string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 from [dbo].[Products] where [ProductCode]='"+productCode+"'", sql);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            if (tb.Rows.Count>0)
            {
                return true;
            }
            else
            {

                return false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connections.GetConnection();


            if (ifRecordExists(con,textBox1.Text))
            {
                con.Open();
                var query = "DELETE FROM [dbo].[Products] WHERE [ProductCode] ='" + dataGridView1.SelectedRows[0].Cells[0].Value + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                MessageBox.Show("Record Doesn't Exist!");
            }
            loadData();
            reset();
        }
        

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString()=="Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            
        }
           private void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            button2.Text = "Add";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();
        }
        private bool validation()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && (comboBox1.SelectedIndex>-1))
            {
                result = true;
            }
            return result;
        }
    }

}

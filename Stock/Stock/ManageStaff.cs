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
    public partial class ManageStaff : Form
    {
        public ManageStaff()
        {
            InitializeComponent();
        }

        private void ManageStaff_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadData();
        }
        public void loadData()
        {
            SqlConnection con = Connections.GetConnection();

            SqlDataAdapter asd = new SqlDataAdapter(@"SELECT *
  FROM[dbo].[login]", con);
            DataTable dt = new DataTable();
            asd.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["UserName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Password"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Type"].ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                SqlConnection con = Connections.GetConnection();
                con.Open();
                
                var sqlQuery = "";
                if (ifRecordExists(con, textBox1.Text))
                {
                    sqlQuery = @"UPDATE [dbo].[login] SET [UserName] = '" + textBox1.Text + "' , [Password] = '" + textBox2.Text + "' ,[Type] = '" + comboBox1.Text + "'  WHERE [UserName] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [dbo].[login] ([UserName],[Password],[Type]) VALUES 
                        ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
                }
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //reader

                loadData();
                reset();
            }
        }
        private bool ifRecordExists(SqlConnection sql, string userName)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 from [dbo].[login] where [UserName]='" + userName + "'", sql);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
            {

                return false;

            }
        }
      
        private void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            button1.Text = "Add";
            textBox1.Focus();
        }
        private bool validation()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && (comboBox1.SelectedIndex > -1))
            {
                result = true;
            }
            return result;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connections.GetConnection();


            if (ifRecordExists(con, textBox1.Text))
            {
                con.Open();
                var query = "DELETE FROM [dbo].[login] WHERE [UserName] ='" + dataGridView1.SelectedRows[0].Cells[0].Value + "' ";
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

        private void Button3_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}

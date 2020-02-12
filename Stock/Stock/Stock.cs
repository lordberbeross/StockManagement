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
    
    public partial class Stock : Form
    {
        
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            comboBox1.SelectedIndex = 0;
            loadData();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (textBox1.TextLength>0)
                {
                    textBox2.Focus();
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.TextLength > 0)
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.TextLength > 0)
                {
                    comboBox1.Focus();
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedIndex!=-1)
                {
                    button1.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar !=Keys.Back && e.KeyChar!= '.')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void ResetRecord()
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            button1.Text = "Ekle";
            dateTimePicker1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetRecord();
        }
        private bool validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Product Name Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Miktar Required");
            }
          
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Status Required");
            }
            else
            {
                result = true;
            }


            return result;
        }
        private bool ifRecordExists(SqlConnection sql, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 from [dbo].[Stock] where [ProductCode]='" + productCode + "'", sql);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                SqlConnection con = Connections.GetConnection();
                con.Open();
                bool status = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    status = true;

                }else
                {
                    status = false;
                }
                var query = "";
                if (ifRecordExists(con,textBox1.Text))
                {
                    query = @"UPDATE [Stock] SET [ProductName] ='" + textBox2.Text + "' ,[TransDate]= '" + dateTimePicker1.Value + "', [Quantity]= '" + textBox3.Text + "', [ProductStatus]='" + status + "' WHERE [ProductCode]='"+textBox1.Text+"'";
                }
                else
                {
                    query = @"INSERT INTO Stock (ProductCode,ProductName,TransDate,Quantity,ProductStatus) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox3.Text + "','" + status + "')";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla Kaydedildi");
                ResetRecord();
                loadData(); 
            }
        }
        public void loadData()
        {
            SqlConnection con = Connections.GetConnection();

            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
  FROM[dbo].[Stock]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Quantity"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["TransDate"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[0].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[0].Value = "Inactive";
                }


            }
        }
    }
}

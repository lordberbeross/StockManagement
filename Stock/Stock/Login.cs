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
    
    public partial class Login : Form
    {
        public string cyka;
        public Login()
        {
            InitializeComponent();
            
            
        }
        public string UserName // on LoginForm
        {
           
            get;
            set;
        
    }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check username and password
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM[Stock].[dbo].[login] WHERE UserName = '"+textBox1.Text+"' and Password = '"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            cyka = textBox1.Text;
            UserName = textBox1.Text;
            sda.Fill(dt);
            if (dt.Rows.Count ==1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("invalid username or password..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }
    }
}

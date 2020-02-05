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
    public partial class Adisyon : Form
    {
        public Adisyon()
        {
            InitializeComponent();
        }
        private void Adisyon_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Price", 150);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            SqlConnection cn = Connections.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Connection.Open();
            cmd.CommandText = "SELECT * FROM [dbo].[Products]";
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> str = new List<string>();
            List<string> str2 = new List<string>();
            List<string> str3 = new List<string>();
        var a = dr;
            while (dr.Read())
            {
                str.Add(dr["ProductClass"].ToString());
                str2.Add(dr["ProductClass"].ToString());
                str2.Add(dr["ProductName"].ToString());
                str2.Add(dr["ProductPrice"].ToString());
            }
            cmd.Connection.Close();
            foreach (string p in str.Distinct())
            {
                Button l = new Button
                {
                    Text = p.ToString(),
                    ForeColor = Color.White,
                    BackColor = Color.Orange,
                    Font = new Font("Serif", 24),
                    Width = 240,
                    Height = 80,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(5)
                };
                flowLayoutPanel1.Controls.Add(l);
                l.Click += new System.EventHandler(l_Click);
                void l_Click(object s, EventArgs ev)
                {
                    flowLayoutPanel2.Controls.Clear();
                    int i = 1;
                    while (i <= str2.Count)
                    {
                        if (l.Text == str2[i - 1])
                        {
                            Button l2 = new Button
                            {
                                Text = str2[i].ToString(),
                                ForeColor = Color.White,
                                BackColor = Color.Green,
                                Font = new Font("Serif", 24),
                                Width = 240,
                                Height = 80,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Margin = new Padding(5),   
                            };
                            string am = str2[i + 1].ToString();
                            flowLayoutPanel2.Controls.Add(l2);                           
                            l2.Click += new System.EventHandler(l2_Click);
                            void l2_Click(object sender2, EventArgs e2)
                            {
                                string[] row = { l2.Text, am };
                                ListViewItem item = new ListViewItem(row);
                                listView1.Items.Add(item); 
                                var t = item.SubItems[1].ToString();
                                double valorSum = 0;

                                foreach (ListViewItem lstItem in listView1.Items)
                                {
                                    valorSum += double.Parse(lstItem.SubItems[1].Text);
                                }
                                Console.WriteLine(valorSum);
                                label2.Text = valorSum.ToString();
                            }      
                        }                    
                        i += 3;
                    };
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

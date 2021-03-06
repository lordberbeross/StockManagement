﻿using System;
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
        int asd;
        int firstValue = 0;
        Dictionary<string, int> production = new Dictionary<string, int>();
        ListViewItem item;
        bool isCash = false;
        bool isCredit = false;
        public string[] row= new string[3];
        public double valorSum;
        public Adisyon()
        {
            InitializeComponent();
        }
        public void Adisyon_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Price", 150);
            listView1.Columns.Add("Quantity", 150);
            listView1.View = View.Details;
            listView1.TabIndex = 0;
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
                production[(string)dr["ProductName"]] = (int)dr["ProductPrice"];
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
                                
                                asd = countinArray(listView1, l2.Text);

                                if (asd==1)
                                {
                                    row[0] = l2.Text;
                                    row[1] = am;
                                    row[2] = asd.ToString();
                                    item = new ListViewItem(row);

                                    listView1.Items.Add(item);
                                    var t = item.SubItems[1].ToString();
                                    //  valorSum = 0;
                                   
                                        valorSum += double.Parse(listView1.Items[listView1.Items.Count-1].SubItems[1].Text);
                                   


                                }
                                else
                                {
                                    for(int z = 0; z < listView1.Items.Count; z++)
                                    {
                                        if (listView1.Items[z].SubItems[0].Text==l2.Text)
                                        {
                                            firstValue = Convert.ToInt32(listView1.Items[z].SubItems[2].Text);
                                            listView1.Items[z].SubItems[2].Text = (firstValue + 1).ToString();
                                            listView1.Items[z].SubItems[1].Text = (Convert.ToInt32(listView1.Items[z].SubItems[2].Text) * ((production[listView1.Items[z].SubItems[0].Text]))).ToString() ;
                                            valorSum += double.Parse(production[listView1.Items[z].SubItems[0].Text].ToString());
                                        }
                                    }
                                }














                                /*    asd = countinArray(listView1, l2.Text);
                                    MessageBox.Show(asd.ToString());*/

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

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lstItem in listView1.Items)
            {
               if(lstItem.Selected)
                    {
                    lstItem.Remove();
                    valorSum -= double.Parse(lstItem.SubItems[1].Text);
                }
                label2.Text = valorSum.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int userId=0;
            SqlConnection con = Connections.GetConnection();
            con.Open();
            var query = "";
            if (isCash)
            {
                query = "INSERT INTO [dbo].[Sales] ([TotalPrice],[SalesDate],[SalesTime],[Cash],[Credit]) VALUES ('" + (decimal)valorSum + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + (decimal)valorSum + "','" + 0 + "')";
              
                query += "SET @SalesID= SCOPE_IDENTITY()";
                isCash = false;
                isCredit = false;
                SqlCommand sql = new SqlCommand(query, con);
                sql.Parameters.Add("@SalesID", SqlDbType.Int).Direction = ParameterDirection.Output;
                sql.ExecuteNonQuery();
                userId = Convert.ToInt32(sql.Parameters["@SalesID"].Value);
              
            }
            else
            if (isCredit)
            {
                query = "INSERT INTO [dbo].[Sales] ([TotalPrice],[SalesDate],[SalesTime],[Cash],[Credit]) VALUES ('" + (decimal)valorSum + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + 0 + "','" + (decimal)valorSum + "')";
                query += " set @id= SCOPE_IDENTITY()";
                isCash = false;
                isCredit = false;
                SqlCommand sql = new SqlCommand(query, con);
                sql.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                sql.ExecuteNonQuery();
                userId = Convert.ToInt32(sql.Parameters["id"].Value);
            }
            else
            {
                MessageBox.Show("Please select Cash or Credit"); 
            }
            foreach (ListViewItem lstItem in listView1.Items)
            {
               
                query = "INSERT INTO [dbo].[SalesDetails] ([SalesID],[ProductName],[ProductPrice],[Quantity]) VALUES ('"+userId+"','" + lstItem.SubItems[0].Text + "','" + double.Parse(lstItem.SubItems[1].Text) + "','" + Convert.ToInt32(lstItem.SubItems[2].Text) + "')";
                SqlCommand newSql = new SqlCommand(query, con);

                newSql.ExecuteNonQuery();
            }
            
            con.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            isCash = true;
            isCredit = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            isCredit = true;
            isCash = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //AdisyonOpt ao = new AdisyonOpt(this);
            //ao.SetBtn = listView1;
            //ao.Show(this);
            //this.Close();
            ListView form1LV = listView1;
            AdisyonOpt f = new AdisyonOpt(form1LV);
            f.Show();
        }
        private int countinArray(ListView lst, String item)
        {
            int counter = 1;
            if (lst.Items.Count>0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {

                    if (lst.Items[i].SubItems[0].Text == item)
                    {
                        counter++;
                            
                    }
                  
                    
                   

                }


            }
          

            return counter;

        }
       

    }
    }



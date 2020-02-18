using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class AdisyonOpt : Form
    {
        int count = 0;
        double result = 0;
        public string[] row = new string[3];
        public double valorSum2;
        public ListView xnxx2;

        public AdisyonOpt(object f1LV)
        {
            InitializeComponent();
            xnxx2 = (ListView)f1LV;        
        }
        private void AdisyonOpt_Load(object sender, EventArgs e)
        {
            xnxx.Columns.Add("Name", 150);
            xnxx.Columns.Add("Price", 150);
            xnxx.Columns.Add("Quantity", 150);
            xnxx.View = View.Details;
            xnxx.TabIndex = 0;
            xnxx.FullRowSelect = true;
            xnxx.MultiSelect = true;
            foreach (ListViewItem lstItem in xnxx2.Items)
            {
                row[0] = lstItem.SubItems[0].Text;
                row[1] = lstItem.SubItems[1].Text;
                row[2] = lstItem.SubItems[2].Text;
                ListViewItem item = new ListViewItem(row);
                xnxx.Items.Add(item);
                valorSum2 += Convert.ToDouble(lstItem.SubItems[1].Text);
            }
            var mod = valorSum2 % 10;
            if (mod <= 5 & mod !=0)
            {
                valorSum2 = valorSum2 + 5 - mod;
                button25.Text = valorSum2.ToString();
            }else
            if (mod != 0 & mod > 5){
                valorSum2 = valorSum2 + 10 - mod;
                button25.Text = valorSum2.ToString();
            } else
            {
                button25.Text = valorSum2.ToString();
            }       
        }
        private void enable()
        {
            if (textBox2.Text == "")
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void Xnxx_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem lstitem in xnxx.Items)
            {
                if (lstitem.Selected && lstitem.BackColor == Color.FromArgb(255, 232, 232))
                {
                   
                    count -= Convert.ToInt32(lstitem.SubItems[1].Text);
                    lstitem.BackColor = Color.FromArgb(255, 255, 255);
                }
              
               else if(lstitem.Selected)
                {
                    count += Convert.ToInt32(lstitem.SubItems[1].Text);
                    lstitem.BackColor = Color.FromArgb(255, 232, 232);
                }
                textBox1.Text = count.ToString();
               
            }
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lstitem in xnxx.Items)
            {
                lstitem.BackColor = Color.FromArgb(255, 255, 255);
            }
            count = 0;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox2.Text += "1";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox2.Text += "2";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox2.Text += "3";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox2.Text += "4";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox2.Text += "5";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "6";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox2.Text += "7";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox2.Text += "8";
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            textBox2.Text += "9";
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            textBox2.Text += ",";
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            textBox2.Text += "0";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                result = 1;
            }else
            {
                result = Convert.ToDouble(textBox2.Text) + 1;
            }

            textBox2.Text = result.ToString();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 5;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 5;
            }

            textBox2.Text = result.ToString();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 10;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 10;
            }

            textBox2.Text = result.ToString();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 20;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 20;
            }

            textBox2.Text = result.ToString();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 50;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 50;
            }

            textBox2.Text = result.ToString();
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 100;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 100;
            }

            textBox2.Text = result.ToString();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                result = 200;
            }
            else
            {
                result = Convert.ToDouble(textBox2.Text) + 200;
            }

            textBox2.Text = result.ToString();
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") return;
            double divide;
            divide = Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text);
            textBox2.Text = divide.ToString();
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = button25.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
        private int countinArray(ListViewItem lst ,String item)
        {
            int counter = 0;
            for (int i = 0; i < lst.SubItems.Count; i++)
            {
                if (lst.SubItems[i].Text==item)
                {
                    counter++;
                }
            }
            return counter;
        }

        private void xnxx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in xnxx.Items)
            {
                if (item.Selected)
                {
                    int val = Convert.ToInt32(item.SubItems[2].Text);
                    item.SubItems[2].Text = (val - 1).ToString();
                }
            }
        }
    }
}

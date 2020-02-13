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
        private Adisyon other;

        //public AdisyonOpt()
        //{
        //    InitializeComponent();
        //}
        public AdisyonOpt(object f1LV)
        {
            InitializeComponent();
            listView1 = (ListView)f1LV;        
        }

        //public AdisyonOpt(Adisyon other)
        //{
        //    this.other = other;
        //    InitializeComponent();
        //}
        //public ListView SetBtn
        //{
        //    get { return SetBtn; }
        //    set
        //    {
        //        xnxx.Controls.Add(value);
        //    }

        //}

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
    }
}

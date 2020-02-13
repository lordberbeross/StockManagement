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
    public partial class StockMain : Form
    {
        public string loggedUser;
        public StockMain()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == "Products")
                {
                    Isopen = true;
                }
            }
            if (Isopen == false)
            {
                Products pro = new Products();
                pro.MdiParent = this;
                pro.Show();
            }
  
        }
        bool close = true;
        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult dialogResult = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                    
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
           

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.MdiParent = this;
            stock.StartPosition = FormStartPosition.CenterScreen;
            stock.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            Login login = new Login();
            
            ana.MdiParent = this;  
            ana.Show();   
        }

        private void AccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Accounts")
                {
                    Isopen = true;
                }
            }
            if (Isopen == false)
            {
                Accounts staff = new Accounts();
                staff.MdiParent = this;
                staff.Show();
            }   
        }

        private void AdisyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Adisyon")
                {
                    Isopen = true;
                }
            }
            if (Isopen == false)
            {
                Adisyon ad = new Adisyon();
                ad.MdiParent = this;
                ad.Show();
         
            } 
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

      

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text= DateTime.Now.ToString("dd-MMM-yyyy, hh:mm:ss");
        }

        private void StockMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            MessageBox.Show(loggedUser);
        }
    }
}

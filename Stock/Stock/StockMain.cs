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
        public StockMain()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.MdiParent = this;
            pro.Show();
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            ManageStaff staff = new ManageStaff();
            staff.MdiParent = this;
            staff.Show();
        }
    }
}

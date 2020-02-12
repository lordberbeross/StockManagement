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

        public AdisyonOpt(Adisyon other)
        {
            this.other = other;
            InitializeComponent();
        }
    }
}

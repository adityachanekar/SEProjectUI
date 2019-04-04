using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUI
{
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //home
            panelLeft.Top = button1.Top;
            this.Hide();
            index f = new index();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {       //income
            panelLeft.Top = button2.Top;
            this.Hide();
            Income f = new Income();
            f.ShowDialog();
        }
    }
}

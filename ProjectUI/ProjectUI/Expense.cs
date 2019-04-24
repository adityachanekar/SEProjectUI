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
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {       //income
            panelLeft.Top = button2.Top;
            this.Hide();
            Income f = new Income();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void Expense_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

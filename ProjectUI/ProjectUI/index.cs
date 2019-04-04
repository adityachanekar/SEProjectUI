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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonHome.Height;
            panelLeft.Top = buttonHome.Top;
        }

        private void buttonIncome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Income f = new Income();
            f.ShowDialog();
            panelLeft.Top = buttonIncome.Top;

        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expense f = new Expense();
            f.ShowDialog();
            panelLeft.Top = buttonExpense.Top;

        }

        private void button7_Click(object sender, EventArgs e)
        { 
        this.Hide();
        Form1 f = new Form1();
        f.ShowDialog();

        }
    }
}

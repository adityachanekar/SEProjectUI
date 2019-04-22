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
    public partial class Financial_Report : Form
    {
        public Financial_Report()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            panelLeft.Visible = true;
            index f = new index();
            f.Show();
        }

        private void buttonIncome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Income f = new Income();
            f.Show();
            panelLeft.Visible = true;
            panelLeft.Top = buttonIncome.Top;
        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expense f = new Expense();
            f.Show();
            panelLeft.Visible = true;
            panelLeft.Top = buttonExpense.Top;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}

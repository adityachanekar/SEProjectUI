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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelLeft.Top = buttonHome.Top;
            this.Hide();
            index f = new index();
            f.ShowDialog();
        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            panelLeft.Top = buttonExpense.Top;
            this.Hide();
            Expense f = new Expense();
            f.ShowDialog();
        }
    }
}

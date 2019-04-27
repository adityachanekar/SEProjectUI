using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;


namespace ProjectUI
{
    public partial class Financial_Report : Form
    {
        public int userid;
        public Financial_Report()
        {
            InitializeComponent();
            userid = Form1.userid;
            
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

        private void buttonFinRep_Click(object sender, EventArgs e)
        {
            //VARIABLE 
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Today.Date;
            var fromdate = dateTimePicker1;
            var todate = dateTimePicker2;

            MessageBox.Show(today.ToString());
            //Validation if fromdate is more than to date and to date is less than or equal to today
            if (fromdate.Value > todate.Value  )
            {
                MessageBox.Show("From Date cannot be after To Date!", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (todate.Value > today.Value && fromdate.Value > today.Value)
            {
                MessageBox.Show("Entered Date cannot be after Today!", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "yyyy-MM-dd";
                fromdate = dateTimePicker1;
                todate = dateTimePicker2;
                OracleConnection con = new OracleConnection(Form1.connectionString);

                string sql = "SELECT INCOMEDATE \"Date\", INCOMEPARTICULAR \"Particulars\", INCOMEAMOUNT \"Credit\", null \"Debit\" " +
                    "FROM INCOME WHERE USERID = " + userid + " AND INCOMEDATE >= DATE'" + fromdate.ToString() + "' AND INCOMEDATE <= DATE'" + todate.ToString() + "'" +
                    "UNION " +
                    "SELECT EXPENSEDATE, EXPENSEPARTICULAR , NULL, EXPENSEAMOUNT" +
                    "FROM EXPENSE WHERE USERID = " + userid + " AND EXPENSEDATE >= DATE'" + fromdate.ToString() + "' AND EXPENSEDATE <= DATE'" + todate.ToString() + "'";
            }
        }
    }
}

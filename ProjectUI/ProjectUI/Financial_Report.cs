using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OracleClient;
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
            index.income_expense_calc();
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
                //PASSING NEW DATES WITH ORACLE DATE FORMAT
                DateTimePicker dt1, dt2;
                dt1 = new DateTimePicker();
                dt2 = new DateTimePicker();
                dt1.Value = dateTimePicker1.Value;
                dt2.Value = dateTimePicker2.Value;
                dt1.Format = DateTimePickerFormat.Custom;
                dt1.CustomFormat = "yyyy-MM-dd";
                dt2.Format = DateTimePickerFormat.Custom;
                dt2.CustomFormat = "yyyy-MM-dd";

                string fromDate = dt1.Value.Date.ToString("yyyy-MM-dd");
                string toDate = dt2.Value.Date.ToString("yyyy-MM-dd");
                //MessageBox.Show(fromDate + "\n" + toDate);

                //Connecting to DB
                OracleConnection con = new OracleConnection(Form1.connectionString);

                string sql = "SELECT INCOMEDATE \"Date\", INCOMEPARTICULAR \"Particulars\", INCOMEAMOUNT \"Credit\", null \"Debit\" " +
                    "FROM INCOME WHERE USERID = " + userid + " " +
                    "AND INCOMEDATE >= DATE'" + fromDate + "' AND INCOMEDATE <= DATE'" + toDate + "' " +
                    "UNION " +
                    "SELECT EXPENSEDATE, EXPENSEPARTICULAR , NULL, EXPENSEAMOUNT \"Amount\" " +
                    "FROM EXPENSE WHERE USERID = " + userid + " " +
                    "AND EXPENSEDATE >= DATE'" + fromDate + "' AND EXPENSEDATE <= DATE'" + toDate + "'";
                string sql2 = "SELECT INCOMEDATE \"Date\", INCOMEPARTICULAR \"Particulars\", INCOMEAMOUNT \"Credit\", null \"Debit\" FROM INCOME WHERE USERID = 1 AND INCOMEDATE >= DATE'2019-04-01' AND INCOMEDATE <= DATE'2019-04-27' UNION SELECT EXPENSEDATE, EXPENSEPARTICULAR , NULL, EXPENSEAMOUNT \"Amount\" FROM EXPENSE WHERE USERID = 1 AND EXPENSEDATE >= DATE'2019-04-01' AND EXPENSEDATE <= DATE'2019-04-27'";
                try
                {
                    con.Open();
                    OracleDataAdapter adt = new OracleDataAdapter(sql, con);
                    DataTable dataTable = new DataTable();

                    adt.Fill(dataTable);

                    if(dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No Entries in the given range", "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    con.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Try Again");
                    
                }



                
            }
        }
    }
}

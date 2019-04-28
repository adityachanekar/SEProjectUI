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
    public partial class index : Form
    {
        public static int userid;
        public static double MonthlyExpense=0, MonthlyIncome=0,SpendingLimit=0;
        public static string connectionString;
        
        public index()
        {
            InitializeComponent();
            userid = Form1.userid;
            connectionString = Form1.connectionString;

            string sql = "SELECT FNAME,LNAME FROM DETAIL WHERE USERID=" + userid + "";

            OracleConnection con = new OracleConnection(connectionString);
            con.Open();
            OracleDataAdapter adt = new OracleDataAdapter(sql, con);
            DataTable dt = new DataTable();

            adt.Fill(dt);
            string fname = dt.Rows[0][0].ToString(), lname = dt.Rows[0][1].ToString();
            label2.Text = fname + " " + lname;
            con.Close();



            string month = DateTime.Today.ToString("MMMM-yyyy");
            label6.Text = month;
            income_expense_calc();
            label7.Text = "Rs "+MonthlyIncome.ToString();
            label8.Text = "Rs "+MonthlyExpense.ToString();
            label9.Text = "Rs "+SpendingLimit.ToString();
            if (SpendingLimit < 0)
            {
                MessageBox.Show("You are in Debt.\nKindly manage funds properly","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        

        }
        public static void income_expense_calc()
        {
            double mIncome=0, mExpense=0;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string thismonth = DateTime.Today.ToString("yyyy-MM");
            string sql1 = "SELECT INCOMEAMOUNT FROM INCOME WHERE USERID = "+index.userid+"" +
                "AND INCOMEDATE >= DATE'"+thismonth+"-01' AND INCOMEDATE <= DATE'"+today+"'";
            string sql2 = "SELECT EXPENSEAMOUNT FROM EXPENSE WHERE USERID = " + index.userid + "" +
                "AND EXPENSEDATE >= DATE'" + thismonth + "-01' AND EXPENSEDATE <= DATE'" + today + "'";

            OracleConnection con = new OracleConnection(index.connectionString);
            con.Open();
            OracleDataAdapter adt1, adt2;
            DataTable table1, table2;

            adt1 = new OracleDataAdapter(sql1, con);
            table1 = new DataTable();
            adt1.Fill(table1);
            adt2 = new OracleDataAdapter(sql2, con);
            table2 = new DataTable();
            adt2.Fill(table2);

            //Calculates Sum of Expense and Income for the present month
            if (table1.Rows.Count !=0)
            {
                for (int i = 0; i < table1.Rows.Count; i++)
                    mIncome += double.Parse(table1.Rows[i][0].ToString());
            }

            if (table2.Rows.Count != 0)
            {
                for (int i = 0; i < table2.Rows.Count; i++)
                    mExpense += double.Parse(table2.Rows[i][0].ToString());
            }
            if(mIncome!=index.MonthlyIncome || mExpense != index.MonthlyExpense)
            {
                index.MonthlyExpense = mExpense;
                index.MonthlyIncome = mIncome;
            }
            index.SpendingLimit = index.MonthlyIncome - index.MonthlyExpense;

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
            f.Show();
            panelLeft.Top = buttonIncome.Top;

        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expense f = new Expense();
            f.Show();
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
            this.Hide();
            Financial_Report f = new Financial_Report();
            panelLeft.Visible = false;
            f.Show();
        }

        private void index_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

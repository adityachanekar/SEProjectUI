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
        public int userid;
        public string connectionString;
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

            string month = DateTime.Today.ToString("MMMM");
            label6.Text = month;



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

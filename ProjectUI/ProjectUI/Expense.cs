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
    public partial class Expense : Form
    {
        public int userid;
        public string connectionString;
        public Expense()
        {
            InitializeComponent();
            userid = Form1.userid;
            connectionString = Form1.connectionString;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
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
            //define variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;

            //oracle connection
            OracleConnection con = new OracleConnection(connectionString);

            //CHECK NO. OF ENTRIES
            OracleDataAdapter no_of_entries
               = new OracleDataAdapter("SELECT * FROM EXPENSE", con);
            DataTable detail_count = new DataTable();
            no_of_entries.Fill(detail_count);
            int expenseidmax = detail_count.Rows.Count;
            if (expenseidmax != 0)
            {
                expenseidmax = int.Parse(detail_count.Rows[0][0].ToString());
            }
            expenseidmax++;
            con.Close();





            string sql = "INSERT INTO EXPENSE(EXPENSEID,EXPENSEPARTICULAR,EXPENSEAMOUNT,EXPENSEDATE,USERID) " +
                "VALUES("+expenseidmax+",'"+particular+"',"+amount+",DATE'"+date+"',"+userid+")";
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Expense of \n"+textBox1.Text + " : " + textBox2.Text + " Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
                throw;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //define variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;

            //oracle connection
            OracleConnection con = new OracleConnection(connectionString);

            string sql1 = "SELECT * FROM EXPENSE WHERE USERID=" + userid + "" +
                " AND EXPENSEPARTICULAR = '" + particular + "' AND EXPENSEDATE = DATE'" + date + "'";


            string Sql(int expenseId)
            {
                return "UPDATE EXPENSE SET EXPENSEAMOUNT = " + amount + " WHERE EXPENSEID = "+expenseId+"";
            }

            //check if entry exists
            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(sql1, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            try
            {
                if (dataTable.Rows.Count == 1)
                {
                    int expenseId = int.Parse(dataTable.Rows[0][0].ToString());
                    DialogResult result = MessageBox.Show("Do you want to edit Expense Amount?", "Yes?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        con.Open();
                        OracleCommand cmd = new OracleCommand(Sql(expenseId), con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                        MessageBox.Show(particular + " : " + amount + " was updated");
                    }
                    else
                    {
                        MessageBox.Show("Amount not updated");
                    }
                }
                else
                {
                    MessageBox.Show("Entry does not exist");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
                throw;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //define variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;

            //oracle connection
            OracleConnection con = new OracleConnection(connectionString);

            string sql1 = "SELECT EXPENSEID FROM EXPENSE WHERE USERID=" + userid + "" +
                " AND EXPENSEPARTICULAR = '" + particular + "' AND EXPENSEDATE = DATE'" + date + "'" +
                " AND EXPENSEAMOUNT = "+amount+"";

            string Sql(int expenseId)
            {
                return "DELETE FROM EXPENSE WHERE EXPENSEID = " + expenseId + "";
            }

            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(sql1, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();

            try
            {
                if (dataTable.Rows.Count == 1)
                {
                    int expenseId = int.Parse(dataTable.Rows[0][0].ToString());
                    DialogResult result = MessageBox.Show("Do you want to delete the entry?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        con.Open();
                        OracleCommand cmd = new OracleCommand(Sql(expenseId), con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                        MessageBox.Show("" + particular + " deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Entry not deleted");
                    }
                }
                else
                {
                    MessageBox.Show("Entry does not exist");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
                throw;
            }
        }
    }
}

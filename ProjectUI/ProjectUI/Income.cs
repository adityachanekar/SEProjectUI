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
using System.Text.RegularExpressions;

namespace ProjectUI
{
    public partial class Income : Form
    {
        public int userid;
        public string connectionString;
        public Income()
        {
            InitializeComponent();
            userid = Form1.userid;
            connectionString = Form1.connectionString;

        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            index.income_expense_calc();
            panelLeft.Top = buttonHome.Top;
            this.Hide();
            index f = new index();
            f.Show();
        }

        private void buttonExpense_Click(object sender, EventArgs e)
        {
            panelLeft.Top = buttonExpense.Top;
            this.Hide();
            Expense f = new Expense();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        //Add Income
        private void button1_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            //validation

            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Today.Date;
            string ErrorMsg;
            var val = validation(textBox1.Text,textBox2.Text,out ErrorMsg);
          
            if (!val)
            {
                MessageBox.Show(ErrorMsg, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(dateTimePicker1.Value.Date > today.Value)
            {
                MessageBox.Show("Entered Date falls after "+today.Value.ToString("dd-MM-yyyy")+"", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                particular = textBox1.Text;
                amount = double.Parse(textBox2.Text);
                date = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

                // finds no of entries
                OracleConnection con = new OracleConnection(connectionString);
                OracleDataAdapter no_of_entries
                    = new OracleDataAdapter("SELECT INCOMEID FROM INCOME", con);
                DataTable detail_count = new DataTable();
                no_of_entries.Fill(detail_count);
                int incomeidmax = detail_count.Rows.Count;
                if (incomeidmax != 0)
                {
                    for (int i = 0; i < detail_count.Rows.Count; i++)
                    {
                        int temp = int.Parse(detail_count.Rows[i][0].ToString());

                        if (incomeidmax <= temp)
                        incomeidmax = temp;
                    }
                }
                incomeidmax++;
                con.Close();

                //checking for redundant entries
                string redundant = "SELECT INCOMEID FROM INCOME" +
                    " WHERE INCOMEPARTICULAR = '" + particular + "' AND " +
                    "INCOMEAMOUNT = " + amount + " AND " +
                    "INCOMEDATE = DATE'" + date + "' AND " +
                    "USERID = " + userid + "";
                con.Open();
                OracleDataAdapter adt = new OracleDataAdapter(redundant, con);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                con.Close();
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Entry aldready exist", "Duplicate not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    string sql = "INSERT INTO INCOME(INCOMEID,INCOMEPARTICULAR,INCOMEAMOUNT,INCOMEDATE,USERID)" +
                        "VALUES (" + incomeidmax + ",'" + particular + "'," + amount + ",DATE'" + date + "'," + userid + ") ";

                    try
                    {
                        con.Open();
                        OracleCommand cmd = new OracleCommand(sql, con);
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Income of \n" + textBox1.Text + " : " + textBox2.Text + " Added");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Try Again");
                        
                    }
                }
            }
        }
        //Edit Income
        private void button2_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            //validation

            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Today.Date;
            string ErrorMsg;
            var val = validation(textBox1.Text,textBox2.Text, out ErrorMsg);


            if (!val)
            {
                MessageBox.Show(ErrorMsg, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value.Date > today.Value)
            {
                MessageBox.Show("Entered Date falls after " + today.Value.ToString("dd-MM-yyyy") + "", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                particular = textBox1.Text;
                amount = double.Parse(textBox2.Text);
                date = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                //search if entry exists;

                string sql1 = "SELECT * FROM INCOME " +
                "WHERE USERID = " + userid + "AND INCOMEPARTICULAR = '" + particular + "'" +
                " AND INCOMEDATE = DATE'" + date + "'";


                OracleConnection con = new OracleConnection(connectionString);
                con.Open();
                OracleDataAdapter entry
                    = new OracleDataAdapter(sql1, con);
                DataTable dt = new DataTable();
                entry.Fill(dt);
                con.Close();


                string Sql(int incomeId)
                {
                    return "UPDATE INCOME " +
                    " SET INCOMEAMOUNT = " + amount + "" +
                    "WHERE INCOMEID =" + incomeId + "";
                }



                try
                {
                    if (dt.Rows.Count == 1)
                    {
                        int incomeId = int.Parse(dt.Rows[0][0].ToString());

                        DialogResult msg = MessageBox.Show("Do you want to Edit Income Amount?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {
                            con.Open();
                            OracleCommand cmd = new OracleCommand(Sql(incomeId), con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            con.Close();
                            MessageBox.Show("" + particular + " Updated!");
                        }
                        else
                        {
                            MessageBox.Show("Amount Not updated");
                        }



                    }
                    else
                    {
                        MessageBox.Show("Entry Does not exist");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Try again");
                }
            }
        }
        //delete income
        private void button3_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            //validation
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Today.Date;
            string ErrorMsg;
            var val = validation(textBox1.Text,textBox2.Text, out ErrorMsg);

            if (!val)
            {
                MessageBox.Show(ErrorMsg, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value.Date > today.Value)
            {
                MessageBox.Show("Entered Date falls after " + today.Value.ToString("dd-MM-yyyy") + "", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                particular = textBox1.Text;
                amount = double.Parse(textBox2.Text);
                date = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                //search if entry exists;

                string sql1 = "SELECT * FROM INCOME " +
                "WHERE USERID = " + userid + "AND INCOMEPARTICULAR = '" + particular + "'" +
                " AND INCOMEDATE = DATE'" + date + "'";


                OracleConnection con = new OracleConnection(connectionString);
                con.Open();
                OracleDataAdapter entry
                    = new OracleDataAdapter(sql1, con);
                DataTable dt = new DataTable();
                entry.Fill(dt);
                con.Close();

                //Delete Query
                string Sql(int incomeId)
                {
                    return "DELETE FROM INCOME WHERE INCOMEID=" + incomeId + "";
                }
                try
                {
                    if (dt.Rows.Count == 1)
                    {
                        int incomeId = int.Parse(dt.Rows[0][0].ToString());
                        DialogResult dr = MessageBox.Show("Do you want to delete the entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (dr == DialogResult.Yes)
                        {
                            con.Open();
                            OracleCommand cmd = new OracleCommand(Sql(incomeId), con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
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

                }
            }

        }

        public static bool validation(string particular, string amount,out string error)
        {
            error = string.Empty;
            var amt = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (string.IsNullOrWhiteSpace(particular))
            {
                error = "Particulars should not be empty";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(amount))
            {
                error = "Amount should not be empty";
                return false;
            }
            else if (!amt.IsMatch(amount))
            {
                error = "Amount should consists of Numbers only";
                return false;
            }
            else
                return true;
        }
    }
}

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
    public partial class Income : Form
    {
        public int userid;
        public string connectionString;
        public Income()
        {
            InitializeComponent();
            userid = Form1.userid;
            connectionString = Form1.connectionString;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;
            

           

            // finds no of entries
            OracleConnection con = new OracleConnection(connectionString);
            OracleDataAdapter no_of_entries
                = new OracleDataAdapter("SELECT * FROM INCOME", con);
            DataTable detail_count = new DataTable();
            no_of_entries.Fill(detail_count);
            int incomeidmax = detail_count.Rows.Count;
            if (incomeidmax != 0)
            {
                incomeidmax = int.Parse(detail_count.Rows[0][0].ToString());
            }
            incomeidmax++;
            con.Close();




            string sql = "INSERT INTO INCOME(INCOMEID,INCOMEPARTICULAR,INCOMEAMOUNT,INCOMEDATE,USERID)" +
                "VALUES ("+incomeidmax+",'"+particular+"',"+amount+",DATE'"+date+"',"+userid+") ";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Income of \n"+textBox1.Text + " : " + textBox2.Text + " Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;
            

            //search if entry exists;

            string sql1 = "SELECT * FROM INCOME " +
                "WHERE USERID = "+userid+"AND INCOMEPARTICULAR = '"+particular+"'" +
                " AND INCOMEDATE = DATE'"+date+"'";
            
            
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
            



            if (dt.Rows.Count == 1)
            {
                int incomeId = int.Parse(dt.Rows[0][0].ToString());

                DialogResult msg = MessageBox.Show("Do you want to Edit Income Amount?","Yes?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.Yes )
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

        private void button3_Click(object sender, EventArgs e)
        {
            //variables
            string particular, date;
            double amount;

            particular = textBox1.Text;
            //amount = double.Parse(textBox2.Text);
            date = dateTimePicker1.Text;
            

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
                return "DELETE * FROM INCOME WHERE INCOMEID=" + incomeId + "";
            }
            try
            {
                if (dt.Rows.Count == 1)
                {
                    int incomeId = int.Parse(dt.Rows[0][0].ToString());
                    DialogResult dr = MessageBox.Show("Do you want to delete the entry?", "Yes?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                throw;
            }

        }
    }
}

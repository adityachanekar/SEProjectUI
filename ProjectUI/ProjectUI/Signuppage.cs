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
    
    public partial class Signuppage : Form
    {
        
        

        
        public Signuppage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Signuppage_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        { 


            //To count no. of users
            OracleConnection con = new OracleConnection("Data Source=XE;user id = db1;password=aditya;");
            
            con.Open();
            OracleDataAdapter no_of_users
                = new OracleDataAdapter("SELECT DETAILID FROM DETAIL",con);
            DataTable detail_count = new DataTable();
            no_of_users.Fill(detail_count);
            int useridmax = detail_count.Rows.Count;
            useridmax++;
            con.Close();

            //variable declaration
            string fname, lname, dob, contact, username, password;
            fname = textBox1.Text;
            lname = textBox2.Text;
            dob = textBox4.Text;
            contact = textBox5.Text;
            username = textBox3.Text;
            password = textBox6.Text;
            
            try
            {


                //SQL Query
                string sql = "INSERT INTO DETAIL(DETAILID,FNAME,LNAME,CONTACT,DOB,USERID) " +
                    "VALUES (" + useridmax + ", '" + fname + "','" + lname + "','" + contact + "',DATE'"+dob+"'," + useridmax + ") ";
                string sql1 = "INSERT INTO USERD(USERID,USERNAME,PASSWORD)" +
                   "VALUES (" + useridmax + ",'" + username + "','" + password + "')";


                con.Open();

                //Initialise Variables
                OracleCommand cmd = new OracleCommand(sql1, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
                
                MessageBox.Show("User Registered");
            }
            catch(Exception )
            {
                
                MessageBox.Show("Try Again");
                throw;
            }

            
        }
    }
}

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
                = new OracleDataAdapter("SELECT DETAILID FROM DETAIL", con);
            DataTable detail_count = new DataTable();
            no_of_users.Fill(detail_count);
            int useridmax = detail_count.Rows.Count;
            useridmax++;
            con.Close();

            //variable declaration
            string fname, lname, dob, contact, username, password;
            fname = textBox1.Text;
            lname = textBox2.Text;
            dob = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            contact = textBox5.Text;
            username = textBox3.Text;
            password = textBox6.Text;

            //for comparing dates for validation
            var DOB = dateTimePicker1;
            DateTimePicker today = new DateTimePicker();
            today.Value = DateTime.Today.Date;
            //password validation
            string error;
            var val = validation(fname,lname,contact, username,password, out error);


            if(!val)
                MessageBox.Show(error,"Credential Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            if (DOB.Value.Date > today.Value.Date)
            {
                MessageBox.Show("Entered Date of Birth should fall before " + today.Value.Date.ToString("dd-MM-yyyy"),"Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(DOB.Value.Date <= today.Value.Date && val)
            {
                try
                {


                    //SQL Query
                    string sql = "INSERT INTO DETAIL(DETAILID,FNAME,LNAME,CONTACT,DOB,USERID) " +
                        "VALUES (" + useridmax + ", '" + fname + "','" + lname + "','" + contact + "',DATE'" + dob + "'," + useridmax + ") ";
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
                    Form1 f = new Form1();
                    this.Hide();
                    f.Show();
                }
                catch (Exception)
                {

                    MessageBox.Show("Try Again");
                    
                }

            }

        }

        public bool validation(string fname,string lname,string contact, string username, string password, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            var input = password;
            var contactNumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[/@$-]");

            /*
             * This regex will enforce these rules:
             * • At least one upper case english letter 
             * • At least one lower case english letter 
             * • At least one digit 
             * • At least one special character 
             * • Minimum 8 in length and Max 15
             */
            if (string.IsNullOrWhiteSpace(fname))
            {
                ErrorMessage = "First Name should not be empty";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(lname))
            {
                ErrorMessage = "Last Name should not be empty";
                return false;
            }
            else if (hasNumber.IsMatch(fname) || hasNumber.IsMatch(lname)) 
            {
                ErrorMessage = "Names should not contain any numeric value";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(username))
            {
                ErrorMessage = "Username should not be empty";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(contact))
            {
                ErrorMessage = "Mobile No. should not be empty";
                return false;
            }
            else if (!contactNumber.IsMatch(contact) )
            {
                ErrorMessage = "Mobile No. should be 10 digits only";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Password should not be empty";
                return false;
            }
           

            else if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than 5 or greater than 15 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one of these special case characters' / @ $ - ' ";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Oracle.DataAccess.Client;

namespace ProjectUI
{
    public partial class Form1 : Form
    {
        public static int userid;
        public static string connectionString = "Data Source=XE;User Id=db1;Password=aditya;";
        public Form1()
        {
            InitializeComponent();
            
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid;
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();
            OracleDataAdapter adt = new OracleDataAdapter("SELECT * FROM USERD WHERE USERNAME='" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "'",con);
            DataTable d = new DataTable();
            adt.Fill(d);
            if (d.Rows.Count == 1)
            {
                uid = d.Rows[0][0].ToString();
                userid = int.Parse(uid);
                MessageBox.Show("Successful, welcome user:"+ userid);
                this.Hide();
                index f = new index();
                f.Show();
            }
            else
            {
                MessageBox.Show("Err 101: Wrong Credentials. Try Again");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signuppage f = new Signuppage();
            f.Show();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

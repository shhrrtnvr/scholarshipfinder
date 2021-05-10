using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class LogInAlumni : Form
    {
        public static string Username = "";

        public LogInAlumni()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Regex(@"\D");
            if (r.IsMatch(textBox1.Text))
            {
                MessageBox.Show(@"ID must be a number. Can not contain alphabet, white space or any special character.",
                    @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text.Length != 9)
            {
                MessageBox.Show(@"ID can have 9 digits only", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show(@"Password can not be empty.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            var selectQuery = "select * from login_alumni where id = '" + textBox1.Text.Trim() + "' and password = '" +
                              textBox2.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                con.Close();
                con.Open();
                selectQuery = "select * from alumni where id = '" + textBox1.Text.Trim() + "'";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                Username = mdr[1].ToString();

                Hide();
                var f = new DashboardAlumni();
                f.Show();
            }

            else
            {
                MessageBox.Show(@"Incorrect ID or Password!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new Form1();
            f.Show();
        }

        private void LogInAlumni_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new SignUpAlumni();
            f.Show();
        }
    }
}
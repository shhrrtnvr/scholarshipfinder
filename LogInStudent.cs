using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class LogInStudent : Form
    {
        public static string Username = "";

        public LogInStudent()
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

            var selectQuery = "select * from login_student where id = '" + textBox1.Text + "' and password = '" +
                              textBox2.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                con.Close();
                con.Open();
                selectQuery = "select * from student where id = '" + textBox1.Text.Trim() + "'";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                Username = mdr[1].ToString();
                Hide();
                var f = new DashboardStudent();
                f.Show();
            }

            else
            {
                MessageBox.Show(@"Incorrect username or password!", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new SignUpStudent();
            f.Show();
        }


        private void LogInStudent_Load(object sender, EventArgs e)
        {
        }
    }
}
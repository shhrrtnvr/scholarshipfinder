using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class LogInFaculty : Form
    {
        public static string Username = "";
        public static int id;

        public LogInFaculty()
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
                MessageBox.Show(@"Password can not be empty.", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            var selectQuery = "select * " +
                              "from login_faculty where id = '" +
                              textBox1.Text + "' and password = '" +
                              textBox2.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                con.Close();
                con.Open();
                selectQuery = "select * " +
                              "from faculty where id = '" +
                              textBox1.Text.Trim() + "'";
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();
                mdr.Read();
                id = int.Parse(mdr[0].ToString());
                Username = mdr[1].ToString();
                Hide();
                var f = new DashboardFaculty();
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

        private void LogInFaculty_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new SignUpFaculty();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
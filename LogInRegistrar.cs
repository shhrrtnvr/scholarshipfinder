using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class LogInRegistrar : Form
    {
        public LogInRegistrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Enter your username", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                              "from registrar where username = '" +
                              textBox1.Text +
                              "' and password = '" +
                              textBox2.Text + "'";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            if (mdr.Read())
            {
                Hide();
                var f = new Registrar();
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
    }
}
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class SignUpStudent : Form
    {
        public SignUpStudent()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new LogInStudent();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show(@"Plase enter your name.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r1 = new Regex(@"^[\p{L} \.'\-]+$");
            if (!r1.IsMatch(textBox1.Text.Trim()))
            {
                MessageBox.Show(@"Name can only have alphabets and space in between.", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show(@"ID can not be empty", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = new Regex(@"\D");
            if (r.IsMatch(textBox2.Text.Trim()))
            {
                MessageBox.Show(@"ID must be a number. Can not contain alphabet, any special character.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Trim().Length != 9)
            {
                MessageBox.Show(@"ID can have 9 digits only", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show(@"Password can not be empty.", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var choice = MessageBox.Show(@"Confirm?", @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (choice == DialogResult.Yes)
            {
                var name = textBox1.Text.Trim();
                var formattedName = new StringBuilder();
                for (var i = 0; i < name.Length; i++)
                    if (i == 0)
                    {
                        formattedName.Append(char.ToUpper(name[0]));
                    }
                    else
                    {
                        if (name[i - 1] == ' ')
                        {
                            if (name[i] == ' ') continue;
                            formattedName.Append(char.ToUpper(name[i]));
                        }
                        else
                        {
                            formattedName.Append(char.ToLower(name[i]));
                        }
                    }

                var con = new MySqlConnection("server=localhost;user id=root;database=kys");
                MySqlDataAdapter sda;

                con.Open();

                var dt = new DataTable();
                var selectQuery = "insert into" +
                                  " student(id, name)" +
                                  " values ('" +
                                  textBox2.Text.Trim() + "', '" +
                                  formattedName +
                                  "')";

                try
                {
                    sda = new MySqlDataAdapter(selectQuery, con);
                    sda.Fill(dt);

                    MessageBox.Show(@"Registration Completed!", @"Successful", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                catch (Exception)
                {
                    MessageBox.Show(@"ID already exists", @"Failed", MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Information);
                    con.Close();
                    return;
                }

                con.Close();

                var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
                MySqlDataAdapter sda2;

                con2.Open();

                var dt2 = new DataTable();
                var selectQuery2 = "insert into" +
                                   " login_student(id, password)" +
                                   " values ('" +
                                   textBox2.Text + "', '" +
                                   textBox3.Text +
                                   "')";

                try
                {
                    sda2 = new MySqlDataAdapter(selectQuery2, con2);
                    sda2.Fill(dt2);
                }

                catch (Exception)
                {
                    // ignored
                }

                con2.Close();

                Close();
                var f = new LogInStudent();
                f.Show();
            }
        }
    }
}
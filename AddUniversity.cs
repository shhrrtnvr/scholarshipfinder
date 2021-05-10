using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class AddUniversity : Form
    {
        public AddUniversity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Enter university name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = new Regex(@"^[A-Za-z\s]+$");

            if (!r.IsMatch(textBox1.Text))
            {
                MessageBox.Show(@"Invalid University. Only alphabets and space allowed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlDataAdapter sda;

            var university = textBox1.Text.Trim();
            var formattedUni = new StringBuilder();
            for (var i = 0; i < university.Length; i++)
                if (i == 0)
                {
                    formattedUni.Append(char.ToUpper(university[0]));
                }
                else
                {
                    if (university[i - 1] == ' ')
                    {
                        if (university[i] == ' ') continue;
                        formattedUni.Append(char.ToUpper(university[i]));
                    }
                    else
                    {
                        formattedUni.Append(char.ToLower(university[i]));
                    }
                }

            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show(@"Select a country", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            con.Open();

            var dt = new DataTable();
            var selectQuery = "insert into university (name, country_id) values ('" + formattedUni + "', " +
                              textBox2.Text + ")";

            try
            {
                sda = new MySqlDataAdapter(selectQuery, con);
                sda.Fill(dt);

                MessageBox.Show(@"University Added", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();

            Close();
        }

        private void AddUniversity_Load(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            selectQuery = "SELECT name FROM country";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            comboBox2.Items.Clear();

            while (mdr.Read()) comboBox2.Items.Add(mdr["name"].ToString());

            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            selectQuery = "SELECT id FROM country WHERE name = '" + comboBox2.Text + "'";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();
            textBox2.Text = mdr["id"].ToString();

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
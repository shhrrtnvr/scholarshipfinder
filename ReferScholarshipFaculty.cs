using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class ReferScholarshipFaculty : Form
    {
        public ReferScholarshipFaculty()
        {
            InitializeComponent();
        }

        private void ReferScholarshipFaculty_Load(object sender, EventArgs e)
        {
            label6.Text = LogInFaculty.Username;
            button6.Enabled = false;

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            selectQuery = "SELECT name FROM subject";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            comboBox3.Items.Clear();

            while (mdr.Read()) comboBox3.Items.Add(mdr["name"].ToString());

            con.Close();

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;
            selectQuery2 = "SELECT name FROM country";
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            comboBox2.Items.Clear();

            while (mdr2.Read()) comboBox2.Items.Add(mdr2["name"].ToString());

            con2.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            selectQuery = "SELECT id FROM subject WHERE name = '" + comboBox3.Text + "'";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();
            textBox2.Text = mdr["id"].ToString();

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
            textBox6.Text = mdr["id"].ToString();

            con.Close();

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;
            selectQuery2 = "SELECT name FROM university WHERE country_id = " + textBox6.Text;
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            comboBox1.Items.Clear();

            while (mdr2.Read()) comboBox1.Items.Add(mdr2["name"].ToString());

            con2.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;
            selectQuery = "SELECT id FROM university WHERE name = '" + comboBox1.Text + "'";
            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            mdr.Read();
            textBox1.Text = mdr["id"].ToString();

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new ReferScholarshipFaculty();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new AddSubject();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new AddCountry();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new AddUniversity();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show(@"Select Subject", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show(@"Enter Professor name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = new Regex(@"^[A-Za-z\s]+$");

            if (!r.IsMatch(textBox3.Text))
            {
                MessageBox.Show(@"Invalid Professor. Only alphabets and space allowed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show(@"Select Country", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Enter University name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var professor = textBox3.Text.Trim();
            var formattedProfessor = new StringBuilder();
            for (var i = 0; i < professor.Length; i++)
                if (i == 0)
                {
                    formattedProfessor.Append(char.ToUpper(professor[0]));
                }
                else
                {
                    if (professor[i - 1] == ' ')
                    {
                        if (professor[i] == ' ') continue;
                        formattedProfessor.Append(char.ToUpper(professor[i]));
                    }
                    else
                    {
                        formattedProfessor.Append(char.ToLower(professor[i]));
                    }
                }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlDataAdapter sda;
            MySqlCommandBuilder scb;
            var selectQuery = "select * from professor";
            var ds = new DataSet();

            con.Open();

            sda = new MySqlDataAdapter(selectQuery, con);
            scb = new MySqlCommandBuilder(sda);
            sda.Fill(ds, "professor");

            var dr = ds.Tables["professor"].NewRow();

            try
            {
                dr["name"] = textBox3.Text;
                dr["university_id"] = textBox1.Text;
                dr["subject_id"] = textBox2.Text;

                ds.Tables["professor"].Rows.Add(dr);

                var adpt = sda.Update(ds, "professor");

                if (adpt == 1)
                {
                    MessageBox.Show(@"Professor added in the database! Click Refer to complete the process.",
                        @"Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button6.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;
            selectQuery2 = "SELECT id FROM professor WHERE name = '" + textBox3.Text + "'";
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            mdr2.Read();
            textBox4.Text = mdr2["id"].ToString();

            con2.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show(@"Select Subject", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show(@"Enter Professor name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var r = new Regex(@"^[A-Za-z\s]+$");

            if (!r.IsMatch(textBox3.Text))
            {
                MessageBox.Show(@"Invalid Professor. Only alphabets and space allowed", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show(@"Select Country", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Enter University name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var professor = textBox3.Text.Trim();
            var formattedProfessor = new StringBuilder();
            for (var i = 0; i < professor.Length; i++)
                if (i == 0)
                {
                    formattedProfessor.Append(char.ToUpper(professor[0]));
                }
                else
                {
                    if (professor[i - 1] == ' ')
                    {
                        if (professor[i] == ' ') continue;
                        formattedProfessor.Append(char.ToUpper(professor[i]));
                    }
                    else
                    {
                        formattedProfessor.Append(char.ToLower(professor[i]));
                    }
                }

            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlDataAdapter sda;
            MySqlCommandBuilder scb;
            var selectQuery = "select * from scholarship";
            var ds = new DataSet();

            con.Open();

            sda = new MySqlDataAdapter(selectQuery, con);
            scb = new MySqlCommandBuilder(sda);
            sda.Fill(ds, "scholarship");

            var dr = ds.Tables["scholarship"].NewRow();

            try
            {
                dr["referringFaculty"] = Convert.ToInt32(label6.Text);
                dr["professorFunding"] = Convert.ToInt32(textBox4.Text);
                dr["status"] = "Ungrabbed!";

                ds.Tables["scholarship"].Rows.Add(dr);

                var adpt = sda.Update(ds, "scholarship");

                if (adpt == 1)
                {
                    MessageBox.Show(@"Referral Successful!", @"Confirmation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    button6.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }
    }
}
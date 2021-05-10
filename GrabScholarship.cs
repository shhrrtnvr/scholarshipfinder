using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class GrabScholarship : Form
    {
        public static string SetValueForText1 = "";

        public GrabScholarship()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValueForText1 = textBox1.Text.Trim();
            if (SetValueForText1 == "")
            {
                MessageBox.Show(@"Enter Scholarship ID", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;
            selectQuery2 = "SELECT professor.name AS pname, " +
                           "university.name AS uname, " +
                           "country.name AS cname, " +
                           "subject.name AS sname, " +
                           "scholarship.referringAlumni AS aname, " +
                           "scholarship.referringFaculty AS fname, " +
                           "scholarship.status AS sstatus " +
                           "FROM scholarship, university, professor, subject, country " +
                           "WHERE scholarship.referringFaculty IS NULL " +
                           "AND scholarship.referringAlumni IS NOT NULL " +
                           "AND scholarship.professorFunding = professor.id " +
                           "AND professor.university_id = university.id " +
                           "AND professor.subject_id = subject.id " +
                           "AND university.country_id = country.id AND scholarship.id = " +
                           textBox1.Text;
            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            if (mdr2.HasRows)
            {
                mdr2.Read();
                Console.Write(mdr2["pname"]);

                textBox2.Text = mdr2["pname"].ToString();
                textBox3.Text = mdr2["uname"].ToString();
                textBox4.Text = mdr2["cname"].ToString();
                textBox5.Text = mdr2["sname"].ToString();
                textBox6.Text = mdr2["aname"].ToString();
                textBox7.Text = mdr2["fname"].ToString();
                textBox8.Text = mdr2["sstatus"].ToString();
            }

            else
            {
                var con3 = new MySqlConnection("server=localhost;user id=root;database=kys");
                MySqlCommand cmd3;
                MySqlDataReader mdr3;

                con3.Open();

                string selectQuery3;
                selectQuery3 = "SELECT professor.name AS pname, " +
                               "university.name AS uname, " +
                               "country.name AS cname, " +
                               "subject.name AS sname, " +
                               "scholarship.referringAlumni AS aname, " +
                               "scholarship.referringFaculty AS fname, " +
                               "scholarship.status AS sstatus FROM scholarship, " +
                               "university, professor, subject, " +
                               "country WHERE scholarship.referringFaculty IS NOT NULL " +
                               "AND scholarship.referringAlumni IS NULL " +
                               "AND scholarship.professorFunding = professor.id " +
                               "AND professor.university_id = university.id " +
                               "AND professor.subject_id = subject.id " +
                               "AND university.country_id = country.id " +
                               "AND scholarship.id = " + textBox1.Text;

                cmd3 = new MySqlCommand(selectQuery3, con3);
                mdr3 = cmd3.ExecuteReader();

                if (mdr3.HasRows)
                {
                    mdr3.Read();

                    textBox2.Text = mdr3["pname"].ToString();
                    textBox3.Text = mdr3["uname"].ToString();
                    textBox4.Text = mdr3["cname"].ToString();
                    textBox5.Text = mdr3["sname"].ToString();
                    textBox6.Text = mdr3["aname"].ToString();
                    textBox7.Text = mdr3["fname"].ToString();
                    textBox8.Text = mdr3["sstatus"].ToString();
                }
                else
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    MessageBox.Show(@"Invalid Scholarship ID", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con3.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new ExploreScholarships();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new GrabConfirm();
            f.Show();
        }

        private void GrabScholarship_Load(object sender, EventArgs e)
        {
        }
    }
}
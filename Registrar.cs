using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Know_Your_Scholarship_
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            var con = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd;
            MySqlDataReader mdr;

            con.Open();

            string selectQuery;

            selectQuery =
                "SELECT scholarship.id AS sid, professor.name AS pname, university.name AS uname, subject.name AS sname, scholarship.referringAlumni AS aname, scholarship.referringFaculty AS fname, scholarship.confirmation AS confirmation FROM scholarship, university, professor, subject WHERE scholarship.referringFaculty IS NOT NULL AND scholarship.referringAlumni IS NULL AND scholarship.professorFunding = professor.id AND professor.university_id = university.id AND professor.subject_id = subject.id";

            cmd = new MySqlCommand(selectQuery, con);
            mdr = cmd.ExecuteReader();

            listView1.Items.Clear();
            while (mdr.Read())
            {
                var item = new ListViewItem();
                item.Text = mdr["sid"].ToString();
                item.SubItems.Add(mdr["pname"].ToString());
                item.SubItems.Add(mdr["uname"].ToString());
                item.SubItems.Add(mdr["sname"].ToString());
                item.SubItems.Add(mdr["aname"].ToString());
                item.SubItems.Add(mdr["fname"].ToString());
                item.SubItems.Add(mdr["confirmation"].ToString());

                listView1.Items.Add(item);
            }

            con.Close();

            var con2 = new MySqlConnection("server=localhost;user id=root;database=kys");
            MySqlCommand cmd2;
            MySqlDataReader mdr2;

            con2.Open();

            string selectQuery2;

            selectQuery2 =
                "SELECT scholarship.id AS sid, professor.name AS pname, university.name AS uname, subject.name AS sname, scholarship.referringAlumni AS aname, scholarship.referringFaculty AS fname, scholarship.confirmation AS confirmation FROM scholarship, university, professor, subject WHERE scholarship.referringFaculty IS NULL AND scholarship.referringAlumni IS NOT NULL AND scholarship.professorFunding = professor.id AND professor.university_id = university.id AND professor.subject_id = subject.id";

            cmd2 = new MySqlCommand(selectQuery2, con2);
            mdr2 = cmd2.ExecuteReader();

            while (mdr2.Read())
            {
                var item = new ListViewItem();
                item.Text = mdr2["sid"].ToString();
                item.SubItems.Add(mdr2["pname"].ToString());
                item.SubItems.Add(mdr2["uname"].ToString());
                item.SubItems.Add(mdr2["sname"].ToString());
                item.SubItems.Add(mdr2["aname"].ToString());
                item.SubItems.Add(mdr2["fname"].ToString());
                item.SubItems.Add(mdr2["confirmation"].ToString());

                listView1.Items.Add(item);
            }

            con2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show(@"Enter scholarship id", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show(@"Password can not be empty", @"Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var con = new MySqlConnection("server=localhost;user id=root;database=kys");
                MySqlCommand cmd;
                MySqlDataReader mdr;

                con.Open();

                var selectQuery = "update scholarship set confirmation = 'confirmed' where id = " + textBox1.Text;
                cmd = new MySqlCommand(selectQuery, con);
                mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                }

                con.Close();

                con.Open();

                selectQuery = "insert into scholarship_confirm values (" + textBox1.Text + ", '" + textBox2.Text + "')";
                cmd = new MySqlCommand(selectQuery, con);
                try
                {
                    mdr = cmd.ExecuteReader();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Scholarship doesnot exist", @"Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                while (mdr.Read())
                {
                }

                con.Close();

                MessageBox.Show("Scholarship Confirmed!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
            var f = new Registrar();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new ScholarshipPasswordViewer();
            f.Show();
        }
    }
}
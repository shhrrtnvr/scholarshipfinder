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

            con.Open();

            const string selectQuery = "SELECT scholarship.id AS sid," +
                                       " professor.name AS pname," +
                                       " university.name AS uname," +
                                       " subject.name AS sname," +
                                       " scholarship.referringAlumni AS aname," +
                                       " scholarship.referringFaculty AS fname," +
                                       " scholarship.confirmation AS confirmation " +
                                       "FROM scholarship, university, professor, subject " +
                                       "WHERE scholarship.referringFaculty IS NOT NULL" +
                                       " AND scholarship.referringAlumni IS NULL" +
                                       " AND scholarship.professorFunding = professor.id" +
                                       " AND professor.university_id = university.id" +
                                       " AND professor.subject_id = subject.id";

            var command = new MySqlCommand(selectQuery, con);
            var mdr = command.ExecuteReader();

            listView1.Items.Clear();
            while (mdr.Read())
            {
                var item = new ListViewItem {Text = mdr["sid"].ToString()};
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

            con2.Open();

            const string selectQuery2 = "SELECT scholarship.id AS sid," +
                                        " professor.name AS pname," +
                                        " university.name AS uname," +
                                        " subject.name AS sname," +
                                        " scholarship.referringAlumni AS aname," +
                                        " scholarship.referringFaculty AS fname," +
                                        " scholarship.confirmation AS confirmation " +
                                        "FROM scholarship, university, professor, subject " +
                                        "WHERE scholarship.referringFaculty IS NULL" +
                                        " AND scholarship.referringAlumni IS NOT NULL" +
                                        " AND scholarship.professorFunding = professor.id" +
                                        " AND professor.university_id = university.id" +
                                        " AND professor.subject_id = subject.id";

            var sqlCommand = new MySqlCommand(selectQuery2, con2);
            var dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                var item = new ListViewItem {Text = dataReader["sid"].ToString()};
                item.SubItems.Add(dataReader["pname"].ToString());
                item.SubItems.Add(dataReader["uname"].ToString());
                item.SubItems.Add(dataReader["sname"].ToString());
                item.SubItems.Add(dataReader["aname"].ToString());
                item.SubItems.Add(dataReader["fname"].ToString());
                item.SubItems.Add(dataReader["confirmation"].ToString());

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

                con.Open();

                var selectQuery = "update scholarship" +
                                  " set confirmation = 'confirmed' where id = " +
                                  textBox1.Text.Trim();
                var sqlCommand = new MySqlCommand(selectQuery, con);
                var dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                }

                con.Close();

                con.Open();

                selectQuery = "insert into" +
                              " scholarship_confirm values (" +
                              textBox1.Text.Trim() + ", '" +
                              textBox2.Text.Trim() + "')";
                sqlCommand = new MySqlCommand(selectQuery, con);
                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Scholarship does not exist", @"Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                while (dataReader.Read())
                {
                }

                con.Close();

                MessageBox.Show(@"Scholarship Confirmed!");
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace department
{
    public partial class AddAssessment : Form
    {
        SqlConnection conn;
        public AddAssessment(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT groups.group_id FROM groups JOIN students " +
                "ON groups.group_id = students.group_id WHERE students.email='" + comboBox1.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "email";
            comboBox3.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM students WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox2.Text = first_name;
                textBox3.Text = last_name;
                textBox4.Text = father_name;
            }
            conn.Close();
        }
        private void fillComboBox1()
        {
            string query = "SELECT students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }
        private void AddAssessment_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups ON lectors_groups_subjects.group_id=groups.group_id " +
                "WHERE lectors.email='" + comboBox3.Text.ToString() + "'" + " AND lectors_groups_subjects.group_id = (SELECT group_id FROM students WHERE email='" + comboBox1.Text.ToString() + "'" +")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox4.DisplayMember = "subject_name";
            comboBox4.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM lectors WHERE lectors.email='" + comboBox3.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox5.Text = first_name;
                textBox6.Text = last_name;
                textBox7.Text = father_name;
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 && comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Выберите почту студента, которому хотите поставить оценку");
            }
            else if (comboBox5.SelectedIndex == -1 && comboBox5.Text.Length == 0)
            {
                MessageBox.Show("Выберите семестр");
            }
            else if (comboBox2.SelectedIndex == -1 && comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Выберите оценку");
            }
            else if (comboBox3.SelectedIndex == -1 && comboBox3.Text.Length == 0)
            {
                MessageBox.Show("Выберите лектора");
            }
            else if (comboBox4.SelectedIndex == -1 && comboBox4.Text.Length == 0)
            {
                MessageBox.Show("Выберите предмет");
            }
            else
            {
                var date = dateTimePicker1.Text;
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("exec check_assessment @email_students='" +
                    comboBox1.Text.ToString() + "'" + "," + "@lectorEmail='" +
                    comboBox3.Text.ToString() + "'" + "," + "@subject_name='" +
                    comboBox4.Text.ToString() + "'" + "," + "@passed_date='" +
                    date + "'" + "," + "@semestr='" +
                    (Convert.ToInt32(comboBox5.Text)) + "'" + "," +
                    "@assessment='" + (Convert.ToInt32(comboBox2.Text)) + "'", conn);
                int assessmentInt = (Int32)sqlCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                if (assessmentInt == 1)
                {
                    MessageBox.Show("Оценка уже поставлена");
                }
                else
                {
                    StringBuilder query = new StringBuilder();
                    conn.Open();
                    query.Append("exec add_assessmentv2 @email_students='" + comboBox1.Text.ToString() + "'" + "," + "@passed_date='" + date + "'" + "," + "@semestr=" + (Convert.ToInt32(comboBox5.Text)) + "," +
                        "@assessment=" + (Convert.ToInt32(comboBox2.Text)) + "," + "@lectorEmail='" +
                        comboBox3.Text.ToString() + "'" + "," + "@subject_name='" + comboBox4.Text.ToString() + "'");
                    var cmd = new SqlCommand(query.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Оценка добавлена");
                }
                conn.Close();
            }
        }
    }
}

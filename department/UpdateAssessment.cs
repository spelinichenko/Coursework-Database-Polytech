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
    public partial class UpdateAssessment : Form
    {
        SqlConnection conn;

        public UpdateAssessment(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox7()
        {
            string query = "SELECT students.email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox7.DisplayMember = "email";
            comboBox7.DataSource = dataTable;
        }
        private void fillComboBox1()
        {
            string query = "SELECT DISTINCT email FROM students JOIN assessments ON students.student_id=assessments.student_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }
        private void UpdateAssessment_Load(object sender, EventArgs e)
        {
            fillComboBox1();
            fillComboBox7();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT lectors.email FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
            "ON assessments.student_id = students.student_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "email";
            comboBox2.DataSource = dataTable;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT subject_name FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + "AND lectors.email ='" + comboBox2.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox3.DisplayMember = "subject_name";
            comboBox3.DataSource = dataTable;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.passed_date FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND lectors.email ='" + comboBox2.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox3.Text.ToString() + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox4.DisplayMember = "passed_date";
            comboBox4.DataSource = dataTable;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.semestr FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND lectors.email ='" + comboBox2.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox3.Text.ToString() + "'" + " AND assessments.passed_date='" + comboBox4.Text + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox5.DisplayMember = "semestr";
            comboBox5.DataSource = dataTable;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT assessments.assessment FROM assessments JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN students " +
                "ON assessments.student_id = students.student_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND lectors.email ='" + comboBox2.Text.ToString()
                + "'" + "AND subjects.subject_name='" + comboBox3.Text.ToString() + "'" + " " +
                "AND assessments.passed_date='" + comboBox4.Text + "'" + " AND assessments.semestr='" +
                (Convert.ToInt32(comboBox5.Text)) + "'", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox6.DisplayMember = "assessment";
            comboBox6.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT assessment_id AS 'Идентификатор оценки', students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND lectors.email ='" + comboBox2.Text.ToString()
                + "'" + "AND subjects.subject_name='" +
                comboBox3.Text.ToString() + "'" + " AND assessments.passed_date='" +
                comboBox4.Text + "'" + " AND assessments.semestr='" +
                (Convert.ToInt32(comboBox5.Text)) + "'" + " AND assessments.assessment='" +
                (Convert.ToInt32(comboBox6.Text)) + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора', students.email AS 'Почта студента', lectors.email AS 'Почта лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND lectors.email ='" + comboBox2.Text.ToString()
                + "'" + "AND subjects.subject_name='" +
                comboBox3.Text.ToString() + "'" + " AND assessments.passed_date='" +
                comboBox4.Text + "'" + " AND assessments.semestr='" +
                (Convert.ToInt32(comboBox5.Text)) + "'" + " AND assessments.assessment='" +
                (Convert.ToInt32(comboBox6.Text)) + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string emailSt = dr["Почта студента"].ToString();
                string date = dr["Дата получения оценки"].ToString();
                string semestr = dr["Семестр"].ToString();
                string assessment = dr["Оценка"].ToString();
                string emailLec = dr["Почта лектора"].ToString();
                string subject = dr["Название предмета"].ToString();
                comboBox7.Text = emailSt;
                dateTimePicker1.Text = date;
                comboBox9.Text = semestr;
                comboBox10.Text = assessment;
                comboBox11.Text = emailLec;
                comboBox12.Text = subject;
            }
            conn.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT lectors.email FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT groups.group_id FROM groups JOIN students " +
                "ON groups.group_id = students.group_id WHERE students.email='" + comboBox7.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox11.DisplayMember = "email";
            comboBox11.DataSource = dataTable;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.lector_id = (SELECT lector_id FROM lectors WHERE lectors.email ='" + comboBox11.Text.ToString() + "'" + ")" +
                " AND lectors_groups_subjects.group_id = (SELECT group_id FROM students WHERE students.email ='" + comboBox7.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox12.DisplayMember = "subject_name";
            comboBox12.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Text;
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("exec check_assessment @email_students='" +
                comboBox7.Text.ToString() + "'" + "," + "@lectorEmail='" +
                comboBox11.Text.ToString() + "'" + "," + "@subject_name='" +
                comboBox12.Text.ToString() + "'" + "," + "@passed_date='" +
                date + "'" + "," + "@semestr='" +
                (Convert.ToInt32(comboBox9.Text)) + "'" + "," +
                "@assessment='" + (Convert.ToInt32(comboBox10.Text)) + "'", conn);
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
                query.Append("exec update_assessmentV1 @emailSt1='" +
                    comboBox1.Text.ToString() + "'" + "," + "@emailLec1='" +
                    comboBox2.Text.ToString() + "'" + "," + "@subject_name1='" +
                    comboBox3.Text.ToString() + "'" + "," + "@passed_date1='" +
                    comboBox4.Text + "'" + "," + "@semestr1='" +
                    (Convert.ToInt32(comboBox5.Text)) + "'" + "," + "@assessment1='" +
                    (Convert.ToInt32(comboBox6.Text)) + "'" + "," +
                     "@emailStNew = '" + comboBox7.Text.ToString() + "'" + "," + "@emailLecNew='" +
                    comboBox11.Text.ToString() + "'" + "," + "@subject_nameNew='" +
                    comboBox12.Text.ToString() + "'" + "," + "@passed_dateNew='" +
                    date + "'" + "," + "@semestrNew='" +
                    (Convert.ToInt32(comboBox9.Text)) + "'" + "," + "@assessmentNew='" +
                    (Convert.ToInt32(comboBox10.Text)) + "'");
                SqlCommand sqlCommand1 = new SqlCommand(query.ToString(), conn);
                sqlCommand1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Данные оценки изменены");
              
                
            }
            conn.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT assessment_id AS 'Идентификатор оценки', students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

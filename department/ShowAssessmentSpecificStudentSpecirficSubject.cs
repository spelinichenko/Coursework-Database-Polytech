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
    public partial class ShowAssessmentSpecificStudentSpecirficSubject : Form
    {
        SqlConnection conn;
        public ShowAssessmentSpecificStudentSpecirficSubject(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void fillComboBox1()
        {
            string query = "SELECT DISTINCT email FROM students JOIN assessments " +
                "ON students.student_id=assessments.student_id";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }
        private void ShowAssessmentSpecificStudentSpecirficSubject_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sql = new SqlCommand("SELECT DISTINCT subjects.subject_name FROM subjects JOIN " +
                "lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN assessments ON lectors_groups_subjects.lector_group_subject_id=assessments.lector_group_subject_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT group_id FROM students WHERE students.email='"+comboBox1.Text.ToString() + "'" + ")", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox2.DisplayMember = "subject_name";
            comboBox2.DataSource = dataTable;
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM students WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string first_name = dr["first_name"].ToString();
                string last_name = dr["last_name"].ToString();
                string father_name = dr["father_name"].ToString();
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = father_name;
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', subjects.subject_name AS 'Название предмета', " +
                "assessments.assessment AS 'Оценка', assessments.passed_date AS 'Дата получения оценки' FROM students " +
                "INNER JOIN assessments ON students.student_id = assessments.student_id INNER JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id INNER JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id INNER JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'" + " AND subjects.subject_name ='" + comboBox2.Text.ToString() + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

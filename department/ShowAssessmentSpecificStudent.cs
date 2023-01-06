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
    public partial class ShowAssessmentSpecificStudent : Form
    {
        SqlConnection conn;
        public ShowAssessmentSpecificStudent(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        private void fillComboBox1()
        {
            string query = "SELECT email FROM students";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "email";
            comboBox1.DataSource = dataTable;
        }
        private void ShowAssessmentSpecificStudent_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя студента', students.last_name AS 'Фамилия студента', " +
                "students.father_name AS 'Отчество студента', " +
                "assessments.assessment AS 'Оценка', assessments.passed_date AS 'Дата получения оценки', " +
                "subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' " +
                "FROM students JOIN groups ON students.group_id = groups.group_id JOIN assessments ON " +
                "students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE students.email='" + comboBox1.Text.ToString() + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

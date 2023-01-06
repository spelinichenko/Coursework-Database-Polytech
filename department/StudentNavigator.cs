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
    public partial class StudentNavigator : Form
    {
        int id;
        SqlConnection conn;
        public StudentNavigator(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void StudentNavigator_Load(object sender, EventArgs e)
        {
            string avg = "";
            SqlCommand sqlCommand = new SqlCommand("SELECT ROUND(AVG(CAST(assessment AS FLOAT)), 1) 'Средняя оценка студента' FROM assessments JOIN students " +
                "ON students.student_id = assessments.student_id JOIN groups " +
                "ON students.group_id = groups.group_id " +
                "WHERE students.student_id="+id, conn);
            conn.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                avg = dr["Средняя оценка студента"].ToString();
                textBox1.Text = avg;
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInformation studentInformation = new StudentInformation(id, conn);
            studentInformation.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateStudentByStudent updateStudentByStudent = new UpdateStudentByStudent(id, conn);
            updateStudentByStudent.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowAssessmentSpecStutById assessmentSpecStutById = new ShowAssessmentSpecStutById(id, conn);
            assessmentSpecStutById.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowStudentsLectors showStudentsLectors = new ShowStudentsLectors(id, conn);
            showStudentsLectors.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT subjects.subject_name AS 'Предмет', " +
                "subjects.subject_description AS 'Описание предмета' FROM subjects " +
                "JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id " +
                "WHERE lectors_groups_subjects.group_id = (SELECT group_id FROM students WHERE students.student_id=" + id + ")", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyOdnogroups myOdnogroups = new MyOdnogroups(id, conn);
            myOdnogroups.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AllGroups allGroups = new AllGroups(conn);
            allGroups.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowTimetable showTimetable = new ShowTimetable(conn);
            showTimetable.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}

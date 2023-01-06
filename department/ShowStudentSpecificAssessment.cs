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

namespace department
{
    public partial class ShowStudentSpecificAssessment : Form
    {
        SqlConnection conn;
        public ShowStudentSpecificAssessment(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ShowStudentSpecificAssessment_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT students.first_name AS 'Имя', " +
                "students.last_name AS 'Фамилия', students.father_name AS 'Отчество', groups.group_number AS " +
                "'Номер группы', subjects.subject_name AS 'Название предмета' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments " +
                "ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.lector_group_subject_id = assessments.lector_group_subject_id JOIN subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id WHERE assessments.assessment ='" + (Convert.ToInt32(comboBox1.Text)) + "'", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

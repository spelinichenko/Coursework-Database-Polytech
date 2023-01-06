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
    public partial class ShowAllAssessments : Form
    {
        SqlConnection conn;
        public ShowAllAssessments(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowAllAssessments_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT assessment_id AS 'Идентификатор оценки', students.first_name AS 'Имя студента', " +
                "students.last_name AS 'Фамилия студента', students.father_name AS 'Отчество студента', assessments.assessment AS 'Оценка', " +
                "assessments.passed_date AS 'Дата получения оценки', assessments.semestr AS 'Семестр', subjects.subject_name AS 'Название предмета', lectors.first_name AS 'Имя лектора', " +
                "lectors.last_name AS 'Фамилия лектора', lectors.father_name AS 'Отчество лектора' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id JOIN assessments ON students.student_id = assessments.student_id JOIN lectors_groups_subjects " +
                "ON assessments.lector_group_subject_id = lectors_groups_subjects.lector_group_subject_id JOIN lectors " +
                "ON lectors_groups_subjects.lector_id = lectors.lector_id JOIN subjects " +
            "ON lectors_groups_subjects.subject_id = subjects.subject_id ", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

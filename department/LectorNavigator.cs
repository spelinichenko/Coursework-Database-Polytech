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
    public partial class LectorNavigator : Form
    {
        SqlConnection conn;
        int id;
        public LectorNavigator(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
        }

        private void LectorNavigator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LectorsForms lectorsForms = new LectorsForms(id, conn);
            lectorsForms.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateLectorsInfo updateLectorsInfo = new UpdateLectorsInfo(id, conn);
            updateLectorsInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySubjectsLector mySubjectsLector = new MySubjectsLector(conn, id);
            mySubjectsLector.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDescriptionSubjectsLector addDescriptionSubjectsLector = new AddDescriptionSubjectsLector(id, conn);
            addDescriptionSubjectsLector.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT group_id AS 'Идентификатор группы', group_number AS 'Номер группы' , " +
                "count_person AS 'Количество человек', date_begin " +
                "AS 'Дата начала обучения' FROM groups", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', groups.group_number AS 'Номер группы', " +
                "subjects.subject_name AS 'Предмет' FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects ON " +
                "lectors_groups_subjects.subject_id = subjects.subject_id WHERE lectors.lector_id=" + id + " ORDER BY group_number", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowStudentSpecificGroup showStudentSpecificGroup = new ShowStudentSpecificGroup(conn);
            showStudentSpecificGroup.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowAssessmentSpecificStudent showAssessmentSpecificStudent = new ShowAssessmentSpecificStudent(conn);
            showAssessmentSpecificStudent.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddAssessmentLector addAssessmentLector = new AddAssessmentLector(id, conn);
            addAssessmentLector.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UpdateAssessmentByLector updateAssessmentByLector = new UpdateAssessmentByLector(id, conn);
            updateAssessmentByLector.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ShowTimetable showTimetable = new ShowTimetable(conn);
            showTimetable.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AddTimetableByLector addTimetableByLector = new AddTimetableByLector(id, conn);
            addTimetableByLector.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UpdateTimetableByLector updateTimetableByLector = new UpdateTimetableByLector(id, conn);
            updateTimetableByLector.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ShowSpecificStudentByLector showSpecificStudentByLector = new ShowSpecificStudentByLector(id, conn);
            showSpecificStudentByLector.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ShowAllStudents showAllStudents = new ShowAllStudents(conn);
            showAllStudents.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ShowAllLectors showAllLectors = new ShowAllLectors(conn);
            showAllLectors.Show();
        }
    }
}

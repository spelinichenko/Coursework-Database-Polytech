using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace department
{
    public partial class NavigationAdmin : Form
    {
        SqlConnection conn;
        string group;
        public NavigationAdmin(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void NavigationAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator administrator = new Administrator(conn);
            administrator.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddLector addLector = new AddLector(conn);
            addLector.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent(conn);
            addStudent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Showing showing = new Showing(conn);
            showing.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addGroup addGroup = new addGroup(conn);
            addGroup.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddLector addLector = new AddLector(conn);
            addLector.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent(conn);
            addStudent.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addGroup addGroup = new addGroup(conn);
            addGroup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowAllLectors showAllLectors = new ShowAllLectors(conn);
            showAllLectors.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowAllStudents showAllStudents = new ShowAllStudents(conn);
            showAllStudents.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
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
            AddSubject addSubject = new AddSubject(conn);
            addSubject.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT subject_id AS 'Идентификатор предмета', subject_name AS 'Название предмета', subject_description AS 'Описание предмета' " +
                "FROM subjects", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateSubject updateSubject = new UpdateSubject(conn);
            updateSubject.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddLectorsGroups addLectorsGroups = new AddLectorsGroups(conn);
            addLectorsGroups.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', groups.group_number AS 'Номер группы', subjects.subject_name AS 'Предмет' FROM " +
                "lectors JOIN lectors_groups_subjects ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects ON lectors_groups_subjects.subject_id = subjects.subject_id ", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView3.DataSource = dataTable;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AddAssessment addAssessment = new AddAssessment(conn);
            addAssessment.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UpdateAssessment updateAssessment = new UpdateAssessment(conn);
            updateAssessment.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ShowAllAssessments showAllAssessments = new ShowAllAssessments(conn);
            showAllAssessments.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ShowStudentSpecificAssessment showStudentSpecificAssessment = new ShowStudentSpecificAssessment(conn);
            showStudentSpecificAssessment.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ShowStudentsThatNoHaveAssessment showStudentsThatNoHaveAssessment = new ShowStudentsThatNoHaveAssessment(conn);
            showStudentsThatNoHaveAssessment.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ShowAssessmentSpecificStudent showAssessmentSpecificStudent = new ShowAssessmentSpecificStudent(conn);
            showAssessmentSpecificStudent.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ShowAssessmentSpecificStudentSpecirficSubject showAssessmentSpecificStudentSpecirficSubject = new ShowAssessmentSpecificStudentSpecirficSubject(conn);
            showAssessmentSpecificStudentSpecirficSubject.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AddTimetable addTimetable = new AddTimetable(conn);
            addTimetable.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            UpdateTimetable updateTimetable = new UpdateTimetable(conn);
            updateTimetable.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ShowTimetable showTimetable = new ShowTimetable(conn);
            showTimetable.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ShowTimetablesSpecific showTimetablesSpecific = new ShowTimetablesSpecific(conn);
            showTimetablesSpecific.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DeleteTimetables deleteTimetables = new DeleteTimetables(conn);
            deleteTimetables.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DeleteSubject deleteSubject = new DeleteSubject(conn);
            deleteSubject.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            AllLectorsAndDataAuth allLectorsAndDataAuth = new AllLectorsAndDataAuth(conn);
            allLectorsAndDataAuth.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AllStudentsDataAuth allStudentsDataAuth = new AllStudentsDataAuth(conn);
            allStudentsDataAuth.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AllDataAuth allDataAuth = new AllDataAuth(conn);
            allDataAuth.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            AllStudentsAndGroups allStudentsAndGroups = new AllStudentsAndGroups(conn);
            allStudentsAndGroups.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            GroupSubject groupSubject = new GroupSubject(conn);
            groupSubject.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            LectorsAndGroups lectorsAndGroups = new LectorsAndGroups(conn);
            lectorsAndGroups.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            LectorsAndSubjects lectorsAndSubjects = new LectorsAndSubjects(conn);
            lectorsAndSubjects.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(conn);
            updateStudent.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            UpdateLector updateLector = new UpdateLector(conn);
            updateLector.Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ShowAllLectors showAllLectors = new ShowAllLectors(conn);
            showAllLectors.Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ShowAllStudents showAllStudents = new ShowAllStudents(conn);
            showAllStudents.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddSubject addSubject = new AddSubject(conn);
            addSubject.Show();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            AVGassessments aVGassessments = new AVGassessments(conn);
            aVGassessments.Show();
        }
    }
}

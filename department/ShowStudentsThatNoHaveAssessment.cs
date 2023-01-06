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
    public partial class ShowStudentsThatNoHaveAssessment : Form
    {
        SqlConnection conn;
        public ShowStudentsThatNoHaveAssessment(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ShowStudentsThatNoHaveAssessment_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', students.education_form AS 'Форма обучения', students.email AS 'Email', groups.group_number " +
                "AS 'Номер группы' FROM students JOIN groups ON students.group_id = groups.group_id " +
                "WHERE NOT EXISTS(SELECT * FROM assessments WHERE assessments.student_id = students.student_id)", conn);
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

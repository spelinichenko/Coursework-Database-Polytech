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
    public partial class AVGassessments : Form
    {
        SqlConnection conn;
        public AVGassessments(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AVGassessments_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT groups.group_number AS 'Номер группы', AVG(assessment/1.0) AS 'Средняя оценка по всей группе' " +
                "FROM assessments JOIN students ON students.student_id = assessments.student_id JOIN groups " +
                "ON students.group_id = groups.group_id " +
                "GROUP BY groups.group_id, groups.group_number", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

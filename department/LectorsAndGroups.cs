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
    public partial class LectorsAndGroups : Form
    {
        SqlConnection conn;
        public LectorsAndGroups(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void LectorsAndGroups_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT lectors.first_name AS 'Имя', lectors.last_name AS 'Фамилия', " +
                "lectors.father_name AS 'Отчество', groups.group_number AS 'Номер группы', " +
                "subjects.subject_name AS 'Предмет' FROM lectors JOIN lectors_groups_subjects " +
                "ON lectors.lector_id = lectors_groups_subjects.lector_id JOIN groups " +
                "ON lectors_groups_subjects.group_id = groups.group_id JOIN subjects ON lectors_groups_subjects.subject_id = subjects.subject_id", conn);
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

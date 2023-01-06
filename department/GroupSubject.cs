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
    public partial class GroupSubject : Form
    {
        SqlConnection conn;
        public GroupSubject(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupSubject_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DISTINCT subjects.subject_name AS 'Название предмета', " +
                "subject_description AS 'Описание предмета', groups.group_number AS 'Номер группы' " +
                "FROM subjects JOIN lectors_groups_subjects " +
                "ON subjects.subject_id = lectors_groups_subjects.subject_id JOIN groups ON " +
                "lectors_groups_subjects.group_id = groups.group_id ORDER BY groups.group_number", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

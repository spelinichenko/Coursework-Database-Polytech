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
    public partial class AllStudentsAndGroups : Form
    {
        SqlConnection conn;
        public AllStudentsAndGroups(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void AllStudentsAndGroups_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', groups.group_number AS 'Номер группы' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id ORDER BY group_number", conn);
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

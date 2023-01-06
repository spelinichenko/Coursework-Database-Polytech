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
    public partial class MyOdnogroups : Form
    {
        SqlConnection conn;
        int id;
        public MyOdnogroups(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void MyOdnogroups_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT students.first_name AS 'Имя', students.last_name AS 'Фамилия', " +
                "students.father_name AS 'Отчество', students.email  AS 'Почта' FROM students JOIN groups " +
                "ON students.group_id = groups.group_id WHERE groups.group_id = (SELECT group_id FROM students WHERE student_id=" + id + ")", conn);
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

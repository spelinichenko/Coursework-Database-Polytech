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
    public partial class AllGroups : Form
    {
        SqlConnection conn;
        public AllGroups(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllGroups_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT group_number AS 'Номер группы', count_person AS 'Количество человек', date_begin " +
                "AS 'Дата начала обучения' FROM groups", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

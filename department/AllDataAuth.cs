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
    public partial class AllDataAuth : Form
    {
        SqlConnection conn;
        public AllDataAuth(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllDataAuth_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT logins.login AS 'Логин', logins.password 'Пароль', " +
                "logins.role AS 'Роль' FROM logins WHERE role IN('student','lector')", conn);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}

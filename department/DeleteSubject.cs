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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace department
{
    public partial class DeleteSubject : Form
    {
        SqlConnection conn;
        public DeleteSubject(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }


        private void fillComboBox1()
        {
            string query = "SELECT subject_name FROM subjects";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "subject_name";
            comboBox1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteSubject_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("delete_subjectv1 @subject_name='" + comboBox1.Text.ToString() + "'");
            SqlCommand sqlCommand = new SqlCommand(query.ToString(), conn);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Предмет удален");
            conn.Close();
        }
    }
}

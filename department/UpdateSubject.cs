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
    public partial class UpdateSubject : Form
    {
        SqlConnection conn;
        public UpdateSubject(SqlConnection conn)
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
        private void UpdateSubject_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder check = new StringBuilder();
            conn.Open();
            check.Append("SELECT COUNT(*) FROM subjects WHERE subject_name='" + textBox1.Text.ToString() + "'");
            SqlCommand sqlCommand = new SqlCommand(check.ToString(), conn);
            int checkInt = (Int32)sqlCommand.ExecuteScalar();
            conn.Close();
            if (checkInt == 1)
            {
                MessageBox.Show("Предмет с таким названием уже есть");
            }
            else if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Если хотите изменить, введите новое название предмета");
            }
            else
            {
                StringBuilder query = new StringBuilder();
                conn.Open();
                query.Append("exec update_subject @subject_name='" + textBox1.Text.ToString() + "'" + "," + "@subject_description='" +
                    textBox2.Text.ToString() + "'" + "," + "@oldSubject_name='" + comboBox1.Text.ToString() + "'");
                var cmd = new SqlCommand(query.ToString(), conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Предмет изменен");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM subjects WHERE subject_name='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string description = sqlDataReader["subject_description"].ToString();
                textBox2.Text = description;
            }
            conn.Close();
        }
    }
}

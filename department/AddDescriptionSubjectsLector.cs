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
    public partial class AddDescriptionSubjectsLector : Form
    {
        SqlConnection conn;
        int id;
        public AddDescriptionSubjectsLector(int id, SqlConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn;
        }

        private void fillComboBox1()
        {
            string query = "SELECT DISTINCT subjects.subject_name FROM subjects JOIN lectors_groups_subjects " +
                "ON lectors_groups_subjects.subject_id = subjects.subject_id " +
                "WHERE lector_id=" + id;
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBox1.DisplayMember = "subject_name";
            comboBox1.DataSource = dataTable;
        }
        private void AddDescriptionSubjectsLector_Load(object sender, EventArgs e)
        {
            fillComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand1 = new SqlCommand("SELECT subjects.subject_description FROM subjects " +
                "WHERE subject_name='" + comboBox1.Text.ToString() + "'", conn);
            conn.Open();
            SqlDataReader dr = sqlCommand1.ExecuteReader();
            while (dr.Read())
            {
                string description = dr["subject_description"].ToString();
                textBox1.Text = description;
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            conn.Open();
            query.Append("add_description @subject='" + comboBox1.Text.ToString() + "'" + "," + "@description='" + textBox1.Text.ToString() + "'");
            SqlCommand sqlCommand1 = new SqlCommand(query.ToString(), conn);
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("Описание предмета изменено");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

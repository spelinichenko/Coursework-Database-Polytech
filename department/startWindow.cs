using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace department
{
    public partial class startWindow : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=STEPANPELINICHE\MSSQLSERVER01;Initial Catalog=UniversityDepartment;Integrated Security=True");
        public startWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator administrator = new Administrator(conn);
            administrator.Show();
            this.Hide();
        }
    }
}

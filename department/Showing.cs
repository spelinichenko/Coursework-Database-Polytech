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
    public partial class Showing : Form
    {
        SqlConnection conn;
        public Showing(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Showing_Load(object sender, EventArgs e)
        {

        }
    }
}

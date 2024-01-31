using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class DepoDurum : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public DepoDurum()
        {
            InitializeComponent();
            database.fillGrid(dataGridView1, "v_ÜrünTotal where username='" + LoginForm.oturum + "'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
            var al = new afterlogin();
            al.Show();
        }
    }
}
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
            database.fillGrid(dataGridView1, "v_ÜrünTotal");

        }

        private void DepoDurum_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exampleDataSet.v_ÜrünTotal' table. You can move, or remove it, as needed.
            this.v_ÜrünTotalTableAdapter.Fill(this.exampleDataSet.v_ÜrünTotal);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            afterlogin al=new afterlogin();
            al.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

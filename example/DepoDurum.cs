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
            searchText.TextChanged += searchText_TextChanged;
        }

        //İnstantly arama yapmasını sağlayan event
        private void searchText_TextChanged(object sender, EventArgs e)
        {
            searchbutton_Click(sender, e); // Arama butonunun click olayını çağırın
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            var al = new afterlogin();
            al.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }


        //Arama yapılan yer
        private void searchbutton_Click(object sender, EventArgs e)
        {
            var searchTerm = searchText.Text.ToLower();

            var dt = dataGridView1.DataSource as DataTable;
            if (dt != null)
            {
                // "ürünAdı" sütununda arama yap
                var dv = dt.DefaultView;
                dv.RowFilter = string.Format("ürünAdı LIKE '%{0}%'", searchTerm);
            }
        }
    }
}
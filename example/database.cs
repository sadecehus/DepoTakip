using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    internal class database
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";


        public static bool controlConnection()
        {
            //bağlı olunan databaseyi değiştirmek için alttaki sqlconnu değiştir
            using (conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Connection Unsuccesfull" + ex.Message);
                    return false;
                }
            }
        }

        public static DataGridView fillGrid(DataGridView ourDataGridView, string tableName)
        {
            try
            {
                conn = new SqlConnection(sqlconn);
                adapter = new SqlDataAdapter("select * from " + tableName, conn);
                ds = new DataSet();
                conn.Open();
                adapter.Fill(ds, tableName);
                ourDataGridView.DataSource = ds.Tables[tableName];
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return ourDataGridView;
        }
    }
}
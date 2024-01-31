using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class addProductForm : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";


        public addProductForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = "INSERT INTO tbl_products (ürünAdı) VALUES (@ürünAdı)";
                using (var conn = new SqlConnection(sqlconn))
                {
                    using (var cmd = new SqlCommand(sorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ürünAdı", textBox1.Text);
                        conn.Open();
                        var result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Ürün Eklendi...");

                            Close();

                            var wf = new WelcomeForm(afterlogin.nameofuser);
                            wf.Show();
                        }
                        else
                        {
                            MessageBox.Show("!Ürün Eklenemedi!");
                        }
                    }
                }

                {
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            var welcomeForm = new WelcomeForm(afterlogin.nameofuser);
            welcomeForm.Show();
        }
    }
}
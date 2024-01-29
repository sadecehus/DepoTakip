using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class SignupForm : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public SignupForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = "INSERT INTO tbl_user_login (username, password, name_surname) VALUES (@username, @password, @fullname)";
                using (var conn = new SqlConnection(sqlconn))
                {
                    using (var cmd = new SqlCommand(sorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                        cmd.Parameters.AddWithValue("@password", sifreleme.md5sifreleme(passwordTextBox.Text));
                        cmd.Parameters.AddWithValue("@fullname", nameTextbox.Text);

                        conn.Open();
                        var result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Üye oldunuz...");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Bir sorun çıktı");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
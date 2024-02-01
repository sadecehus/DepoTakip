using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class usersettings : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public usersettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            var afterlogin = new afterlogin();
            afterlogin.Show();
        }

        public void exsifrekontrol()
        {
            var sorgu = "Select password from tbl_user_login where username = @username AND password = @password";
            using (var conn = new SqlConnection(sqlconn))
            {
                using (var cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    cmd.Parameters.AddWithValue("@password", sifreleme.md5sifreleme(textBox1.Text));
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var sorgu2 = "UPDATE tbl_user_login SET password = @newpassword WHERE username = @username";
                            using (var conn2 = new SqlConnection(sqlconn))
                            {
                                using (var cmd2 = new SqlCommand(sorgu2, conn2))
                                {
                                    cmd2.Parameters.AddWithValue("@newpassword", sifreleme.md5sifreleme(textBox2.Text));
                                    cmd2.Parameters.AddWithValue("@username", LoginForm.oturum);
                                    conn2.Open();
                                    var result = cmd2.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        MessageBox.Show("Şifre Değiştirildi Tekrar Giriş Yapın");
                                        Close();
                                        var lf = new LoginForm();
                                        lf.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Bir Hata Oluştu");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mevcut şifre yanlış.");
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text) exsifrekontrol();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text) exsifrekontrol();
            else
                MessageBox.Show("Girilen Şifreler Aynı Değil");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            var afterlogin = new afterlogin();
            afterlogin.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
            var afterlogin = new afterlogin();
            afterlogin.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text) exsifrekontrol();
            else
                MessageBox.Show("Girilen Şifreler Aynı Değil");
        }
    }
}
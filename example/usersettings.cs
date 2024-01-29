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
            this.Close();
            afterlogin afterlogin = new afterlogin();
            afterlogin.Show();
        }
        public void exsifrekontrol()
        {
            var sorgu = "Select password from tbl_user_login where username = @username AND password = @password";
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    cmd.Parameters.AddWithValue("@password", sifreleme.md5sifreleme(textBox1.Text));
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var sorgu2 = "UPDATE tbl_user_login SET password = @newpassword WHERE username = @username";
                            using (SqlConnection conn2 = new SqlConnection(sqlconn))
                            {
                                using (SqlCommand cmd2 = new SqlCommand(sorgu2, conn2))
                                {
                                    cmd2.Parameters.AddWithValue("@newpassword", sifreleme.md5sifreleme(textBox2.Text));
                                    cmd2.Parameters.AddWithValue("@username", LoginForm.oturum);
                                    conn2.Open();
                                    var result = cmd2.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        MessageBox.Show("Şifre Değiştirildi Tekrar Giriş Yapın");
                                        this.Close();
                                        LoginForm lf = new LoginForm();
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
            if (textBox2.Text == textBox3.Text)
            {
                exsifrekontrol();
            }
        }
    }
}

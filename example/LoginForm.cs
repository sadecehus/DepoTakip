using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class LoginForm : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public static string oturum;

        public LoginForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyPress += LoginForm_KeyPress;
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer basılan tuş Enter ise
            if (e.KeyChar == (char)Keys.Enter)
                // LoginButton_Click metodunu çağır
                LoginButton_Click(this, new EventArgs());

            if (e.KeyChar == (char)Keys.Escape) exitButton_Click(this, new EventArgs());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var sorgu = "SELECT name_surname FROM tbl_user_login WHERE username = @username AND password = @password";
            using (conn = new SqlConnection(sqlconn))
            {
                using (cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@username", usernameTextbox.Text);
                    cmd.Parameters.AddWithValue("@password", sifreleme.md5sifreleme(passwordTextbox.Text));

                    conn.Open();
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var nameSurname = reader["name_surname"].ToString();
                            MessageBox.Show("Giriş Başarılı...");
                            oturum = usernameTextbox.Text;
                            var al = new afterlogin();
                            var wf = new WelcomeForm(nameSurname);
                            Hide();
                            al.Show();
                            // wf.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                            passwordTextbox.Clear();
                            passwordTextbox.Focus();
                        }
                    }
                }
            }
        }


        private void signupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var sf = new SignupForm();
            sf.ShowDialog();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
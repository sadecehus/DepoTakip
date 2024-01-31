using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class afterlogin : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public static string nameofuser;

        public afterlogin()
        {
            InitializeComponent();
            fetchTheName();
            label2.Text = nameofuser;
        }

        private void fetchTheName()
        {
            var sorgu = "Select name_surname from tbl_user_login where username=@username";
            using (conn = new SqlConnection(sqlconn))
            {
                using (cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    conn.Open();
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            nameofuser = reader["name_surname"].ToString();
                        else
                            MessageBox.Show("Bulunamadı!");
                    }
                }
            }
        }

        private void afterlogin_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Hide();
            var wf = new WelcomeForm(nameofuser);
            wf.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Hide();
            var dd = new DepoDurum();
            dd.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var usersettings = new usersettings();
            Hide();
            usersettings.Show();
        }
    }
}
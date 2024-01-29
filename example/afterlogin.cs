using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            string sorgu = "Select name_surname from tbl_user_login where username=@username";
            using (conn = new SqlConnection(sqlconn))
            {
                using (cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@username",LoginForm.oturum);
                    conn.Open();
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nameofuser = reader["name_surname"].ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("Bulunamadı!");
                        }

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
            this.Hide();
            WelcomeForm wf = new WelcomeForm(nameofuser);
            wf.Show();
        }
    }
}

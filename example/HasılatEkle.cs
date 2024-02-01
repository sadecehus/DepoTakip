using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class HasılatEkle : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";

        public HasılatEkle()
        {
            InitializeComponent();
            aktifkullanici.Text = afterlogin.nameofuser;
        }


        private void HasılatEkle_Load(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(sqlconn))
            {
                var sorgu = "Select ürünAdı from tbl_products";
                var command = new SqlCommand(sorgu, conn);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) comboBox1.Items.Add(reader["ürünAdı"]);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu =
                "INSERT INTO tbl_islem (product, product_count, product_pricie, islemTarih, username, islemAciklama) VALUES (@ürünad, @ürünmiktar, 0,@date,@username, 'Hasılat Eklendi');";
            using (var conn = new SqlConnection(sqlconn))
            {
                using (var cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@ürünad", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ürünmiktar", float.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Hasılat Eklendi...");

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
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Close();
            var wf = new WelcomeForm(afterlogin.nameofuser);
            wf.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            var sorgu =
                "INSERT INTO tbl_islem (product, product_count, product_pricie, islemTarih, username, islemAciklama) VALUES (@ürünad, @ürünmiktar, 0,@date,@username, 'Hasılat Eklendi');";
            using (var conn = new SqlConnection(sqlconn))
            {
                using (var cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@ürünad", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ürünmiktar", float.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Hasılat Eklendi...");

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
        }

        private void label4_Click(object sender, EventArgs e)
        {
            guna2PictureBox3_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            guna2PictureBox2_Click(sender, e);
        }
    }
}
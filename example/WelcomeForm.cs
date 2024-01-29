using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace example
{
    public partial class WelcomeForm : Form
    {
        private static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapter;
        private static DataSet ds;
        private static SqlDataReader reader;

        public static string sqlconn =
            "Data Source=HÜSEYIN\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True";


        public WelcomeForm(string nameSurname)
        {
            InitializeComponent();
            nameLabel.Text = nameSurname;
            DisplayUsername(nameSurname);
        }

        private void DisplayUsername(string nameSurname)
        {
            var sqlQuery = "SELECT username FROM tbl_user_login WHERE name_surname = @nameSurname";

            using (conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                using (cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nameSurname", afterlogin.nameofuser);
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var username = reader["username"].ToString();
                            label3.Text = username;
                        }
                        else
                        {
                            MessageBox.Show("Username Not Found!");
                        }
                    }
                }
            }
        }

        //Form İlk yüklenirken çağırılır.
        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(sqlconn))
            {
                var sorgu = "Select * from tbl_products";
                var command = new SqlCommand(sorgu, conn);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) ürünAdıComboBox.Items.Add(reader["ürünAdı"]);
                conn.Close();
            }

            using (conn = new SqlConnection(sqlconn))
            {
                var sorgu = "Select Round(TotalBakiye,2) from v_TotalBakiye";
                var command = new SqlCommand(sorgu, conn);
                conn.Open();
                reader = command.ExecuteReader();
                if (reader.Read()) totalCountLabel.Text = reader[0].ToString();

                conn.Close();
            }

            database.fillGrid(dataGridView1, "tbl_islem");
            ürünAdıComboBox.SelectedIndexChanged += ürünAdıComboBox_SelectedIndexChanged;
        }

        //İşlemlerden sonra dataGridViewi günceller
        private void UpdateDataGridView()
        {
            try
            {
                using (conn = new SqlConnection(sqlconn))
                {
                    var sorgu = "SELECT * FROM tbl_islem";
                    var command = new SqlCommand(sorgu, conn);
                    var adapter = new SqlDataAdapter(command);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGridView güncelleme hatası: " + ex.Message);
            }
        }

        //Updates totalCountLabel after the buy or sell operations
        private void UpdateTotalCountLabel()
        {
            try
            {
                using (conn = new SqlConnection(sqlconn))
                {
                    var sorgu = "Select Round(TotalBakiye,2) from v_TotalBakiye";
                    var command = new SqlCommand(sorgu, conn);
                    conn.Open();
                    var result = command.ExecuteScalar();
                    totalCountLabel.Text = result != null ? result.ToString() : "0";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Total count label güncelleme hatası: " + ex.Message);
            }
        }

        //This function call when we pressed the alisBox Button
        private void alisBox_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || fiyatTextbox.Text == "" || checkercombobox())
                MessageBox.Show("Ürün miktarı veya fiyat Boş olamaz");
            else
                try
                {
                    var sorgu =
                        "INSERT INTO tbl_islem (product, product_count, product_pricie, islemTarih, islemAciklama, username, islemBakiye) VALUES (@product, @product_count, @product_pricie, @islemTarih, @islemAciklama, @username, @islemBakiye)";
                    using (var conn = new SqlConnection(sqlconn))
                    {
                        using (var cmd = new SqlCommand(sorgu, conn))
                        {
                            cmd.Parameters.AddWithValue("@product", ürünAdıComboBox.Text);
                            cmd.Parameters.AddWithValue("@product_count",
                                float.Parse(textBox2.Text)); // Veri türü float olarak düzeltildi
                            cmd.Parameters.AddWithValue("@product_pricie",
                                -float.Parse(fiyatTextbox.Text)); // Veri türü float olarak düzeltildi
                            cmd.Parameters.AddWithValue("@islemTarih", DateTime.Now);
                            cmd.Parameters.AddWithValue("@islemAciklama", richTextBox1.Text);
                            cmd.Parameters.AddWithValue("@username", label3.Text);
                            cmd.Parameters.AddWithValue("@islemBakiye",
                                -float.Parse(textBox2.Text) * float.Parse(fiyatTextbox.Text));
                            conn.Open();

                            //Total bakiye kontrolü yapılıyor.
                            if (float.Parse(totalCountLabel.Text) > 0 &&
                                float.Parse(textBox2.Text) * float.Parse(fiyatTextbox.Text) <=
                                float.Parse(totalCountLabel.Text))
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Alış Başarılı");
                                UpdateDataGridView();
                                UpdateTotalCountLabel();
                                //UPDATE EKLENECEK PRODUCTCOUNTLABEL İİÇİNN
                            }
                            else
                            {
                                MessageBox.Show("Yeterli Paranız Yok");
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Hata: Yetersiz Bakiye");
                }
        }

        private void satisBox_Click(object sender, EventArgs e)
        {
            var currentStock = 0;
            var sorgu2 = "Select SUM (product_count) from tbl_islem where product=@product";
            using (var conn = new SqlConnection(sqlconn))
            {
                using (var cmd = new SqlCommand(sorgu2, conn))
                {
                    cmd.Parameters.AddWithValue("@product", ürünAdıComboBox.Text);
                    conn.Open();
                    var stockResult = cmd.ExecuteScalar();
                    if (currentStock == null || stockResult == DBNull.Value)
                    {
                    }
                    else
                    {
                        currentStock = Convert.ToInt32(stockResult);
                        conn.Close();
                    }
                }
            }

            if (textBox2.Text == "" || fiyatTextbox.Text == "" || checkercombobox())
                MessageBox.Show("Ürün miktarı veya fiyat Boş olamaz");
            else if (currentStock >= int.Parse(textBox2.Text))
                try
                {
                    var sorgu =
                        "INSERT INTO tbl_islem (product, product_count, product_pricie, islemTarih, islemAciklama, username, islemBakiye) VALUES (@product, @product_count, @product_pricie, @islemTarih, @islemAciklama, @username, @islemBakiye)";
                    using (var conn = new SqlConnection(sqlconn))
                    {
                        using (var cmd = new SqlCommand(sorgu, conn))
                        {
                            cmd.Parameters.AddWithValue("@product", ürünAdıComboBox.Text);
                            cmd.Parameters.AddWithValue("@product_count",
                                -float.Parse(textBox2.Text));
                            cmd.Parameters.AddWithValue("@product_pricie",
                                float.Parse(fiyatTextbox.Text));
                            cmd.Parameters.AddWithValue("@islemTarih", DateTime.Now);
                            cmd.Parameters.AddWithValue("@islemAciklama", richTextBox1.Text);
                            cmd.Parameters.AddWithValue("@username", label3.Text);
                            cmd.Parameters.AddWithValue("@islemBakiye",
                                float.Parse(textBox2.Text) * float.Parse(fiyatTextbox.Text));
                            conn.Open();
                            var result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Satış Başarılı");
                                UpdateDataGridView();
                                UpdateTotalCountLabel();
                            }
                            else
                            {
                                MessageBox.Show("Bir sorun çıktı");
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Hata: " + exception.Message);
                }
            else
                MessageBox.Show("HATA: ELİNİZDE YETERLİ ÜRÜN YOK");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addProductForm = new addProductForm();
            addProductForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ürünAdıComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ürünAdıComboBox.SelectedIndex != -1)
            {
                var selectedProduct = ürünAdıComboBox.SelectedItem.ToString();
                GüncelleProductNameAndCount(selectedProduct);
            }
        }

        private void GüncelleProductNameAndCount(string productName)
        {
            using (conn = new SqlConnection(sqlconn))
            {
                var sorgu = "SELECT SUM(product_count) FROM tbl_islem WHERE product = @productName";
                var command = new SqlCommand(sorgu, conn);
                command.Parameters.AddWithValue("@productName", productName);
                conn.Open();
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    productnamelabel.Text = productName;
                    productcountlabel.Text = result.ToString();
                }

                conn.Close();
            }
        }

        private bool checkercombobox()
        {
            if (ürünAdıComboBox.Text == "") return true;

            return false;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
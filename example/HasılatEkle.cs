﻿using System;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            WelcomeForm wf = new WelcomeForm(afterlogin.nameofuser);
            wf.Show();
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
            var sorgu = "INSERT INTO tbl_islem (product, product_count, product_pricie, islemTarih, username) VALUES (@ürünad, @ürünmiktar, 0,@date,@username);";
            using (var conn = new SqlConnection(sqlconn))
            {
                using (var cmd = new SqlCommand(sorgu,conn))
                {
                    cmd.Parameters.AddWithValue("@ürünad",comboBox1.Text);
                    cmd.Parameters.AddWithValue("@ürünmiktar",float.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@username", LoginForm.oturum);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    conn.Open();
                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Hasılat Eklendi...");

                        this.Close();
                        WelcomeForm wf = new WelcomeForm(afterlogin.nameofuser);
                        wf.Show();
                    }
                    else
                    {
                        MessageBox.Show("!Ürün Eklenemedi!");
                    }

                }
                
            }
        }
    }
}

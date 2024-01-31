using System;
using System.Windows.Forms;

namespace example
{
    public partial class SifrelemePaneli : Form
    {
        public SifrelemePaneli()
        {
            InitializeComponent();
        }

        private void sifreBox_TextChanged(object sender, EventArgs e)
        {
            md5Box.Text = sifreleme.md5sifreleme(sifreBox.Text);
            md5lengthlabel.Text = md5Box.TextLength.ToString();
            shaBox.Text = sifreleme.shaSifreleme(sifreBox.Text);
            shalengthlabel.Text = shaBox.Text.Length.ToString();
        }
    }
}
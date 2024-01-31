using System.Windows.Forms;

namespace example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Rapor1.SetParameterValue(0, LoginForm.oturum);
        }
    }
}
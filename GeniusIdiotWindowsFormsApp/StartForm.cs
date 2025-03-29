using System;
using System.Windows.Forms;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class StartForm : Form
    {
        public string Username {  get; set; }

        public StartForm()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (userNameMaskedTextBox.Text ==  string.Empty)
            {
                MessageBox.Show("Введите ваше имя!");
                return;
            }
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Username = userNameMaskedTextBox.Text;
            if (Username ==  string.Empty)
            {
                MessageBox.Show("Введите ваше имя!");
                return;
            }
            Close();
        }
    }
}

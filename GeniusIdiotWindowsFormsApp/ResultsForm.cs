using GeniusIdiotClassLibrary;
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
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            var users = UserResultsStorage.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = users[i].Name;
                dataGridView.Rows[i].Cells[1].Value = users[i].CountRightAnswers;
                dataGridView.Rows[i].Cells[2].Value = users[i].Diagnose;
            }
        }
    }
}

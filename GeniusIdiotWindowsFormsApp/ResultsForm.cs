using System;
using GeniusIdiot.Common;
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
            var results = UserResultsStorage.GetAll();
            foreach (var result in  results)
            {
                resultsDataGridView.Rows.Add(result.Name, result.CountRightAnswers, result.Diagnose);
            }
        }
    }
}

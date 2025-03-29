using System;
using System.Collections.Generic;
using GeniusIdiot.Common;
using System.Windows.Forms;
using GeniusIdiotClassLibrary;

namespace GeniusIdiotWindowsFormsApp
{
    public partial class MainForm : Form
    {
        Game game { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startForm = new StartForm();
            startForm.ShowDialog();

            var user = new User(startForm.userNameMaskedTextBox.Text);
            game = new Game(user);

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            questionTextLabel.Text = game.GetNextQuestion().Text;
            questionNumberLabel.Text = game.GetQuestionNumberText();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(userAnswerTextBox.Text, out int userAnswer, out string errorMessage);
            if (!parsed)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                game.AcceptAnswer(userAnswer);

                if (game.End())
                {
                    var message = game.CalculateDiagnose();
                    MessageBox.Show(message);
                }
                else
                {
                    ShowNextQuestion();
                }
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

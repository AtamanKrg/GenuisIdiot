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
    public partial class MainForm : Form
    {
        private List<Question> questions {  get; set; }
        private Question currentQuestion { get; set; }
        private int countQuestions { get; set; }
        private User user { get; set; }
        private int questionNumber { get; set; } = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionsStorage.GetAll();
            countQuestions = questions.Count;
            user = new User("Неизвестно");

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];

            questionTextLabel.Text = currentQuestion.Text;

            questionNumber++;
            questionNumberLabel.Text = $"Вопрос №{questionNumber}";

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);

            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }

            questions.Remove(currentQuestion);

            var endGame = questions.Count == 0;
            if (endGame)
            {
                user.Diagnose = DiagnoseCalculator.Calculate(countQuestions, user);
                MessageBox.Show($"{user.Name}, ваш диагноз: {user.Diagnose}");
                return;
            }

            ShowNextQuestion();
        }
    }
}

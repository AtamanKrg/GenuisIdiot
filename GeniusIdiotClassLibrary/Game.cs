using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot.Common
{
    public class Game
    {
        User User { get; set; }
        List<Question> questions { get; set; }
        Question currentQuestion { get; set; }
        public int countQuestions { get; set; }
        int questionNumber { get; set; } = 0;
        public Game(User user)
        { 
            User = user;
            questions = QuestionsStorage.GetAll();
            countQuestions = questions.Count;
        }

        public Question GetNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];

            questionNumber++;
            return currentQuestion;
        }
        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                User.AcceptRightAnswer();
            }

            questions.Remove(currentQuestion);
        }
        public string GetQuestionNumberText()
        {
            return $"Вопрос №{questionNumber}";
        }

        public bool End()
        {
            return questions.Count == 0;
        }

        public string CalculateDiagnose()
        {
            User.Diagnose = DiagnoseCalculator.Calculate(countQuestions, User);
            UserResultsStorage.Save(User);

            return $"{User.Name}, ваш диагноз: {User.Diagnose}";
        }
    }
}

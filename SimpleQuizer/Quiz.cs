using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;

        public Quiz()
        {
            Questions = new List<Question>();
        }
        #region DEBUG

        public static Quiz GetTestQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.QuastionText = "Для чего используется инжектор?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add("Для фильтрации выхлопных газов");
            q.Answers.Add("Для подачи топлива в камеру сгорания");
            q.Answers.Add("Нет");

            quiz.Questions.Add(q);

            return quiz;
          
            #endregion
        }
    }
}

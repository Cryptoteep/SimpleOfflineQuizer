using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;

        public Question currentQuestion => Questions[currentQuestionIndex];

        private int currentQuestionIndex;

        public Quiz()
        {
            Questions = new List<Question>();

        }

        public void NextQuestion()
        {

            if (currentQuestionIndex >= Questions.Count - 1) return;
            currentQuestionIndex++;
        }

        public void PriveusQuestion()
        {

            if (currentQuestionIndex <= 0) return;
            currentQuestionIndex--;
        }

        #region DEBUG

        public static Quiz GetTestQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.QuastionText = "Для чего используется инжектор?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("Для фильтрации газа", false));
            q.Answers.Add(new Answer("Для подачи топлива ", true));
            q.Answers.Add(new Answer("Для уменьшения сопротивления воздуха", false));
            q.Answers.Add(new Answer("Нет", false));

            quiz.Questions.Add(q);

            
            q = new Question();
            q.Number = 2;
            q.QuastionText = "Кто говорит Meow?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("Кот", true));
            q.Answers.Add(new Answer("Никто", false));
            q.Answers.Add(new Answer("Собака", false));
            q.Answers.Add(new Answer("Жираф", false));
            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 3;
            q.QuastionText = "Какого цвета трава летом?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("Зелёного", true));
            q.Answers.Add(new Answer("Синего", false));
            q.Answers.Add(new Answer("Розового", false));
            q.Answers.Add(new Answer("Белого", false));
            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 4;
            q.QuastionText = "Сколько дней в обычном году?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("366", false));
            q.Answers.Add(new Answer("365", true));
            q.Answers.Add(new Answer("360", false));
            q.Answers.Add(new Answer("350", false));
            quiz.Questions.Add(q);


            return quiz;
            #endregion
        }
    }
}

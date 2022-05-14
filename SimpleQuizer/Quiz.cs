using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public void Load(string path)
        {
            Deserialize(path);
        }
        public void Save(string path)
        {
            Serialize(path);
        }
        public void Serialize(string path)
        {
            Stream s = File.Open(path, FileMode.OpenOrCreate);

            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(s, Questions);
            s.Close();
        }
        public void Deserialize(string path)
        {
            Stream file = File.Open(path, FileMode.OpenOrCreate);

            BinaryFormatter binary = new BinaryFormatter();
            Questions = (List<Question>)binary.Deserialize(file);

            file.Close();
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


            
        }
        public static Quiz GetTestQuiz2()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.QuastionText = "Сколько длится неделя";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("24ч", false));
            q.Answers.Add(new Answer("7 дней ", true));
            q.Answers.Add(new Answer("10 дней", false));
            q.Answers.Add(new Answer("Нет", false));

            quiz.Questions.Add(q);


            q = new Question();
            q.Number = 2;
            q.QuastionText = "Кто говорит Мууу";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("Корова", true));
            q.Answers.Add(new Answer("Никто", false));
            q.Answers.Add(new Answer("Собака", false));
            q.Answers.Add(new Answer("Жираф", false));
            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 3;
            q.QuastionText = "Какого цвета небо?";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("Голубого", true));
            q.Answers.Add(new Answer("Синего", false));
            q.Answers.Add(new Answer("Розового", false));
            q.Answers.Add(new Answer("Белого", false));
            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 4;
            q.QuastionText = "Сколько дней в мае";
            q.Type = QuestionType.MultiChois;
            q.Answers.Add(new Answer("30", false));
            q.Answers.Add(new Answer("31", true));
            q.Answers.Add(new Answer("29", false));
            q.Answers.Add(new Answer("10", false));
            quiz.Questions.Add(q);


            return quiz;


           
        }
            #endregion
    }
}

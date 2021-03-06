using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleQuizer;

namespace SimpleQuizer.Viewer
{
    public partial class Form1 : Form
    {

        private List<Answer>userAnswers;
        private List<RadioButton> buttonControls;
        private QuizResult result;

        private Quiz currentQuiz;
        

        public Form1()

        {
            userAnswers = new List<Answer>();
            buttonControls = new List<RadioButton>();
            result = new QuizResult();
            InitializeComponent();
        }

        private void ShowResult()
        {
            result.allAnswers = currentQuiz.Questions.Count;
            QuizResultForm f = new QuizResultForm(result);
            f.Show();
        }

        private void CheckUserAnswers()
        {
            for (int i = 0; i< currentQuiz.currentQuestion.UserAnswers.Count; i++)
            {
                if(currentQuiz.currentQuestion.UserAnswers[i].correct == true)
                {
                    MessageBox.Show("Valid!");
                    result.validCountAnswer++;

                }
                if (currentQuiz.currentQuestion.Number == currentQuiz.Questions.Count)
                {
                    MessageBox.Show("КОнец теста");
                    ShowResult();
                }
            }
        }
        private void CheckQuestions()
        {
            GetUserInput();
            CheckUserAnswers();
            currentQuiz.NextQuestion();
            ShowQuestion(currentQuiz.currentQuestion);
        }
        private void GetUserInput()
        {
            userAnswers.Clear();

            //R button
            for(int i=0; i <buttonControls.Count; i++)
            {
                if(buttonControls[i].Checked == true)
                {
                    currentQuiz.currentQuestion.UserAnswers.Add(currentQuiz.currentQuestion.Answers[i]);
                }
            }

            result.quizQuestions.Add(currentQuiz.currentQuestion);


        }


            public void ShowQuestion(Question queston)
            {
            
            questionNumberLabel.Text = "Вопрос № " + queston.Number.ToString();
            questionTextBox.Text = queston.QuastionText;
            if(queston.Type == QuestionType.MultiChois )
            {
                questionInfoLabel.Text = "Выберите правильный  вариант ответа";
            }

            //Вёрстка таблицы
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
         
            int answerCount = queston.Answers.Count;
            tableLayoutPanel1.RowCount = answerCount;

            buttonControls.Clear();
            
            for (int i = 0; i < answerCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100/ answerCount));
                //Добавление контролов
                RadioButton r = new RadioButton();
                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0];
                t.Width = tableLayoutPanel1.GetColumnWidths()[1];
                t.Text = queston.Answers[i].text + " " + queston.Answers[i].correct.ToString();

                tableLayoutPanel1.Controls.Add(t, 1, i);
                tableLayoutPanel1.Controls.Add(r, 0, i);
                buttonControls.Add(r);
            }


        }
            
            



        #region DEBUG
        private void отрытьТестовыйКвизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentQuiz = Quiz.GetTestQuiz();
            ShowQuestion(currentQuiz.currentQuestion);
        }
        #endregion

        private void answerButtton_Click(object sender, EventArgs e)
        {
            CheckQuestions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(currentQuiz != null)
            {
                currentQuiz.NextQuestion();
                ShowQuestion(currentQuiz.currentQuestion);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentQuiz != null)
            {
                currentQuiz.PriveusQuestion();
                ShowQuestion(currentQuiz.currentQuestion);
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz.GetTestQuiz2().Save("D:\\1.txt");
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                currentQuiz = new Quiz();
                currentQuiz.Load(openFileDialog1.FileName);
            }
            ShowQuestion( currentQuiz.currentQuestion);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

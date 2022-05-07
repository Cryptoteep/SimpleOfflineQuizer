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
        private Question currentQuestion;

        private Quiz currentQuiz;

        public Form1()

        {
            userAnswers = new List<Answer>();
            buttonControls = new List<RadioButton>();

            InitializeComponent();
        }
        private void CheckUserAnswers()
        {
            for (int i = 0; i< userAnswers.Count; i++)
            {
                if(userAnswers[i].correct == true)
                {
                    MessageBox.Show("Valid!");
                }
            }
        }
        private void CheckQuestions()
        {
            GetUserInput();
            CheckUserAnswers();
        }
        private void GetUserInput()
        {
            userAnswers.Clear();

            //R button
            for(int i=0; i <buttonControls.Count; i++)
            {
                if(buttonControls[i].Checked == true)
                {
                    userAnswers.Add(currentQuestion.Answers[i]);
                }
            }
        }


            public void ShowQuestion(Question queston)
        {
            currentQuestion = queston;
            questionNumberLabel.Text = "Номер" + queston.Number.ToString();
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
    }
}

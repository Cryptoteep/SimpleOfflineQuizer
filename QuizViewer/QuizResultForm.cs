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
    public partial class QuizResultForm : Form
    {

            private QuizResult result;
            public QuizResultForm(QuizResult result)
            {
                InitializeComponent();
                this.result = result;
                
                ShowResult();

            }
            
        private void ShowResult()
        {
            
            label2.Text = result.validCountAnswer + " из " + result.allAnswers;
            //вЁрстка Таблицы

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();




            int answerCount = result.quizQuestions.Count;
            tableLayoutPanel1.RowCount = answerCount;
            tableLayoutPanel1.ColumnCount = 4;
            for (int i = 0; i < answerCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / answerCount));
                //Добавление контролов
                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0];
                t.Width = tableLayoutPanel1.GetColumnWidths()[1];
                //NUMBER
                t = new TextBox();
                t.Text = result.quizQuestions[i].Number.ToString();
                tableLayoutPanel1.Controls.Add(t, 0, i);
                //Ответ пользователя
                t = new TextBox();
                t.Text = result.quizQuestions[i].UserAnswers[0].text;
                tableLayoutPanel1.Controls.Add(t, 2, i);
                //Вопрос
                t = new TextBox();
                t.Text = result.quizQuestions[i].QuastionText;
                tableLayoutPanel1.Controls.Add(t, 1, i);
                //Current
                t = new TextBox();
                t.Text = result.quizQuestions[i].Answers[0].correct.ToString();
                tableLayoutPanel1.Controls.Add(t, 3, i);
            }


            }

        private void QuizResultForm_Load(object sender, EventArgs e)
        {

        }
    }
}
            
        


    


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
        public Form1()
        {
            InitializeComponent();
        }
        
        public void ShowQuestion(Question queston)
        {
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

            for (int i = 0; i < answerCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100/ answerCount));
                //Добавление контролов
                RadioButton r = new RadioButton();
                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0];
                t.Width = tableLayoutPanel1.GetColumnWidths()[1];
                t.Text = queston.Answers[i];

                tableLayoutPanel1.Controls.Add(t, 1, i);
                tableLayoutPanel1.Controls.Add(r, 0, i);
            }


        }

        #region DEBUG
        private void отрытьТестовыйКвизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();
            ShowQuestion(q.Questions[0]);
        }
        #endregion
    }
}

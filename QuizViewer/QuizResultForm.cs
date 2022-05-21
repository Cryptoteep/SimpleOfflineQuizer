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
                label2.Text = result.validCountAnswer + " из " + result.allAnswers;


        }
           
        


    }
}
            
        


    


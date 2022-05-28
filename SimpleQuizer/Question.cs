using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    
    public enum QuestionType
    {
        MultiChois,
        Open
    }
    [Serializable]
    public class Question
    {

        public int Number;
        public string QuastionText;
        public QuestionType Type;
        public List<Answer> Answers;
        public List<Answer> UserAnswers;
        public Question()
        {
            Answers = new List<Answer>();
            UserAnswers = new List<Answer>();

            
        }
        

    }
}

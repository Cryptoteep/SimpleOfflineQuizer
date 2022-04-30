using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public enum QuestionType
    {
        MultiChois,
        Open
    }

    public class Question
    {

        public int Number;
        public string QuastionText;
        public QuestionType Type;  
        public List<string> Answers;
        public Question()
        {
            Answers = new List<string>();


            
        }
        

    }
}

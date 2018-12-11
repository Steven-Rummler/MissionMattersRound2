using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public Question(string q, string a)
        {
            QuestionText = q;
            Answer = a;
        }
        public Question()
        {
            QuestionText = "Empty Question";
            Answer = "Empty Answer";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("MissionQuestion")]
    public class MissionQuestion
    {
        [Key]
        public int missionQuestionID;
        public int missionID;
        public int userID;
        public string question;
        public string answer;
    }
}
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
        int missionQuestionID;
        int missionID;
        int userID;
        string question;
        string answer;
    }
}
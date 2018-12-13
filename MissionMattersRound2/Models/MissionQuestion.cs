using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("MissionQuestion")]
    public class MissionQuestion
    {
        [Key]
        public int missionQuestionID { get; set; }
        public int userID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        //foreign key linking to mission model
        public int? missionID { get; set; }
        public virtual Mission mission { get; set; }
    }
}
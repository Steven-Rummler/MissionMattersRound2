using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int missionID { get; set; }
        public String missionName { get; set; }
        public String missionPresidentName { get; set; }
        public String missionAddress { get; set; }
        public String language { get; set; }
        public String climate { get; set; }
        public String dominantReligion { get; set; }
        public String flagSymbol { get; set; }

        //LINK TO MISSION QUESTIONS TABLE
        public virtual ICollection<MissionQuestion> missionQuestions { get; set; }
    }
}


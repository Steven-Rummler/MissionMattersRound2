using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int missionID;
        public string missionName;
        public string missionPresidentName;
        public string missionAddress;
        public string language;
        public string climate;
        public string dominantReligion;
        public string flagSymbol;
    }
}
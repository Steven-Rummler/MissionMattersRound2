using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MissionMattersRound2.Models;
using MissionMattersRound2.DAL;

namespace MissionMattersRound2.DAL
{
    public class MissionMattersContext : DbContext
    {
        public MissionMattersContext() : base ("MissionMattersContext")
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet <MissionQuestion> MissionQuestions { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.DAL
{
    public class MissionContext : DbContext
    {
      
        public MissionContext() : base("MissionContext")
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MissionQuestion> MissionQuestions { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int userID;
        public string userEmail;
        public string password;
        public string firstName;
        public string lastName;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionMattersRound2.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        int userID;
        string userEmail;
        string password;
        string firstName;
        string lastName;
    }
}
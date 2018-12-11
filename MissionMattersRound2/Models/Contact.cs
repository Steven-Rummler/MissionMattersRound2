using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
////The contact view will have basic company information, such as phone number and email.The view will 
//also have a contact form that will have fields for the user’s name, email, subject(choose from a list), 
//and message body.
namespace MissionMattersRound2.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
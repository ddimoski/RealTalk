using RealTalk.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }

        public String FistName { get; set; }

        public String LastName { get; set; }

        public UserType Type { get; set; }
    }
}
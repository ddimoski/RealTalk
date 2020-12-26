using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public List<Post> Posts { get; set; }

        public Tag()
        {
            Posts = new List<Post>();
        }
    }
}
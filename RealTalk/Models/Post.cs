using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class Post
    {
        public int Id { get; set; }

        public String Title { get; set; }
        
        public String Content { get; set; }

        public User User { get; set; }

        public List<Tag> Tags { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }
}
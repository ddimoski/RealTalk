﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }
        
        public String Content { get; set; }

        public ApplicationUser User { get; set; }
        
        public String Author { get; set; }
        public List<Tag> Tags { get; set; }

        public String TagsText { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }
}
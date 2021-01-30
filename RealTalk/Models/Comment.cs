﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    //trivial comment
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public String Content { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public String Content { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class PostVote
    {
        public int Id { get; set; }

        public VoteType Type { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
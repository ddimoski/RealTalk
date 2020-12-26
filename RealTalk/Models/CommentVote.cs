using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class CommentVote
    {
        public int Id { get; set; }
        public VoteType Type { get; set; }

        public User User { get; set; }

        public Comment Comment { get; set; }
    }
}
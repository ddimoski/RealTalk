using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class CommentVote
    {
        [Key]
        public int Id { get; set; }
        public VoteType Type { get; set; }

        public ApplicationUser User { get; set; }

        public Comment Comment { get; set; }
    }
}
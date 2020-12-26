using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealTalk.Models.Context
{
    public class RealTalkContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<User> Users { get; set; }

        public RealTalkContext() : base("DefaultConnection")
        {

        }

        public static RealTalkContext Create() 
        { 
            return new RealTalkContext();
        }
    }
}
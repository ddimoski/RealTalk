using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class AddCommentToPost
    {
        public List<Comment> tags { get; set; }
        public string commentToAdd { get; set; }
        public int selectedPost { get; set; }
        public AddCommentToPost()
        {
            tags = new List<Comment>();
        }
    }
}
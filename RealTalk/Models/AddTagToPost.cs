using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class AddTagToPost
    {
        public List<Tag> tags { get; set; }
        public int selectedTag { get; set; }
        public int selectedPost { get; set; }
        public AddTagToPost()
        {
            tags = new List<Tag>();
        }
    }
}
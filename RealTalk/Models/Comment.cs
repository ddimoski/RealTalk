using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealTalk.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public String Content { get; set; }

        public ApplicationUser User { get; set; }

        public String Author { get; set; }

        public Post Post { get; set; }
    }
}
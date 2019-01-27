using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Backend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public Guid Name { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual IList<Likes> Likes { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

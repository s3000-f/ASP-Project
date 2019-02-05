using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Backend.Models
{
    public class Post2
    {
        public Post2(Post post, DataContext context)
        {
            this.Caption = post.Caption;
            this.Id = post.Id;
            this.FileName = post.FileName;
            this.UserId = post.UserId;
            var u = context.Users.Find(post.UserId);
            this.UserName = u.UserName;
            this.CreatedAt = post.CreatedAt;
            this.likes = new List<int>();  
            if (post.Likes != null)
            {
                foreach (var l in post.Likes)
                {
                    this.likes.Add(l.UserId);
                }
            }

        }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> likes;
        public string FileName { get; set; }
        public string UserName { get; set; }
        public string Caption { get; set; }
    }
}

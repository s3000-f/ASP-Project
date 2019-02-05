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
            if (post.Likes != null)
                this.LikesCount = post.Likes.Count;
            else
                this.LikesCount = 0;

        }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string UserName { get; set; }
        public string Caption { get; set; }
    }
}

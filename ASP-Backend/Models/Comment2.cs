using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Backend.Models
{
    public class Comment2
    {
        public Comment2(Comment post, DataContext context)
        {
            this.Id = post.Id;
            this.UserId = post.UserId;
            var u = context.Users.Find(post.UserId);
            this.UserName = u.UserName;
            this.CreatedAt = post.CreatedAt;
            this.PostId = post.PostId;
            this.Data = post.Data;
            if (post.Clikes != null)
                this.LikesCount = post.Clikes.Count;
            else
                this.LikesCount = 0;

        }
        public int Id { get; set; }
        public int LikesCount { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Data { get; set; }


    }
}

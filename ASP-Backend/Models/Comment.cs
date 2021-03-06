﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<Clike> Clikes { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

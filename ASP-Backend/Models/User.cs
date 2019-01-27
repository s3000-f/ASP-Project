using System;
using System.Collections.Generic;

namespace ASP_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Backend.Models
{
    public class Post2
    {
        public int Id { get; set; }
        public Guid Name { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Caption { get; set; }
    }
}

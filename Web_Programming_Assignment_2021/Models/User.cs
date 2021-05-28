﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Avatar { get; set; }

        public string Message { get; set; }
        public string Email { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}

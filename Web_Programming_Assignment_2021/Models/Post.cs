using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Comment { get; set; }
        public string PhotoFile { get; set; }   
        public string Hashtag { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}

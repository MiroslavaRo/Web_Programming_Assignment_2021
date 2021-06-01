using System;
using System.ComponentModel.DataAnnotations;

namespace Web_Programming_Assignment_2021.DataEntities
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Content { get; set; }

        public string Photo { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
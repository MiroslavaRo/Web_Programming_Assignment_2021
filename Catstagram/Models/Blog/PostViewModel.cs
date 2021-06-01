using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Catstagram.Models.Blog
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Content { get; set; }

        public IFormFile PhotoFile { get; set; }

        public string Photo { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public string CategorySlug
        {
            get
            {
                return $"_{CategoryId}";
            }
        }

        public string Message { get; set; }
    }
}
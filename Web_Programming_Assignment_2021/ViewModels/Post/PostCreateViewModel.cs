using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.ViewModels.Post
{
    public class PostCreateViewModel
    {

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Hashtags")]
        public string Hashtag { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Please Enter Upload photo..")] 
        public IFormFile photo { get; set; }


        public bool ErrorMessageVisible { get; set; }


        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public string UserName { get; set; }
    }
}

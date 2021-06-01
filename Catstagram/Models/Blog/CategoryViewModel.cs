using System.ComponentModel.DataAnnotations;

namespace Catstagram.Models.Blog
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string CategorySlug
        {
            get
            {
                return $"_{Id}";
            }
        }

        public string Message { get; set; }
    }
}
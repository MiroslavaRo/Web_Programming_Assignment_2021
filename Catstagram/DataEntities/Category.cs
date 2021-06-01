using System.ComponentModel.DataAnnotations;

namespace Catstagram.DataEntities
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
    }
}
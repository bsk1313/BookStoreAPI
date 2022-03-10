using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please add title propertry")]
        [StringLength(100, ErrorMessage ="Title should not be greater than 100 characters")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

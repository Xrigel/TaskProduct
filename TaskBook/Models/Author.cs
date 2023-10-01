using System.ComponentModel.DataAnnotations;

namespace TaskBook.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [EnumDataType(typeof(GenderEnum))]
        public string Gender { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string IdNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Country { get; set; }
        [StringLength(50, MinimumLength = 4)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }
        public List<Product_Author> Product_Authors { get; set; }


    }
    enum GenderEnum
    {
        Male,
        Female
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250,MinimumLength=2)]
        public string  Name { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 100)]
        public string Annotation { get; set; }
        [EnumDataType(typeof(ProductTypeEnum))]
        public string ProductType { get; set; }
        [Required]
        [StringLength(13,MinimumLength =13)]
        public string ISBN { get; set; }
        [Required]
        public DateTime Release { get; set; }
        public Publisher Publisher { get; set; }

        public int PageNumber { get; set; }
        [Required]
        public bool IsOnline { get; set; }
        [Required]
        public string  Address { get; set; }
        public int PublisherId { get; set; }
        public List<Product_Author> Product_Authors { get; set; }

    }
    public enum ProductTypeEnum
    {
        Book,
        Statue,
        ElectronicResource
    }
}

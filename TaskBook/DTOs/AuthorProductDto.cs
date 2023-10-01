namespace TaskBook.DTOs
{
    public class AuthorProductDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public List<ProductDto> Product { get; set; }

        



    }
}

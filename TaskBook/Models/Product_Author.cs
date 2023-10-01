namespace TaskBook.Models
{
    public class Product_Author
    {
        public int  Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

namespace TaskBook.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublisherName { get; set; }
        public List<Product> Products { get; set; }
    }
}

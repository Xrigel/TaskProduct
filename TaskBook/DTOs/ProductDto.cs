
namespace TaskBook.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        
        public string Annotation { get; set; }
        
        public string ProductType { get; set; }
       
        public string ISBN { get; set; }
      
        public DateTime Release { get; set; }
        public PublisherDto Publisher { get; set; }
        public int  PublisherId { get; set; }

        public int PageNumber { get; set; }
        
        public bool IsOnline { get; set; }
        
        public string Address { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}

using TaskBook.DTOs;
using TaskBook.Models;

namespace TaskBook.Services
{
    public interface IProductService
    {
        public Task<bool> AddAuthorWithBook(ProductDto productDto);

        public Task<List<Product>> GetFilterProduct(string name,int pageSize=3,int page=1);
    }
}

using TaskBook.Models;

namespace TaskBook.Core.Abstraction
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public Task<List<Product>> GetFilteredProduct(string name, int page, int pagesize);
    }
}

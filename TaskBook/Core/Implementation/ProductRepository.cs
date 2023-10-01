using TaskBook.Core.Abstraction;
using TaskBook.Data;
using TaskBook.Models;

namespace TaskBook.Core.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<List<Product>> GetFilteredProduct(string name, int page, int pagesize)
        {
            var filteredBooks =_appDbContext.Products.Where(prod => prod.Name == name).ToList();

            var startIndex = (page - 1) * pagesize;
            var endIndex = startIndex + pagesize;

            
            var paginatedBooks = filteredBooks.Skip(startIndex).Take(pagesize).ToList();
            return paginatedBooks;
        }
    }
}

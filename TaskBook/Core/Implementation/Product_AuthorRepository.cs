using TaskBook.Core.Abstraction;
using TaskBook.Data;
using TaskBook.Models;

namespace TaskBook.Core.Implementation
{
    public class Product_AuthorRepository : GenericRepository<Product_Author>,IProduct_AuthorRepository
    {
        public Product_AuthorRepository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
        }
    }
}

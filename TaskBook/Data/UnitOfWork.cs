using TaskBook.Core.Abstraction;
using TaskBook.Core.Implementation;

namespace TaskBook.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerfactory)
        {
            _context = context;
            var _logger = loggerfactory.CreateLogger("logs");  
            //"მივაერთეთ" ბაზა ჩვენ რეპოსიტორის და ასევე აბსტრაქტულ კლასებსაც
            Authors =new AuthorRepository(_context, _logger);
            Products = new ProductRepository(_context, _logger);
            Product_Author = new Product_AuthorRepository(_context, _logger);
        }

        public IAuthorRepository Authors { get; }
        public IProductRepository Products { get; }

        public IProduct_AuthorRepository Product_Author { get; }

        public  async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

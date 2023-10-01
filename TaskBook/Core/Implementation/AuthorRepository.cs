using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBook.Core.Abstraction;
using TaskBook.Data;
using TaskBook.DTOs;
using TaskBook.Models;

namespace TaskBook.Core.Implementation
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;
        public AuthorRepository(AppDbContext appDbContext, ILogger logger) : base(appDbContext, logger)
        {
            _appDbContext = appDbContext;
        }

        //vqmni axal IProductAuthorRepository(public async Task<Product_Author> GetAuthorWithProduct(int id);)
        //,implementacia ProductAuthorRepository(aq chavwer metods qvemot racaa),mere shevqmni service da am se

        public async Task<Author?> GetAuthorWithProducts(int id)
        {
            return await _appDbContext.Authors.Include(x => x.Product_Authors).ThenInclude(p=>p.Product).ThenInclude(pab=>pab.Publisher).FirstOrDefaultAsync(g => g.Id == id);
        }
        
    }
}

using Microsoft.EntityFrameworkCore;
using TaskBook.Core.Abstraction;
using TaskBook.Data;

namespace TaskBook.Core.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //AppDbContext უკავშირედბა ბაზას
        protected AppDbContext appDbContext;
        //DbSet უკავშირდება ბაზაში კონკრეტულ მაგიდას
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(AppDbContext appDbContext, ILogger logger)
        {
            this.appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
            _logger = logger;
        }

        public  virtual async Task<bool> Add(T entity)
        {
             await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity=await GetByID(id);
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
             _dbSet.Update(entity);
            return true;
        }
    }
}

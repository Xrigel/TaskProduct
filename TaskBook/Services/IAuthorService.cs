using TaskBook.DTOs;

namespace TaskBook.Services
{
    public interface IAuthorService
    {
        public  Task<bool> Add(AuthorDto entity);
        public Task<AuthorProductDto?> GetAuthorWithProducts(int id);
        public Task<bool> Delete(int id);

        public Task<bool> Update(int id,AuthorDto authorDto);
    }
}

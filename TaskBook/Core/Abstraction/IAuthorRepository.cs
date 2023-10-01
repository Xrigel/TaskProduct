using Microsoft.AspNetCore.Mvc;
using TaskBook.DTOs;
using TaskBook.Models;

namespace TaskBook.Core.Abstraction
{
    public interface IAuthorRepository:IGenericRepository<Author>
    {
        public Task<Author?> GetAuthorWithProducts(int id);
    }

}

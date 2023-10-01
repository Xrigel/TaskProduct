using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBook.Core.Abstraction;
using TaskBook.DTOs;
using TaskBook.Models;
using TaskBook.Services;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("authors-add")]
        public  IActionResult Add([FromBody] AuthorDto authorDto)
        {
            _authorService.Add(authorDto);
            return Ok();
        }
       
        [HttpGet("AuthorWithProduct")]
        public async Task<IActionResult> GetAuthorByIdWithBooks(int id)
        {
            var author = await _authorService.GetAuthorWithProducts(id);
            return Ok(author);
        }

        [HttpDelete("DeleteAuthor")]

        public async Task<bool> Delete(int id)
        {
             return await _authorService.Delete(id);
        }
        [HttpPut("Update-Author")]
        public async Task<bool> Update(int id, [FromBody] AuthorDto authorDto)
        {
            return await _authorService.Update(id, authorDto);
        }
    }
}

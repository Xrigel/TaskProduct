using TaskBook.Core.Abstraction;
using TaskBook.DTOs;
using TaskBook.Models;

namespace TaskBook.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IUnitOfWork _unitOfwork;
        public AuthorService(IUnitOfWork unitOfwork)
        {

            _unitOfwork = unitOfwork;
        }

        public async Task<bool> Add(AuthorDto entity)
        {
            var author = new Author()
            {
                City = entity.City,
                Country = entity.Country,
                LastName = entity.LastName,
                Name = entity.Name,
                IdNumber = entity.IdNumber,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                DateOfBirth = entity.DateOfBirth

            };
            await _unitOfwork.Authors.Add(author);
            await _unitOfwork.CompleteAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var IsDeleted = await _unitOfwork.Authors.Delete(id);
            await _unitOfwork.CompleteAsync();
            return IsDeleted;
        }

        public async Task<AuthorProductDto?> GetAuthorWithProducts(int id)
        {
            var authorsWith = await _unitOfwork.Authors.GetAuthorWithProducts(id);
            var Products = new List<ProductDto>();
            var authorWithDto = new AuthorProductDto()
            {
                Name = authorsWith.Name,
                LastName = authorsWith.LastName,
                Product = Products
            };
            foreach (var productAuthor in authorsWith.Product_Authors)
            {
                var product = new ProductDto()
                {
                    Address = productAuthor.Product.Address,
                    ISBN = productAuthor.Product.ISBN,
                    Publisher = new PublisherDto()
                    {
                        PublisherName = productAuthor.Product.Publisher.PublisherName
                    }
                };
                Products.Add(product);
            }
            return authorWithDto;

        }

        public async Task<bool> Update(int id, AuthorDto _authorDto)
        {
            var _tempAuthor = await _unitOfwork.Authors.GetByID(id);

            if (_tempAuthor != null)
            {
                _tempAuthor.Name = _authorDto.Name;
                _tempAuthor.LastName = _authorDto.LastName;
                _tempAuthor.PhoneNumber = _authorDto.PhoneNumber;
                _tempAuthor.DateOfBirth = _authorDto.DateOfBirth;
                _tempAuthor.IdNumber = _authorDto.IdNumber;
                _tempAuthor.Gender = _authorDto.Gender;
                _tempAuthor.Country = _authorDto.Country;
                _tempAuthor.Email = _authorDto.Email;
                _tempAuthor.City = _authorDto.City;

                await _unitOfwork.Authors.Update(_tempAuthor);
                await _unitOfwork.CompleteAsync();
                return true;
            }
            return false;
        }

    }
}

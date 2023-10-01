using TaskBook.Core.Abstraction;
using TaskBook.DTOs;
using TaskBook.Models;

namespace TaskBook.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfwork;
        public ProductService(IUnitOfWork unitOfwork)
        {

            _unitOfwork = unitOfwork;
        }
        public async Task<bool> AddAuthorWithBook(ProductDto productDto)
        {
            var _product = new Product()
            {
                Name = productDto.Name,
                Address = productDto.Address,
                Annotation = productDto.Annotation,
                ISBN = productDto.ISBN,
                IsOnline = productDto.IsOnline,
                PageNumber = productDto.PageNumber,
                Release = productDto.Release,
                PublisherId = productDto.PublisherId
            };
            await _unitOfwork.Products.Add(_product);
            await _unitOfwork.CompleteAsync();
            foreach (var id in productDto.AuthorIds)
            {
                var _product_Authors = new Product_Author()
                {
                    AuthorId = id,
                    ProductId = _product.Id,
                };
                await _unitOfwork.Product_Author.Add(_product_Authors);
                await _unitOfwork.CompleteAsync();
            }
            return true;
        }

        public  async Task<List<Product>> GetFilterProduct(string name, int pageSize = 3, int page = 1)
        {
            return await _unitOfwork.Products.GetFilteredProduct(name, pageSize, page);
            await _unitOfwork.CompleteAsync();
        }
    }
}

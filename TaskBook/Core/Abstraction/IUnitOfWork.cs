namespace TaskBook.Core.Abstraction
{
    public interface IUnitOfWork:IDisposable
    {
        IAuthorRepository Authors { get; }
        IProductRepository Products { get; }
        IProduct_AuthorRepository Product_Author { get; }
        Task CompleteAsync();
    }
}

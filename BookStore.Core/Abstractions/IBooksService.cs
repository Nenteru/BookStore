using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<List<Book>> GetListBooksAsync();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}
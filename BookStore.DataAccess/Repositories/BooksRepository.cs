using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;

        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking() // ичпользуем при получении данных
                .ToListAsync<BookEntity>();

            var books = bookEntities
                .Select(x => Book.Create(x.Id, x.Title, x.Description, x.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _context.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Title, x => title)
                    .SetProperty(x => x.Description, x => description)
                    .SetProperty(x => x.Price, x => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}

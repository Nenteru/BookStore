﻿using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<List<Book>> GetListBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
        Task<Guid> DeleteBook(Guid id);
    }
}
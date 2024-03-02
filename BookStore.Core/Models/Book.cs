

using System.Runtime.InteropServices;

namespace BookStore.Core.Models
{
    public class Book
    {
        public static int MAX_TITLE_LENGTH = 250;
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if (title.Length > MAX_TITLE_LENGTH || string.IsNullOrEmpty(title))
                error = "title.Length > MAX_TITLE_LENGTH";

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}

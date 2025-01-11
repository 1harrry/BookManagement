using API.Repositories;
using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Get all books asynchronously
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        // Get a book by id asynchronously
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        // Add a new book asynchronously
        public async Task AddBookAsync(BookDTO bookDTO)
        {
            var book = new Book
            {
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Genre = bookDTO.Genre,
                Price = bookDTO.Price,
                PublishedYear = bookDTO.PublishedYear,
                Rating = bookDTO.Rating
            };
            await _bookRepository.AddBookAsync(book);
        }

        // Update an existing book asynchronously
        public async Task UpdateBookAsync(int id, BookDTO bookDTO)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                book.Title = bookDTO.Title;
                book.Author = bookDTO.Author;
                book.Genre = bookDTO.Genre;
                book.Price = bookDTO.Price;
                book.Rating = bookDTO.Rating;
                await _bookRepository.UpdateBookAsync(book);
            }
        }

        // Delete a book by id asynchronously
        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        // Method to get the dashboard summary


        public async Task<DashboardSummaryDTO> GetDashboardSummaryAsync()
        {
            var books = await _bookRepository.GetBooksAsync();

            var totalBooks = books.Count();
            var averageRating = books.Any() ? books.Average(b => b.Rating) : 0;

            var booksByGenre = books
                .GroupBy(b => b.Genre)
                .Select(g => new GenreSummaryDTO
                {
                    Genre = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return new DashboardSummaryDTO
            {
                TotalBooks = totalBooks,
                AverageRating = Convert.ToDecimal(averageRating),
                BooksByGenre = booksByGenre
            };
        }
    }
}

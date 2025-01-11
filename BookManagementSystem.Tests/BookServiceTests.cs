using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Repositories;
using API.Services;
using Domain.Entities;
using Domain.DTOs;

namespace BookManagementSystem.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockRepo;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            // Mock the IBookRepository
            _mockRepo = new Mock<IBookRepository>();
            _bookService = new BookService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllBooks_ReturnsBooks()
        {
            // Arrange: Set up mock data to be returned by the repository
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Fiction", Price = 9.99m, Rating = 4.5m },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Non-Fiction", Price = 14.99m, Rating = 3.8m }
            };

            // Set up the mock repository to return the books list
            _mockRepo.Setup(repo => repo.GetBooksAsync()).ReturnsAsync(books);

            // Act: Call the service method
            var result = await _bookService.GetAllBooksAsync();

            // Assert: Verify that the result contains the correct number of books
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetBookById_ReturnsBook_WhenBookExists()
        {
            // Arrange: Create a mock book
            var book = new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Fiction", Price = 9.99m, Rating = 4.5m };

            // Set up the mock repository to return the book
            _mockRepo.Setup(repo => repo.GetBookByIdAsync(1)).ReturnsAsync(book);

            // Act: Call the service method
            var result = await _bookService.GetBookByIdAsync(1);

            // Assert: Verify that the result is the correct book
            Assert.Equal(1, result.Id);
            Assert.Equal("Book 1", result.Title);
        }

        [Fact]
        public async Task AddBook_AddsBookSuccessfully()
        {
            // Arrange: Create a new book DTO to add
            var bookDTO = new BookDTO { Title = "New Book", Author = "New Author", Genre = "Fiction", Price = 12.99m, Rating = 4.0m };

            // Act: Call the service method
            await _bookService.AddBookAsync(bookDTO);

            // Assert: Verify that the repository AddBookAsync method was called once
            _mockRepo.Verify(repo => repo.AddBookAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}

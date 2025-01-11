using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(BookDTO bookDTO);
        Task UpdateBookAsync(int id, BookDTO bookDTO);
        Task DeleteBookAsync(int id);
        Task<DashboardSummaryDTO> GetDashboardSummaryAsync();
    }
}

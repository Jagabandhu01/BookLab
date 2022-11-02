using BookLab.Models;
using BookLab.Models.Dto;

namespace BookRecord.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task <Book> GetBookFromId(int id);
        Task<Book> AddBook(Book book);
    }
}

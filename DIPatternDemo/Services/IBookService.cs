using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int EditBook(Book book);
        int DeleteBook(int id);
    }
}

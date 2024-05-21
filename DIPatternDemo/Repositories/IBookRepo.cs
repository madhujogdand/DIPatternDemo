using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int EditBook(Book book);
        int DeleteBook(int id);
    }
}

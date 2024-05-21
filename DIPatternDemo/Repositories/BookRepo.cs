using DIPatternDemo.Data;
using DIPatternDemo.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace DIPatternDemo.Repositories
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext db;

        public BookRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddBook(Book book)
        {
            book.IsActive = 1;
            int result = 0;
            db.Books.Add(book);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int result = 0;
            var model = db.Books.Where(book => book.Id == id).FirstOrDefault();
            if (model != null)
            {
                model.IsActive = 0;
                result = db.SaveChanges();
            }
            return result;
        }

        public int EditBook(Book book)
        {
            int result = 0;
            var model = db.Books.Where(bk => bk.Id == book.Id).FirstOrDefault();
            if (model != null)
            {
                model.Name = book.Name;
                model.Author = book.Author;
                model.Price = book.Price;
                model.IsActive = 1;
                result = db.SaveChanges();
            }
            return result;
        }

        public Book GetBookById(int id)
        {
            return db.Books.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<Book> GetBooks()
        {
            var model = (from book in db.Books
                         where book.IsActive == 1
                         select book).ToList();
            return model;
        }
    }
}

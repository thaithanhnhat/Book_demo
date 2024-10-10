using Nhat_ThaiThanh_21T1020553.Models;

namespace Nhat_ThaiThanh_21T1020553.Services
{
    public class BookService
    {
        private AppDbContext db;

        public BookService()
        {
            if (db == null)
            {
                db = new AppDbContext();
            }
        }

        public List<Book> GetAllBooks(int id)
        {
            var ls = db.Books.Where(q=>q.AuthorId == id).ToList();
            return ls;
        }

        public Book GetBookById(int id)
        {
            return db.Books.Find(id);
        }
        public List<Book> GetBookByName(string keyWord,int maAu)
        {
            var ls = db.Books.Where(q=>q.Title.Contains(keyWord) && q.AuthorId == maAu).ToList();
            return ls;
        }
        public void CreateBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            db.Books.Update(book);
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}

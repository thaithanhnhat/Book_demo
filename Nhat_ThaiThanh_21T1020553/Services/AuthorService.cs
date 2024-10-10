using Nhat_ThaiThanh_21T1020553.Models;

namespace Nhat_ThaiThanh_21T1020553.Services
{
    public class AuthorService
    {
        private AppDbContext db;

        public AuthorService()
        {
            if (db == null)
            {
                db = new AppDbContext();
            }
        }

        public List<Author> GetAllAuthors()
        {
            return db.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return db.Authors.Find(id);
        }

        public List<Author> GetAuthorByName(string name) { 
            var ls = db.Authors.Where(q=>q.Name.Contains(name)).ToList();
            return ls;
        }
        public void CreateAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            db.Authors.Update(author);
            db.SaveChanges();
        }

        public Boolean DeleteAuthor(int id)
        {
            var author = db.Authors.Find(id);
            BookService bookService = new BookService();
            if (bookService.GetAllBooks(id).Count == 0)
            {
                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
           
            return null;
        }
    }
}

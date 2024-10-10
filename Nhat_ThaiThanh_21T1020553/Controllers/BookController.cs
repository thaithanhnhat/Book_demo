using Microsoft.AspNetCore.Mvc;
using Nhat_ThaiThanh_21T1020553.Models;
using Nhat_ThaiThanh_21T1020553.Services;
using Nhat_ThaiThanh_21T1020553.ViewModels;

namespace Nhat_ThaiThanh_21T1020553.Controllers
{
    public class BookController : Controller
    {
        private BookService bookService;
        public BookController()
        {
            bookService = new BookService();
        }
        public IActionResult Index(int idAuthor, string? keyWord)
        {
            BookViewModel model = new BookViewModel();
            if (keyWord == null) { 
                var ls = bookService.GetAllBooks(idAuthor);
                model.ListBook = ls;
                model.keyWord="";
            }
            else
            {
                var ls = bookService.GetBookByName(keyWord,idAuthor);
                model.ListBook=ls;
                model.keyWord=keyWord;
            }

            model.maAuthor = idAuthor;
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ls = bookService.GetBookById(id);
            BookViewModel model = new BookViewModel();
            model.BookResponse = ls;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            bookService.UpdateBook(model.BookResponse);


            return RedirectToAction("index", new { idAuthor = model.BookResponse.AuthorId});
        }
        [HttpGet]
        public IActionResult Add(int id)
        {   
            BookViewModel model = new BookViewModel();  
            model.maAuthor = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            bookService.CreateBook(model.BookResponse);
            return RedirectToAction("index", new { idAuthor = model.BookResponse.AuthorId });
        }

        public IActionResult Delete(int id)
        {
            var ls = bookService.GetBookById(id);
            bookService.DeleteBook(id);
            return RedirectToAction("index", new { idAuthor = ls.AuthorId });
        }

    }
}

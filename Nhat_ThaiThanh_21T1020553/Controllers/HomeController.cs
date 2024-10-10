using Microsoft.AspNetCore.Mvc;
using Nhat_ThaiThanh_21T1020553.Models;
using Nhat_ThaiThanh_21T1020553.Services;
using Nhat_ThaiThanh_21T1020553.ViewModels;
using System.Diagnostics;

namespace Nhat_ThaiThanh_21T1020553.Controllers
{
    public class HomeController : Controller
    {
        AuthorService authorService;

        public HomeController()
        {
            authorService = new AuthorService();
        }

        public IActionResult Index(string? keyWord)
        {
            AuthorViewModel model = new AuthorViewModel();
            if (keyWord ==null)
            {
                var ls = authorService.GetAllAuthors();
                model.ListAuthor = ls;
                model.keyWord="";
            }
            else
            {
                var ls = authorService.GetAuthorByName(keyWord);
                model.ListAuthor = ls;
                model.keyWord=keyWord;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            var ls = authorService.GetAuthorById(id);
            AuthorViewModel model = new AuthorViewModel();
            model.AuthorResponse = ls;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(AuthorViewModel model)
        {
            authorService.UpdateAuthor(model.AuthorResponse);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            AuthorViewModel model = new AuthorViewModel();
            return View(model.AuthorResponse);
        }
        [HttpPost]
        public IActionResult Add(AuthorViewModel model)
        {
            authorService.CreateAuthor(model.AuthorResponse);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            authorService.DeleteAuthor(id);
            return RedirectToAction("index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

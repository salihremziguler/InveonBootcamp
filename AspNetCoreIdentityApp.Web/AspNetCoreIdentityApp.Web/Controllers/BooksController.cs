using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.UnitOfWork;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.Books.GetAll()
        .Select(book => new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublicationYear = book.PublicationYear,
            ISBN = book.ISBN
        }).ToList();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN
            };

            return View(bookViewModel);
        }
    }
}

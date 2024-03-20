using directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace directory.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> _books = new List<Book>
        {
            //new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Genre 1", PublicationYear = 2020 },
            //new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Genre 2", PublicationYear = 2021 },
            //new Book { Id = 3, Title = "Book 3", Author = "Author 3", Genre = "Genre 3", PublicationYear = 2022 }
            
        };

        
        public ActionResult Index()
        {
            ViewBag.Books = _books;
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            // Add the new book to the static list
            _books.Add(book);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            // Find the book with the given ID in the static list
            Book bookToDelete = _books.FirstOrDefault(b => b.Id == id);

            // If the book exists, remove it from the list
            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
            }

            return RedirectToAction("Index");
        }

    }
}

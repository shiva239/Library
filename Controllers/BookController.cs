using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        BookModel bookDB = new BookModel();
        public ActionResult Index()
        {
            return View(bookDB.GetBooksList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book bookObj)
        {
            int i = bookDB.SaveBook(bookObj);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Book bookObj = bookDB.GetBookById(id);
            return View(bookObj);
        }

        [HttpPost]
        public ActionResult Edit(Book bookObj)
        {
            int i = bookDB.EditBookById(bookObj);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(bookObj);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            int i = bookDB.DeleteBookById(id);
            return RedirectToAction("index");
        }

    }
}
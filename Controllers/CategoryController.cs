using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using PagedList;
using PagedList.Mvc;

namespace Task1.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Category
        public ActionResult Index(int? page)
        {
            var category = _context.Categories.ToList();
            return View(category.ToList().ToPagedList(page ?? 1, 10));
        }

        public ActionResult AddCat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var catInDb = _context.Categories.Single(c => c.Id == category.Id);

                catInDb.CatName = category.CatName;
               
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Edit(int id)
        {
            var cat = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (cat == null)
                return HttpNotFound();

            return View("AddCat");
        }

        public ActionResult Delete(int id)
        {
            var cat = _context.Categories.Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }

       
        public ActionResult Active(Category category)
        {
            var act = _context.Categories.Single(c => c.Id == category.Id);
            act.ActiveOrNot = true;
            _context.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }

        public ActionResult Deactive(Category category)
        {
            var deact = _context.Categories.Single(c => c.Id == category.Id);
            deact.ActiveOrNot = false;
            _context.SaveChanges();
            //Category deact = _context.Categories.Create();
            //deact.Id = id;
            //_context.Categories.Attach(deact);
            //deact.ActiveOrNot = deactivate;
            //_context.SaveChanges();

            return RedirectToAction("ProductList", "Product");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Task1.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Index(int? page)
        {
            if (User.IsInRole(RoleName.Admin)) 
            { 
                var category = await _context.Categories.ToListAsync();
                return View("Index",category.ToList().ToPagedList(page ?? 1, 10));
            }else
            {
                var category = await _context.Categories.ToListAsync();
                return View("list",category.ToList().ToPagedList(page ?? 1, 10));
            }
        }

        public ActionResult AddCat()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Save(Category category)
        {

            if (category.Id == 0)
            {
                  _context.Categories.Add(category);
            }
            else
            {
                var catInDb = await _context.Categories.SingleAsync(c => c.Id == category.Id);

                catInDb.CatName = category.CatName;
               
            }
             await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var cat = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (cat == null)
                return HttpNotFound();

            return View("AddCat");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Category");
        }

       
        public async Task<ActionResult> Active(Category category)
        {
            var act = await _context.Categories.SingleAsync(c => c.Id == category.Id);
            act.ActiveOrNot = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductList", "Product");
        }

        public async Task<ActionResult> Deactive(Category category)
        {
            var deact = await _context.Categories.SingleAsync(c => c.Id == category.Id);
            deact.ActiveOrNot = false;
            await _context.SaveChangesAsync();
            //Category deact = _context.Categories.Create();
            //deact.Id = id;
            //_context.Categories.Attach(deact);
            //deact.ActiveOrNot = deactivate;
            //_context.SaveChanges();

            return RedirectToAction("ProductList", "Product");

        }

    }
}
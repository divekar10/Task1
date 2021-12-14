using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using Task1.ViewModels;
using PagedList;
using PagedList.Mvc;
using System.Data;

namespace Task1.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        

        private readonly ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult AddProduct()
        {
            var ddl = _context.Categories.ToList();
            var viewModel = new AddProductViewModel
            {
                Categories = ddl
            };
            return View("AddProduct",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new AddProductViewModel
            //    {
            //        Product = product,
            //        Categories = _context.Categories.ToList()
            //    };
            //    return View("AddProduct", viewModel);
            //}
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(c => c.Id == product.Id);

                productInDb.ProductName = product.ProductName;
                productInDb.CategoryId = product.CategoryId;
                productInDb.Username = product.Username;
            }
            _context.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return HttpNotFound();

            var viewModel = new AddProductViewModel
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };

            return View("AddProduct", viewModel);
        }


        public ActionResult Delete(int id)
        {
            var pro = _context.Products.Find(id);
            _context.Products.Remove(pro);
            _context.SaveChanges();

            return RedirectToAction("ProductList", "Product");
        }

        // GET: Product
        public ActionResult ProductList(int? page, bool a = true)
        {
            if (User.IsInRole("Admin"))
            {
                var product = _context.Products.Include(c => c.Category).Where(c => c.Category.ActiveOrNot.Equals(a)).ToList();
                return View("ProductList",product.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var product = _context.Products.Include(c => c.Category).Where(c => c.Category.ActiveOrNot.Equals(a)).ToList();
                return View("ReadOnly",product.ToList().ToPagedList(page ?? 1, 10));
            }
        }

    //    public ActionResult Report()
    //    //{
    //    //    IEnumerable<Product> data = _context.Database.SqlQuery<Product>("spDisplayDetails", CommandType.StoredProcedure);
    //    //    return View(data.ToList());
    //    }
    }
}
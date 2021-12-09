using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using Task1.ViewModels;

namespace Task1.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationDbContext _context;
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
            return View(viewModel);
        }


        // GET: Product
        public ActionResult ProductList()
        {

            var product = _context.Products.Include(c => c.Category).ToList();
            return View(product);

            //var product = new Product() { ProductName = "Mobile" };
            //var category = new List<Category>
            //{
            //    new Category { CatName = "Electronic"},
            //    new Category { CatName = "Farm"}
            //};

            //var viewModel = new ProductListViewModel
            //{
            //    Product = product,
            //    Categories = category
            //};
            //return View(product);
        }
    }
}
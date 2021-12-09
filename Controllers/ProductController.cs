﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using Task1.ViewModels;
using PagedList;
using PagedList.Mvc;

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
            return View("AddProduct",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(c => c.Id == product.Id);

                productInDb.ProductName = product.ProductName;
                productInDb.CategoryId = product.CategoryId;
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
        public ActionResult ProductList(int? page)
        {

            var product = _context.Products.Include(c => c.Category).ToList();
            return View(product.ToList().ToPagedList(page ?? 1, 10));

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
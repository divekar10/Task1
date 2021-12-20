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
using System.Threading.Tasks;

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


        public async Task<ActionResult> AddProduct()
        {
            var ddl = await _context.Categories.ToListAsync();
            var viewModel = new AddProductViewModel
            {
                Categories = ddl
            };
            return View("AddProduct",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Product product)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewmodel = new addproductviewmodel
            //    {
            //        product = product,
            //        categories = _context.categories.tolist()
            //    };
            //    return view("addproduct", viewmodel);
            //}
            if (product.Id == 0)
            {
               _context.Products.Add(product);
            }
            else
            {
                var productInDb = await _context.Products.SingleAsync(c => c.Id == product.Id);

                productInDb.ProductName = product.ProductName;
                productInDb.CategoryId = product.CategoryId;
                productInDb.Username = product.Username;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductList", "Product");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(c => c.Id == id);
            if (product == null)
                return HttpNotFound();

            var viewModel = new AddProductViewModel
            {
                Product = product,
                Categories = await _context.Categories.ToListAsync()
            };

            return View("AddProduct", viewModel);
        }


        public async Task<ActionResult> Delete(int id)
        {
            var pro = await _context.Products.FindAsync(id);
            _context.Products.Remove(pro);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductList", "Product");
        }

        // GET: Product
        public async Task<ActionResult> ProductList(int? page, bool a = true)
        {
            if (User.IsInRole(RoleName.Admin))
            {
                var product = await _context.Products.Include(c => c.Category).Where(c => c.Category.ActiveOrNot.Equals(a)).ToListAsync();
                return View("ProductList",product.ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                var product = await _context.Products.Include(c => c.Category).Where(c => c.Category.ActiveOrNot.Equals(a)).ToListAsync();
                return View("list",product.ToList().ToPagedList(page ?? 1, 10));
            }
        }

    //    public ActionResult Report()
    //    //{
    //    //    IEnumerable<Product> data = _context.Database.SqlQuery<Product>("spDisplayDetails", CommandType.StoredProcedure);
    //    //    return View(data.ToList());
    //    }
    }
}
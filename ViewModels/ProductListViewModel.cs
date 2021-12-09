using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task1.Models;

namespace Task1.ViewModels
{
    public class ProductListViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
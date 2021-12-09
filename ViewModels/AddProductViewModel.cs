using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task1.Models;

namespace Task1.ViewModels
{
    public class AddProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
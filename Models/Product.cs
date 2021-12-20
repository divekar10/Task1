using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter Product Name.")]
        [StringLength(255)]
        [DisplayName("Product Name")]
        public String ProductName { get; set; }
        public Category Category { get; set; }

        [DisplayName("Category Name")]
        public int CategoryId { get; set; }

        public string Username { get; set; }
    }
}
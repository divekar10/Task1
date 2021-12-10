using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Task1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String CatName { get; set; }

        [DefaultValue(true)]
        public bool ActiveOrNot { get; set; }
    }
}
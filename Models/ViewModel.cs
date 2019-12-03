using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAspNetCoreApp.Models
{
    public class ViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ProductCategories{ get; set; }
        
    }
}

using Microsoft.EntityFrameworkCore;
using ProductsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAspNetCoreApp.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}

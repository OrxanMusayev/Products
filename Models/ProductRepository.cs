using Microsoft.EntityFrameworkCore;
using ProductAspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int Id)
        {
            Product product = GetProduct(Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }


        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.ProductCategory).ToList();
        }

        public Product GetProduct(int Id)
        {
            return _context.Products.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            _context.Entry(productChanges).State = EntityState.Modified;
            _context.SaveChanges();
            return productChanges;
        }
    }
}

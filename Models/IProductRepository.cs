using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAspNetCoreApp.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        List<Product> GetAllProducts();
        Product Add(Product product);
        Product Update(Product productChange);
        Product Delete(int id);
    }
}

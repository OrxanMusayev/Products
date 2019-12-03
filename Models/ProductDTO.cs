using ProductsWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAspNetCoreApp.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Məhsulun adı daxil edilməlidir")]
        public string Name { get; set; }
        [RegularExpression(@"^[0-9]*$")]
        [Required]
        public string Code { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [ForeignKey("ProductCategoryId")]
        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}

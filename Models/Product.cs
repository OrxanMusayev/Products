using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAspNetCoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Məhsulun adı daxil edilməlidir")]
        public string Name { get; set; }
        [RegularExpression(@"^[0-9]*$")]
        [Required(ErrorMessage = "Kod daxil edilməlidir")]
        [StringLength(8, MinimumLength =8)]
        public string Code { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]

        public int UserID { get; set; }
        //[Required]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Kategoriyanı seçin")]
        public int? ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}

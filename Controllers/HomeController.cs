using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProductAspNetCoreApp.Models;
using ProductsWebApp.Models;

namespace ProductAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductContext _context { get; }

        public HomeController(IMapper mapper, IProductRepository repository, ProductContext context)
        {
            _mapper = mapper;
            _repository = repository;
            _context = context;
        }

        public IActionResult List()
        {
            var model = _repository.GetAllProducts();

            var productDTO = _mapper.Map<List<ProductDTO>>(model);
            return View(productDTO);
        }

        private List<SelectListItem> GetCategory()
        {
            return _context.ProductCategories.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
                .ToList();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ViewModel();
            model.ProductCategories = GetCategory();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Date = DateTime.Now;
                _repository.Add(product);

                return RedirectToAction("List");
            }
            var model = new ViewModel();
            model.ProductCategories = GetCategory();
            model.Product = product;
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewModel vmodel = new ViewModel()
            {
                Product = _repository.GetProduct(id),
            };
            vmodel.ProductCategories = GetCategory();
            return View(vmodel);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            product.Date = DateTime.Now;
            _repository.Update(product);
            return RedirectToAction("List");
        }
        [Route("Home/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("List");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

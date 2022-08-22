using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICategoryService categoryService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductWithCategory());
        }

        public IActionResult Save()
        {
            FillDropdownWithCategories();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productDto);
                await _productService.AddAsync(product);
                await _unitOfWork.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            FillDropdownWithCategories();
            return View();
        }
        private void FillDropdownWithCategories()
        {
            var categories = _categoryService.GetAll().ToList();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
        }
    }
}

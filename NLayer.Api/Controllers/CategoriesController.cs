using Microsoft.AspNetCore.Mvc;
using NLayer.Api.Filters;
using NLayer.Core.Services;

namespace NLayer.Api.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // api/categories/GetSingleCategoryByIdWithProducts/2
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int id)
        {
            return CreateActionResult(await _service.GetSingleCategoryByIdWithProductsAsync(id));
        }
    }
}

using NLayer.Core.Dtos;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductWithCategory();
    }
}

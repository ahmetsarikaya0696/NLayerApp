namespace NLayer.Core.Dtos
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}

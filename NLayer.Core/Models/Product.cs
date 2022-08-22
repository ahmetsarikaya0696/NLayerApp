namespace NLayer.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public int ProductFeatureId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }

    }
}

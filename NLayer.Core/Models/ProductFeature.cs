namespace NLayer.Core.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Foreign Key
        public int ProductId { get; set; }

        // Navigation Property
        public Product Product { get; set; }
    }
}

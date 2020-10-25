namespace Andreys.ViewModels.Products
{
    public class ProductAddInputModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        public decimal Price { get; set; }
        
        public string Category { get; set; } // string in order to be mapped eaisilly in the ProductsController
        
        public string Gender { get; set; } // string in order to be mapped eaisilly in the ProductsController
    }
}

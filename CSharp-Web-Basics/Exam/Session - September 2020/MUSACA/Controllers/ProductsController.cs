using Musaca.Models;
using Musaca.Services;
using MUSACA.ViewModels.BindingModels.Products;
using MUSACA.ViewModels.Products;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Musaca.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            this.productService.Create(model.Name, model.Price);

            return this.Redirect("/Products/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var allProducts = this.productService.GetAllProducts();

            var allProductsView = this.productService
                .GetAllProducts()
                .Select(x => new AllProductViewModel { Name = x.Name, Price = x.Price })
                .ToList();

            return this.View(allProductsView);
        }

        [HttpPost]
        public IActionResult Order(OrderProductModel orderProductModel)
        {
            Product productToOrder = this.productService.GetByName(orderProductModel.Product);

            this.orderService.AddProductToCurrentActiveOrder(productToOrder.Id, this.User.Id);
            
            return this.Redirect("/");
        }

    }
}

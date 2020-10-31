using Microsoft.AspNetCore.Mvc;
using MUSACA.App.ViewModels.Orders;
using MUSACA.Models;
using MUSACA.Services;
using MUSACA.ViewModels.Products;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Musaca.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet(Url = "/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            OrderHomeViewModel orderHomeViewModel = new OrderHomeViewModel();

            if (this.IsUserSignedIn())
            {
                Order order = this.orderService
                    .GetCurrentActiveOrderByCashierId(this.GetUserId());
                if (order == null)
                {
                    return this.View(orderHomeViewModel);
                }
                orderHomeViewModel = order.ProjectTo<OrderHomeViewModel>();
               
                orderHomeViewModel.Products.Clear();

                foreach (var orderProduct in order.Products)
                {
                    ProductHomeViewModel productHomeViewModel = orderProduct.Product.ProjectTo<ProductHomeViewModel>();

                    orderHomeViewModel.Products.Add(productHomeViewModel);
                }
            }

            return this.View(orderHomeViewModel);
        }
    }
}

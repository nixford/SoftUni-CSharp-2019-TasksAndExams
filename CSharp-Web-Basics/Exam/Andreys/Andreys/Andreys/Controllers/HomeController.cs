using Andreys.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productService;
        public HomeController(IProductsService productService)
        {
            this.productService = productService;
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash() // Returns directly homepage trough get request 
        {
            return this.Index();
        }

        public HttpResponse Index() // Returns homepage trough localhost/Home/Index
        {
            if (IsUserLoggedIn())
            {
                var allProducts = productService.GetAll();

                return this.View(allProducts, "Home");
            }
            return this.View();
        }
    }
}

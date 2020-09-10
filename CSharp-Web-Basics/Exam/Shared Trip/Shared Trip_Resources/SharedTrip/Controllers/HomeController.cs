namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {        
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}
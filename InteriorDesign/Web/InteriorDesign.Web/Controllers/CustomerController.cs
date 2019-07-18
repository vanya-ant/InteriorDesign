namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

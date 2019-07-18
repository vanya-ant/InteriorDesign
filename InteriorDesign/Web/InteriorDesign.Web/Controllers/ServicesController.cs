namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : Controller
    {
        [HttpGet]
        public IActionResult Services()
        {
            return this.View();
        }
    }
}
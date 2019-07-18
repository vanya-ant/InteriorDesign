namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DesignerController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

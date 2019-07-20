namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DesignerController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

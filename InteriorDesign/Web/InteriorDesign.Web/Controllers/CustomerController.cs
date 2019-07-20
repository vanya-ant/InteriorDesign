namespace InteriorDesign.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

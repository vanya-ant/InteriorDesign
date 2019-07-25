namespace InteriorDesign.Web.Controllers
{
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Clients()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Contacts()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Services()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Team()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult IndexLoggedin()
        {
           var userId = this.userManager.GetUserId(this.HttpContext.User);
           ApplicationUser userFromDb = this.userManager.FindByIdAsync(userId).Result;

           var user = new UserViewModel
           {
               Username = userFromDb.UserName,
               Projects = userFromDb.Projects.Select(p => new ProjectViewModel
               {
                    Name = p.Name,
                    CustomerEmail = p.Customer.UserName,
                    DesignerEmail = p.Designer.UserName,
               }).ToList(),
           };

           return this.View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}

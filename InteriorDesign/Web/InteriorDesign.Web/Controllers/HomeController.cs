namespace InteriorDesign.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Web.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IContactService contactService;

        public HomeController(UserManager<ApplicationUser> userManager, IContactService contactService)
        {
            this.userManager = userManager;
            this.contactService = contactService;
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
        [HttpPost]
        public async Task<IActionResult> Contacts(ContactFormInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            Gmailer.GmailUsername = "interiorvdesignv@gmail.com";
            Gmailer.GmailPassword = "InteriorD3sign";
            Gmailer mailer = new Gmailer();

            mailer.ToEmail = "vanyad@gmail.com";
            mailer.Subject = model.Subject;
            mailer.Body = $"Hello InteriorDesign.com owner,\n\r" +
                          $"This is a new contact request from your website:\n\r" +
                          $"Full Name: {model.Name}\n\r" +
                          $"Email: {model.Email}\n\r" +
                          $"Message: {model.Message}\n\r" +
                          "Cheers,The InteriorDesign contact form";

            mailer.IsHtml = true;
            mailer.Send();

            return this.Redirect("Index");
        }

        [AllowAnonymous]
        [HttpGet]
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

            var allUserProjects = userFromDb.Projects.ToList();

            var result = AutoMapper.Mapper.Map<List<ProjectViewModel>>(allUserProjects);

            return this.View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}

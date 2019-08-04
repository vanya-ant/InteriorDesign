namespace InteriorDesign.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly IAdminService adminService;
        private readonly ICustomerService customerService;
        private readonly IDesignerService designerService;

        public HomeController(UserManager<ApplicationUser> userManager, IContactService contactService,
                              IAdminService adminService, ICustomerService customerService,
                              IDesignerService designerService)
        {
            this.userManager = userManager;
            this.contactService = contactService;
            this.adminService = adminService;
            this.customerService = customerService;
            this.designerService = designerService;
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
                          "Cheers,\n\rThe InteriorDesign contact form";

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
        public async Task<IActionResult> IndexLoggedin()
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            ApplicationUser userFromDb = this.userManager.FindByIdAsync(userId).Result;

            var projects = new List<Project>();

            if (await this.userManager.IsInRoleAsync(userFromDb, "Administrator"))
            {
                projects = await this.adminService.GetAllProjectsInProgress();
            }
            else if (await this.userManager.IsInRoleAsync(userFromDb, "Designer"))
            {
                projects = this.designerService.GetActiveDesignerProjects(userId).ToList();
            }
            else if (await this.userManager.IsInRoleAsync(userFromDb, "Customer"))
            {
                projects = this.customerService.GetActiveCustomerProjects(userId).ToList();
            }

            List<ProjectViewModel> result = new List<ProjectViewModel>();

            foreach (var project in projects)
            {
                var projectView = new ProjectViewModel
                {
                    Customer = project.Customer,
                    Designer = await this.userManager.FindByIdAsync(project.DesignerId),
                    DesignBoards = project.DesignBoards,
                    ProjectFiles = AutoMapper.Mapper.Map<IList<ProjectFileViewModel>>(project.ProjectFiles),
                    Id = project.Id,
                    Name = project.Name,
                    Status = project.Status.ToString(),
                    IsPublic = project.IsPublic,
                    ProjectReviews = project.ProjectReviews,
                };

                result.Add(projectView);
            }

            return this.View(result);
        }

        [Authorize]
        [HttpGet("/Home/AllCompleted")]
        public async Task<IActionResult> AllCompletedProjects()
        {
            var projectsFromDb = await this.adminService.GetAllCompletedProjects();

            List<ProjectViewModel> result = new List<ProjectViewModel>();

            foreach (var project in projectsFromDb)
            {
                var projectView = new ProjectViewModel
                {
                    Customer = project.Customer,
                    Designer = project.Designer,
                    DesignBoards = project.DesignBoards,
                    ProjectFiles = AutoMapper.Mapper.Map<IList<ProjectFileViewModel>>(project.ProjectFiles),
                    Id = project.Id,
                    Name = project.Name,
                    Status = project.Status.ToString(),
                    IsPublic = project.IsPublic,
                    ProjectReviews = project.ProjectReviews,
                };

                result.Add(projectView);
            }

            return this.View("IndexLoggedin", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}

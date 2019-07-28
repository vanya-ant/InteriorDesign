namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Web.Areas.Administration.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAdminServise adminService;

        public ProjectController(UserManager<ApplicationUser> userManager, IAdminServise adminService)
        {
            this.userManager = userManager;
            this.adminService = adminService;
        }

        [HttpGet("/Administration/Project/Create")]
        public async Task<IActionResult> Create()
        {
            var users = await this.userManager.GetUsersInRoleAsync("Customer");

            var designers = await this.userManager.GetUsersInRoleAsync("Designer");

            var viewModel = new AllUsersViewModel()
            {
                Customers = AutoMapper.Mapper.Map<IList<ApplicationUser>>(users),
                Designers = AutoMapper.Mapper.Map<IList<ApplicationUser>>(designers),
            };

            return this.View("Create", viewModel);
        }

        [HttpPost("/Administration/Project/Create")]
        public async Task<IActionResult> CreateProject(ProjectCreateInputModel model)
        {
            string projectName = this.Request.Form["projectName"].ToString();
            string customerEmail = this.Request.Form["customer"].ToString();
            string designerEmail = this.Request.Form["designer"].ToString();

            var project = new ProjectCreateInputModel
            {
                Name = projectName,
                Customer = await this.userManager.FindByNameAsync(customerEmail),
                Designer = await this.userManager.FindByNameAsync(designerEmail),
            };

            await this.adminService.CreateProject(project);

            return this.Redirect("/Home/IndexLoggedin");
        }
    }
}

namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Web.Areas.Administration.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProjectController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("/Administration/Project/Create")]
        public async Task<IActionResult> CreateProject()
        {
            var users = await this.userManager.GetUsersInRoleAsync("User");

            var designers = await this.userManager.GetUsersInRoleAsync("Designer");

            var viewModel = new AllUsersViewModel()
            {
                Users = AutoMapper.Mapper.Map<IEnumerable<UserViewModel>>(users),
                Designers = AutoMapper.Mapper.Map<IEnumerable<UserViewModel>>(designers),
            };

            return this.View("Create", viewModel);
        }

        [HttpPost("/Administration/Project/Create")]
        public async Task<IActionResult> CreateProject(ProjectViewModel model)
        {
            var project = new Project
            {
                Name = model.Name,
                Customer = await this.userManager.FindByEmailAsync(model.CustomerEmail),
                Designer = await this.userManager.FindByEmailAsync(model.DesignerEmail),
            };

            return this.Redirect("/Dashboard/IndexViewModel");
        }
    }
}

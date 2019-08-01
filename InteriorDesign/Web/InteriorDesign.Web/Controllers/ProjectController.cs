namespace InteriorDesign.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Web.Areas.Administration.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IAdminServise adminService;

        public ProjectController(UserManager<ApplicationUser> userManager, IProjectService projectService, IAdminServise adminService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.adminService = adminService;
        }

        [Authorize]
        [HttpGet("/Project/Create")]
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

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost("/Project/Create")]
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

        [Authorize]
        [HttpGet("/Project/Details")]
        public async Task<IActionResult> Details(string id)
        {
            var project = await this.projectService.GetProjectById(id);

            var projectFiles = await this.projectService.GetCurrentProjectFiles(id);
            var projectFilesResult = new List<ProjectFileViewModel>();

            foreach (var currentProjectFile in projectFiles)
            {
                var projectFile = new ProjectFileViewModel
                {
                    Id = currentProjectFile.Id,
                    Name = currentProjectFile.Name,
                    IsApproved = currentProjectFile.IsApproved,
                    IsPublic = currentProjectFile.IsPublic,
                    ProjectId = currentProjectFile.ProjectId,
                    Url = currentProjectFile.Url,
                };

                projectFilesResult.Add(projectFile);
            }

            var projectReviews = await this.projectService.GetCurrentProjectReviews(id);

            var projectDesignBoards = await this.projectService.GetCurrentProjectDesignBoards(id);

            var result = new ProjectDetailsViewModel
            {
                ProjectFiles = projectFilesResult,
                ProjectReviews = projectReviews,
                DesignBoards = projectDesignBoards,
                Name = project.Name,
                Id = id,
            };

            return this.View(result);
        }

        [Authorize]
        [HttpGet("/Project/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var projectFromDb = await this.projectService.GetProjectById(id);

            var project = new ProjectEditViewModel
            {
                Id = projectFromDb.Id,
                Name = projectFromDb.Name,
                Statuses = new List<ProjectStatus> { ProjectStatus.InProgress, ProjectStatus.Completed },
                ProjectFiles = AutoMapper.Mapper.Map<IList<ProjectFileViewModel>>(projectFromDb.ProjectFiles),
            };

            return this.View(project);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost("/Project/Edit")]
        public async Task<IActionResult> Update(string id, ProjectEditInputModel model)
        {
            if (this.ModelState.IsValid)
            {
               await this.projectService.EditProject(id, model);
            }

            return this.Redirect("/Home/IndexLoggedin");
        }

        [Authorize]
        [HttpGet("/Project/Delete")]
        public async Task<IActionResult> Delete(string projectId)
        {
            var projectFromDb = this.projectService.GetProjectById(projectId);

            this.adminService.DeleteProject(projectId);

            return this.Redirect("/Home/IndexLoggedin");
        }
    }
}

namespace InteriorDesign.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Common;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IAdminService adminService;
        private readonly IReviewService reviewService;
        private readonly IDesignBoardService designBoardService;

        public ProjectController(UserManager<ApplicationUser> userManager, IProjectService projectService, IAdminService adminService, IReviewService reviewService, IDesignBoardService designBoardService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.adminService = adminService;
            this.reviewService = reviewService;
            this.designBoardService = designBoardService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost("/Project/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(AllUsersViewModel model)
        {
            string projectName = this.Request.Form["projectName"].ToString();
            string customerEmail = this.Request.Form["Customer"].ToString();
            string designerEmail = this.Request.Form["Designer"].ToString();

            var project = new ProjectCreateInputModel
            {
                Name = projectName,
                Customer = await this.userManager.FindByNameAsync(customerEmail),
                Designer = await this.userManager.FindByNameAsync(designerEmail),
                IsPublic = model.IsPublic,
            };

            await this.adminService.CreateProject(project);

            return this.Redirect("/Home/IndexLoggedin");
        }

        [Authorize]
        [HttpGet("/Project/Details")]
        public async Task<IActionResult> Details(string id)
        {
            var project = await this.adminService.GetProjectById(id);

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

            var resultDesignBoards = new List<DesignBoardViewModel>();

            foreach (var designBoard in projectDesignBoards)
            {
                var board = new DesignBoardViewModel
                {
                     Id = designBoard.Id,
                     Name = designBoard.Name,
                     DesignReferences = await this.designBoardService.GetDesignBoardReferences(designBoard.Id),
                };

                resultDesignBoards.Add(board);
            }

            var result = new ProjectDetailsViewModel
            {
                ProjectFiles = projectFilesResult,
                ProjectReviews = projectReviews,
                DesignBoards = resultDesignBoards,
                Name = project.Name,
                Id = id,
            };

            return this.View(result);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpGet("/Project/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var projectFromDb = await this.adminService.GetProjectById(id);

            var project = new ProjectEditViewModel
            {
                Id = projectFromDb.Id,
                Name = projectFromDb.Name,
                Statuses = new List<ProjectStatus> { ProjectStatus.InProgress, ProjectStatus.Completed },
                ProjectFiles = AutoMapper.Mapper.Map<IList<ProjectFileViewModel>>(projectFromDb.ProjectFiles),
            };

            return this.View(project);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [ValidateAntiForgeryToken]
        [HttpPost("/Project/Edit")]
        public async Task<IActionResult> Edit(string id, ProjectEditInputModel model)
        {
            if (this.ModelState.IsValid)
            {
               await this.adminService.EditProject(model);
            }

            return this.Redirect("/Home/IndexLoggedin");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost("/Project/Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await this.adminService.DeleteProject(id);

            return this.Redirect("/Home/IndexLoggedin");
        }

        [Authorize]
        [HttpGet("/Project/Review")]
        public async Task<IActionResult> Review()
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

            return this.View(result);
        }

        [Authorize]
        [HttpPost("/Project/Review")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(string id)
        {
            var customer = await this.userManager.FindByEmailAsync(this.User.Identity.Name);

            ReviewCreateModel model = new ReviewCreateModel
            {
                ProjectId = id,
                CustomerId = customer.Id,
                Review = this.Request.Form["review-body"].ToString(),
            };

            if (this.ModelState.IsValid)
            {
                 await this.reviewService.CreateReview(model);
            }

            return this.RedirectToAction("Review", "Project", new { id = model.ProjectId });
        }
    }
}

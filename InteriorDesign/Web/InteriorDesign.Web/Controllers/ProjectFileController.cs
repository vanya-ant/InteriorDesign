namespace InteriorDesign.Web.Controllers
{
    using System.Threading.Tasks;

    using InteriorDesign.Common;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectFileController : BaseController
    {
        private readonly IProjectFileService projectFileService;
        private readonly IAdminService adminService;

        public ProjectFileController(IProjectFileService projectFileService, IAdminService adminService)
        {
            this.projectFileService = projectFileService;
            this.adminService = adminService;
        }

        [Authorize(Roles = GlobalConstants.DesignerRoleName)]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpGet("/ProjectFile/Create")]
        public async Task<IActionResult> CreateProjectFile(string id)
        {
            var projectId = new ProjectFileCreateModel
            {
                ProjectId = id,
            };

            return this.View(projectId);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [Authorize(Roles = GlobalConstants.DesignerRoleName)]
        [HttpPost("/ProjectFile/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProjectFile(ProjectFileCreateModel model)
        {
            await this.projectFileService.AddProjectFile(model);

            return this.Redirect("/Home/IndexLoggedin");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var projectFile = await this.projectFileService.GetCurrentProjectFile(id);
            var projectId = projectFile.ProjectId;

            await this.projectFileService.DeleteProjectFile(id);

            await this.adminService.DeleteProjectFile(id);

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }

        [Authorize]
        [HttpPost("/ProjectFile/Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(string id)
        {
            await this.projectFileService.ApproveFile(id);

            var projectFile = await this.projectFileService.GetCurrentProjectFile(id);

            var projectId = projectFile.ProjectId;

            return this.RedirectToAction("Details", "Project", new { id = projectId });
        }
    }
}

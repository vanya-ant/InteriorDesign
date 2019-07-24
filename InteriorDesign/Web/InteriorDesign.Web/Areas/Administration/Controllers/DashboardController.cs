namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Web.Controllers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : BaseController
    {
        private readonly ApplicationDbContext context;

        public DashboardController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var projects = this.context.Projects.Where(p => p.Status == ProjectStatus.InProgress);

            foreach (var project in projects)
            {
                var projectsView = AutoMapper.Mapper.Map<ProjectViewModel>(project);
            }

            return this.View(projects);
        }
    }
}

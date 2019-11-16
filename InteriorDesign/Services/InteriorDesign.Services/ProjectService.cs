namespace InteriorDesign.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;

    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext context;

        public ProjectService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<ProjectFile>> GetCurrentProjectFiles(string id)
        {
            var result = this.context.ProjectFiles.Where(x => x.ProjectId == id).OrderBy(x => x.Url).ToList();

            return result;
        }

        public async Task<IList<ProjectReview>> GetCurrentProjectReviews(string id)
        {
            var result = this.context.ProjectReviews.Where(x => x.ProjectId == id).ToList();

            return result;
        }

        public async Task<IList<DesignBoard>> GetCurrentProjectDesignBoards(string id)
        {
            var result = this.context.DesignBoards.Where(x => x.ProjectId == id).ToList();

            return result;
        }

        public ICollection<Project> GetActiveDesignerProjects(string designerId)
        {
            var allActiveProjects = this.context.Projects.Where(p => p.DesignerId == designerId && p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }

        public ICollection<Project> GetActiveCustomerProjects(string customerId)
        {
            var allActiveProjects = this.context.Projects.Where(p => p.CustomerId == customerId && p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }
    }
}

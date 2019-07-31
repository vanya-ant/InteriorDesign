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

        public async Task<Project> GetProjectById(string id)
        {
            return this.context.Projects.SingleOrDefault(x => x.Id == id);
        }

        public async Task EditProject(string id, ProjectEditInputModel model)
        {
            var projectFromBd = await this.GetProjectById(id);

            if (projectFromBd.Status != model.Status && projectFromBd.Name != model.Name)
            {
                projectFromBd.Status = model.Status;
                projectFromBd.Name = model.Name;
            }

            this.context.Update(projectFromBd);

            this.context.SaveChanges();
        }

        public async Task<IList<ProjectFile>> GetCurrentProjectFiles(string id)
        {
            var projectFiles = this.context.ProjectFiles.Where(x => x.ProjectId == id).ToList();

            return projectFiles;
        }

        public async Task<IList<ProjectReview>> GetCurrentProjectReviews(string id)
        {
            return this.context.ProjectReviews.Where(x => x.ProjectId == id).ToList();
        }

        public async Task<IList<DesignBoard>> GetCurrentProjectDesignBoards(string id)
        {
            return this.context.DesignBoards.Where(x => x.ProjectId == id).ToList();
        }
    }
}

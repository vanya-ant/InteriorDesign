namespace InteriorDesign.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
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

            projectFromBd.Status = model.Status;
            projectFromBd.Name = model.Name;

            this.context.Update(projectFromBd);

            this.context.SaveChanges();
        }
    }
}

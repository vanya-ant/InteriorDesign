namespace InteriorDesign.Services
{
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

        public async Task<string> CreateProject(ProjectCreateInputModel model)
        {
           if (this.context.Projects.Any(p => p.Name == model.Name))
           {
                return $"Project with name {model.Name} alreday exists!";
            }

           var project = await this.context.Projects.AddAsync(new Project
            {
                Name = model.Name,
                Designer = model.Designer,
                Customer = model.Customer,
            });

           await this.context.SaveChangesAsync();

           return $"New project created successfuly!";
        }
    }
}

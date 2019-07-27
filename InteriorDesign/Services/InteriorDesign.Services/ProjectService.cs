namespace InteriorDesign.Services
{
    using System.ComponentModel.DataAnnotations;
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

        public async Task<ValidationResult> CreateProject(ProjectCreateInputModel model)
        {
           if (this.context.Projects.Any(p => p.Name == model.Name))
           {
                return new ValidationResult($"Project with name {model.Name} alreday exists!");
           }

           var project = await this.context.Projects.AddAsync(new Project
            {
                Name = model.Name,
                Designer = model.Designer,
                Customer = model.Customer,
            });

           await this.context.SaveChangesAsync();

           return new ValidationResult($"New project created successfuly!");
        }
    }
}

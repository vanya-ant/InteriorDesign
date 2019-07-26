namespace InteriorDesign.Services.Contracts
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using InteriorDesign.Models.InputModels;

    public interface IProjectService
    {
       Task<ValidationResult> CreateProject(ProjectCreateInputModel model);
    }
}

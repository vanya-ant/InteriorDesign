namespace InteriorDesign.Services.Contracts
{
    using System.Threading.Tasks;

    using InteriorDesign.Models.InputModels;

    public interface IProjectService
    {
       Task<string> CreateProject(ProjectCreateInputModel model);
    }
}

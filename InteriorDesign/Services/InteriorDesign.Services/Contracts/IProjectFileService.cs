namespace InteriorDesign.Services.Contracts
{
    using System.Threading.Tasks;

    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;

    public interface IProjectFileService
    {
        Task<ProjectFileVewModel> AddProjectFile(string projectId, ProjectFileCreateModel projectFile);

        Task<bool> SaveAll();
    }
}

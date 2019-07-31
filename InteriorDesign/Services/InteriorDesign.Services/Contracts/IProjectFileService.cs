namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;

    public interface IProjectFileService
    {
        Task<ProjectFileViewModel> AddProjectFile(ProjectFileCreateModel projectFile);

        Task<ProjectViewModel> GetCurrentProject(string id);

        Task<bool> SaveAll();
    }
}

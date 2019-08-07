namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;

    public interface IAdminService
    {
        Task<Project> GetProjectById(string id);

        Task<ValidationResult> CreateProject(ProjectCreateInputModel model);

        Task EditProject(ProjectEditInputModel model);

        Task AddDesigner(string email);

        Task<List<Project>> GetAllProjectsInProgress();

        Task<List<Project>> GetAllCompletedProjects();

        Task DeleteProject(string id);

        Task DeleteProjectFile(string id);
    }
}

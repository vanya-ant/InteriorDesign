namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;

    public interface IAdminServise
    {
        Task<ValidationResult> CreateProject(ProjectCreateInputModel model);

        Task AddDesigner(string email);

        ICollection<Project> GetAllProjectsInProgress();

        ICollection<Project> GetAllCompletedProjects();

        void EditProject(string id);

        void AddProjectFile(ProjectFileCreateModel projectFile);

        void DeleteProject(string id);

        void DeleteProjectFIle(string id);

        void DeleteDeigner(string id);

        void DeleteReview(string id);
    }
}

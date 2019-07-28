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

        void EditProject();

        void AddProjectFile();

        void DeleteProjectFIle();

        void DeleteDeigner();

        void DeleteReview();
    }
}

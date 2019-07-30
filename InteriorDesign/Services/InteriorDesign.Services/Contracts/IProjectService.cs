namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;

    public interface IProjectService
    {
        Task<Project> GetProjectById(string id);

        Task EditProject(string id, ProjectEditInputModel model);
    }
}

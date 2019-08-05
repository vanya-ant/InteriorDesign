namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;

    public interface IProjectService
    {
        Task<IList<ProjectFile>> GetCurrentProjectFiles(string id);

        Task<IList<ProjectReview>> GetCurrentProjectReviews(string id);

        Task<IList<DesignBoard>> GetCurrentProjectDesignBoards(string id);

        ICollection<Project> GetActiveCustomerProjects(string customerId);

        ICollection<Project> GetActiveDesignerProjects(string designerId);
    }
}

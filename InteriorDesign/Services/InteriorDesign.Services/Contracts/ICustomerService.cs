namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;

    public interface ICustomerService
    {
        ICollection<Project> GetActiveCustomerProjects(string customerId);

        void ApproveProjectFile();

        void PreviewProject();
    }
}

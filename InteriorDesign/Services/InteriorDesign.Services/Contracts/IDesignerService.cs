namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;

    public interface IDesignerService
    {
        ICollection<Project> GetActiveDesignerProjects(string designerId);

    }
}

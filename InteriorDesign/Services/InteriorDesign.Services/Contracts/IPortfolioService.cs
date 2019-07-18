namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;

    public interface IPortfolioService
    {
        ICollection<ProjectFile> GetPublicProjectFiles();
    }
}

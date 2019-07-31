namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;

    public interface IPortfolioService
    {
        ICollection<ProjectFileViewModel> GetPublicProjectFiles();
    }
}

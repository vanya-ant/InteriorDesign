namespace InteriorDesign.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;

    public class PortfolioService : IPortfolioService
    {
        private readonly ApplicationDbContext context;

        public PortfolioService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<ProjectFileViewModel> GetPublicProjectFiles()
        {
            var publicProjectFiles = this.context.ProjectFiles
                    .Where(x => x.IsPublic).ToList();

            var result = new List<ProjectFileViewModel>();

            foreach (var projectFile in publicProjectFiles)
            {
                if (projectFile.Url.EndsWith(".jpg") || projectFile.Url.EndsWith(".png"))
                {
                    result.Add(new ProjectFileViewModel
                    {
                        Url = projectFile.Url,
                    });
                }
            }

            return result;
        }
    }
}

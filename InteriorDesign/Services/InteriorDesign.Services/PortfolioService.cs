namespace InteriorDesign.Services
{
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PortfolioService : IPortfolioService
    {
        private readonly ApplicationDbContext context;

        public PortfolioService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<ProjectFile> GetPublicProjectFiles()
        {
            string ext = string.Empty;

            var publicProjectFiles = this.context.ProjectFiles
                    .Where(x => x.IsPublic).ToList();

            return publicProjectFiles;
        }
    }
}

namespace InteriorDesign.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Services.Contracts;

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

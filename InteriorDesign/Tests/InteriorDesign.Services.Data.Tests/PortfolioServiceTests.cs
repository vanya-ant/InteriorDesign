namespace InteriorDesign.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Xunit;

    public class PortfolioServiceTests
    {
        private IPortfolioService portfolioService;

        private List<Project> AddPublicProjects()
        {
            return new List<Project>()
            {
                 new Project
                    {
                        IsPublic = true,
                        Name = "Project1",
                        Customer = new ApplicationUser(),
                        Designer = new ApplicationUser(),
                        ProjectFiles = new List<ProjectFile>()
                        {
                            new ProjectFile
                            {
                                 IsPublic = true,
                                 Name = string.Empty,
                                 Url = "https://1.jpg",
                                 ProjectId = string.Empty,
                            },
                        },
                    },
                 new Project
                    {
                        IsPublic = true,
                        Name = "Project2",
                        Customer = new ApplicationUser(),
                        Designer = new ApplicationUser(),
                        ProjectFiles = new List<ProjectFile>()
                        {
                            new ProjectFile
                            {
                                 IsPublic = true,
                                 Name = string.Empty,
                                 Url = "https://2.jpg",
                                 ProjectId = string.Empty,
                            },
                        },
                    },
            };
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.AddRange(this.AddPublicProjects());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetPublicProjects_ShouldReturnCorrectNumber()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.portfolioService = new PortfolioService(context);

            var result = this.portfolioService.GetPublicProjectFiles().Count;

            Assert.Equal(2, result);
        }
    }
}

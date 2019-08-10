namespace InteriorDesign.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class ProjectFileServiceTests
    {
        private IProjectFileService projectFileService;

        public ProjectFileServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        private ApplicationUser AddDesigner()
        {
            return new ApplicationUser
            {
                Email = "designer@designer.com",
                PasswordHash = 5.GetHashCode().ToString(),
            };
        }

        private ApplicationUser AddCustomer()
        {
            return new ApplicationUser
            {
                Email = "customer@customer.com",
                PasswordHash = 5.GetHashCode().ToString(),
            };
        }

        private Project AddProject()
        {
            var model = new ProjectCreateInputModel
            {
                Designer = new ApplicationUser
                {
                    Id = new Guid("db2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                    Email = "customer@customer.com",
                    PasswordHash = 5.GetHashCode().ToString(),
                },
                Customer = new ApplicationUser
                {
                    Id = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                    Email = "customer@customer.com",
                    PasswordHash = 5.GetHashCode().ToString(),
                },
                Name = "Test",
                IsPublic = true,
            };

            var project = new Project
            {
                Id = new Guid("bb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                DesignerId = model.Designer.Id,
                CustomerId = model.Customer.Id,
                Name = model.Name,
                IsPublic = model.IsPublic,
            };

            var revew = new ProjectReview
            {
                ProjectId = project.Id,
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                Review = "First Review",
            };

            var designBoard = new DesignBoard
            {
                ProjectId = project.Id,
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                Id = new Guid("de2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                Name = "Test Design Board",
                DesignReferences = new List<DesignReference>(),
            };

            var designRefernce = new DesignReference
            {
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                ImageUrl = "https://test.test",
                DesignBoardId = "de2bd817-98cd-4cf3-a80a-53ea0cd9c200",
            };

            project.ProjectReviews.Add(revew);
            project.DesignBoards.Add(designBoard);
            project.DesignBoards[0].DesignReferences.Add(designRefernce);

            return project;
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.Add(this.AddDesigner());
            context.Add(this.AddCustomer());
            context.Add(this.AddProject());
            await context.SaveChangesAsync();
        }

        // GetCurrentProject(string id)
        [Fact]
        private async Task GetCurrentProject_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            var cloudinary = new Mock<CloudinaryService>().Object;

            this.projectFileService = new ProjectFileService(cloudinary, context);

            var result = await this.projectFileService.GetCurrentProject("bb2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            Assert.Equal("Test", result.Name);
            Assert.True(result.IsPublic);
        }

        // GetCurrentProjectFile(string id)
        // DeleteProjectFile(string id)
    }
}

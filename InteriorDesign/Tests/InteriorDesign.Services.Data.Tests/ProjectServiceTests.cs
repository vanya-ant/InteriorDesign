namespace InteriorDesign.Services.Data.Tests
{
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ProjectServiceTests
    {
        private IProjectService projectService;
        private IProjectFileService projectFileService;

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
                    Email = "customer@customer.com",
                    PasswordHash = 5.GetHashCode().ToString(),
                },
                Customer = new ApplicationUser
                {
                    Email = "customer@customer.com",
                    PasswordHash = 5.GetHashCode().ToString(),
                },
                Name = "Test",
                IsPublic = true,
            };

            var result = new Project
            {
                DesignerId = model.Designer.Id,
                CustomerId = model.Customer.Id,
                Name = model.Name,
                IsPublic = model.IsPublic,
            };

            var file = new Mock<IFormFile>();

            var projectFile = new ProjectFileCreateModel
            {
                File = file.Object,
                IsPublic = true,
                IsApproved = false,
                Name = "TestProjectFile",
                ProjectId = result.Id,
            };

            var resultProjectFile = new ProjectFile
            {
                IsApproved = projectFile.IsApproved,
                IsPublic = projectFile.IsPublic,
                Name = projectFile.Name,
                ProjectId = projectFile.ProjectId,
            };

            result.ProjectFiles.Add(resultProjectFile);

            return result;
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.Add(this.AddDesigner());
            context.Add(this.AddCustomer());
            context.Add(this.AddProject());
            await context.SaveChangesAsync();
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        // GetCurrentProjectFiles(string id)
        [Fact]
        private async Task GetCurrentProjectFiles_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();

            await this.SeedData(context);

            this.projectService = new ProjectService(context);
            var result = context.ProjectFiles.ToList().Count;

            Assert.Equal(1, result);
        }

        // GetCurrentProjectReviews(string id)
        // GetCurrentProjectDesignBoards(string id)
        // GetActiveDesignerProjects(string designerId)
        // GetActiveCustomerProjects(string customerId)
    }
}

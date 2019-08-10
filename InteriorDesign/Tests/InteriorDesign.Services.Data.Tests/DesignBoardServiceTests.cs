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

    public class DesignBoardServiceTests
    {
        private IDesignBoardService designBoardServce;

        public DesignBoardServiceTests()
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

            var projectFile = new ProjectFileCreateModel
            {
                File = new Mock<IFormFile>().Object,
                IsApproved = false,
                IsPublic = true,
                Name = "TestProjectFile",
                ProjectId = project.Id,
            };

            var projectFileResult = new ProjectFile
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                IsApproved = projectFile.IsApproved,
                IsPublic = projectFile.IsPublic,
                Name = "TestProjectFile.jpg",
                ProjectId = project.Id,
            };

            var revew = new ProjectReview
            {
                ProjectId = project.Id,
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                Review = "First Review",
            };

            var designRefernce = new DesignReference
            {
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                ImageUrl = "https://test.test",
                DesignBoardId = "de2bd817-98cd-4cf3-a80a-53ea0cd9c200",
            };

            project.ProjectReviews.Add(revew);
            project.ProjectFiles.Add(projectFileResult);
            //project.DesignBoards[0].DesignReferences.Add(designRefernce);

            return project;
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.Add(this.AddDesigner());
            context.Add(this.AddCustomer());
            context.Add(this.AddProject());
            await context.SaveChangesAsync();
        }


        // AddDesignBoard(DesignBoardCreateInputModel model)
        [Fact]
        private async Task AddDesignBoard_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.designBoardServce = new DesignBoardService(context);

            var designBoard = new DesignBoardCreateInputModel
            {
                ProjectId = "bb2bd817-98cd-4cf3-a80a-53ea0cd9c200",
                CustomerId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200").ToString(),
                Name = "Test Design Board",
            };

            var result = await this.designBoardServce.AddDesignBoard(designBoard);

            Assert.Equal("DesignBoard created successfully!", result);
        }

        // AddDesignReference(ReferenceInputModel model)
        [Fact]
        private async Task AddDesignReference_ShouldWorkFine()
        {

        }

        // GetDesignBoardReferences(string id)
        // GetCurrentDesignBoard(string id)
    }
}

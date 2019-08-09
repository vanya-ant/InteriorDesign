﻿namespace InteriorDesign.Services.Data.Tests
{
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ProjectServiceTests
    {
        private IProjectService projectService;

        public ProjectServiceTests()
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
            project.ProjectFiles.Add(projectFileResult);
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

        // GetCurrentProjectFiles(string id)
        [Fact]
        private async Task GetCurrentProjectFiles_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            //var cloudinary = new Mock<CloudinaryService>().Object;

            this.projectService = new ProjectService(context);

            var result = await this.projectService.GetCurrentProjectFiles("bb2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            Assert.Equal(1, result.Count);
        }

        // GetCurrentProjectReviews(string id)
        [Fact]
        private async Task GetCurrentProjectReviews_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.projectService = new ProjectService(context);

            var result = await this.projectService.GetCurrentProjectReviews("bb2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            Assert.Equal(1, result.Count);
            Assert.Equal("First Review", result[0].Review);
        }

        // GetCurrentProjectDesignBoards(string id)
        [Fact]
        private async Task GetCurrentProjectDesignBoards_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.projectService = new ProjectService(context);

            var result = await this.projectService.GetCurrentProjectDesignBoards("bb2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            var designReferenceUrl = result[0].DesignReferences.FirstOrDefault().ImageUrl;

            Assert.Equal(1, result[0].DesignReferences.Count);
            Assert.Equal("https://test.test", designReferenceUrl);
        }
  
        // GetActiveDesignerProjects(string designerId)
        [Fact]
        private async Task GetActiveDesignerProjects_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.projectService = new ProjectService(context);

            var result = this.projectService.GetActiveDesignerProjects("db2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            Assert.Single(result);
        }

        // GetActiveCustomerProjects(string customerId)
        [Fact]
        private async Task GetActiveCustomerProjects_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            this.projectService = new ProjectService(context);

            var result = this.projectService.GetActiveCustomerProjects("cb2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            Assert.Single(result);
        }
    }
}

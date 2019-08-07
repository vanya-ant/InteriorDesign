namespace InteriorDesign.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using Xunit;

    public class AdminServiceTests
    {
        private IAdminService adminService;

        public AdminServiceTests()
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

        private async Task SeedData(ApplicationDbContext context)
        {
            context.Add(this.AddDesigner());
            context.Add(this.AddCustomer());
            await context.SaveChangesAsync();
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        // CreateProject
        [Fact]
        private async Task CreateProject_ShouldCorrectlyAddProject()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            var userManager = this.GetMockUserManager().Object;

            this.adminService = new AdminService(userManager, context);

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

            var result = await this.adminService.CreateProject(model);

            Assert.Equal("New project created successfuly!", result.ToString());
        }

        [Fact]
        private async Task CreateProject_ShouldThrowExeption()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            var userManager = this.GetMockUserManager().Object;

            this.adminService = new AdminService(userManager, context);

            var test1 = new ProjectCreateInputModel
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

            var test2 = new ProjectCreateInputModel
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

            await this.adminService.CreateProject(test1);
            var result2 = await this.adminService.CreateProject(test2);

            Assert.Equal("Project with name Test alreday exists!", result2.ToString());
        }

        // EditProject
        [Fact]
        private async Task EditProject_ShouldWorkFine()
        {
            var context = ContextInitializer.InitializeContext();
            await this.SeedData(context);

            var userManager = this.GetMockUserManager().Object;

            this.adminService = new AdminService(userManager, context);

            var test1 = new ProjectCreateInputModel
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

            await this.adminService.CreateProject(test1);

            var test2 = AutoMapper.Mapper.Map<ProjectEditInputModel>(test1);

            test2.Name = "Test-Edited";

            await this.adminService.EditProject(test2);

            Assert.Equal("Test-Edited", test2.Name);
        }

        private async Task EditProject_ShouldThrowExeption()
        {

        }

        // GetAllCompletedProjects
        private async Task GetAllCompletedProjects_ShouldWorkFine()
        {

        }

        // GetAllProjectsInProgress
        private async Task GetAllProjectsInProgress_ShouldWorkFine()
        {

        }

        // DeleteProjectFile
        private async Task DeleteProject_ShouldWorkFine()
        {

        }
    }
}

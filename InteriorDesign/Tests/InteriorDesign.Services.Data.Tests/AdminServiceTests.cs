namespace InteriorDesign.Services.Data.Tests
{
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Services.Contracts;
    using InteriorDesign.Services.Data.Tests.Common;
    using Microsoft.AspNetCore.Identity;
    using Moq;

    using Xunit;

    public class AdminServiceTests
    {
        private IAdminService adminService;

        private ApplicationUser AddDesigner()
        {
            return new ApplicationUser
            {
                Email = "designer@designer.com",
                PasswordHash = 5.GetHashCode().ToString(),
            };
        }

        private async Task SeedData(ApplicationDbContext context)
        {
            context.AddRange(this.AddDesigner());
            await context.SaveChangesAsync();
        }

        // CreateProject
        // EditProject
        // GetAllCompletedProjects
        // GetAllProjectsInProgress
        // DeleteProjectFile
   
    }
}

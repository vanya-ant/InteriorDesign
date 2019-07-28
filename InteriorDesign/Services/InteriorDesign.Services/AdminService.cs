namespace InteriorDesign.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdminService : IAdminServise
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public AdminService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task AddDesigner(string email)
        {
            var userToBeAssigned = await this.userManager.FindByNameAsync(email);

            if (!await this.userManager.IsInRoleAsync(userToBeAssigned, "Designer"))
            {
                await this.userManager.AddToRoleAsync(userToBeAssigned, "Designer");
            }
        }

        public void AddProjectFile()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> CreateProject(ProjectCreateInputModel model)
        {
            if (this.context.Projects.Any(p => p.Name == model.Name))
            {
                return new ValidationResult($"Project with name {model.Name} alreday exists!");
            }

            var project = await this.context.Projects.AddAsync(new Project
            {
                Name = model.Name,
                Designer = model.Designer,
                Customer = model.Customer,
            });

            await this.context.SaveChangesAsync();

            return new ValidationResult($"New project created successfuly!");
        }

        public void DeleteDeigner()
        {
            throw new NotImplementedException();
        }

        public void DeleteProjectFIle()
        {
            throw new NotImplementedException();
        }

        public void DeleteReview()
        {
            throw new NotImplementedException();
        }

        public void EditProject()
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> GetAllProjectsInProgress()
        {
            var allActiveProjects = this.context.Projects.Where(p => p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }
    }
}

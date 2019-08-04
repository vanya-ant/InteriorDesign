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

    public class AdminService : IAdminService
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

        public async Task<Project> GetProjectById(string id)
        {
           var project = this.context.Projects.Where(x => x.Id == id).SingleOrDefault();

           return project;
        }

        public async Task EditProject(string id, ProjectEditInputModel model)
        {
            var projectFromBd = await this.GetProjectById(id);

            if (projectFromBd.Status != model.Status || projectFromBd.Name != model.Name || projectFromBd.IsPublic != model.IsPublic)
            {
                projectFromBd.Status = model.Status;
                projectFromBd.Name = model.Name;
                projectFromBd.IsPublic = model.IsPublic;
            }

            this.context.Projects.Update(projectFromBd);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDeigner(string id)
        {
            var designerToBeDeleted = this.context.Users.Where(x => x.Id == id).SingleOrDefault();

            designerToBeDeleted.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteProject(string id)
        {
            var project = await this.GetProjectById(id);

            this.context.Projects.Remove(project);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteProjectFile(string id)
        {
            var projectFileToBeDeleted = this.context.ProjectFiles.Where(x => x.Id == id).SingleOrDefault();

            this.context.ProjectFiles.Remove(projectFileToBeDeleted);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteReview(string id)
        {
            var projectReviewToBeDeleted = this.context.ProjectReviews.Where(x => x.Id == id).SingleOrDefault();

            this.context.ProjectReviews.Remove(projectReviewToBeDeleted);

            await this.context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllCompletedProjects()
        {
            var allCompletedProjects = this.context.Projects.Where(p => p.Status == ProjectStatus.Completed).ToList();

            return allCompletedProjects;
        }

        public async Task<List<Project>> GetAllProjectsInProgress()
        {
            var allActiveProjects = this.context.Projects.Where(p => p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }
    }
}

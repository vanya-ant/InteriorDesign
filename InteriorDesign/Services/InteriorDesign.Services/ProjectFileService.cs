namespace InteriorDesign.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectFileService : IProjectFileService
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly ApplicationDbContext context;

        public ProjectFileService(ICloudinaryService cloudinaryService, ApplicationDbContext context)
        {
            this.context = context;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<ProjectFileViewModel> AddProjectFile(ProjectFileCreateModel projectFile)
        {
            var project = this.context
               .Projects
               .Where(p => p.Id == projectFile.ProjectId)
               .SingleOrDefault();

            var file = projectFile.File;

            if (this.context.ProjectFiles.Any(p => p.Name == projectFile.Name))
            {
                return null;
            }

            string projectFileUrl = await this.cloudinaryService.UploadProjectFileAsync(projectFile.File, Guid.NewGuid().ToString());

            var newFile = new ProjectFile
            {
                IsApproved = projectFile.IsApproved,
                AddedOn = projectFile.AddedOn,
                ProjectId = project.Id,
                IsPublic = projectFile.IsPublic,
                Name = projectFile.Name,
                Url = projectFileUrl,
            };

            project.ProjectFiles.Add(newFile);
            await this.context.SaveChangesAsync();

            var result = new ProjectFileViewModel
            {
                IsApproved = newFile.IsApproved,
                IsPublic = newFile.IsPublic,
                Url = newFile.Url,
            };

            return result;
        }

        public async Task<ProjectViewModel> GetCurrentProject(string id)
        {
            var project = this.context.Projects.Where(x => x.Id == id);

            var result = AutoMapper.Mapper.Map<ProjectViewModel>(project);

            return result;
        }

        public async Task<ProjectFileViewModel> GetCurrentProjectFile(string id)
        {
            var project = this.context.ProjectFiles.Where(x => x.Id == id);

            var result = AutoMapper.Mapper.Map<ProjectFileViewModel>(project);

            return result;
        }

        public async Task DeleteProjectFile(string id)
        {
            var projectFileToDelete = await this.GetCurrentProjectFile(id);

            await this.cloudinaryService.DeleteImage(projectFileToDelete.Url);
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}

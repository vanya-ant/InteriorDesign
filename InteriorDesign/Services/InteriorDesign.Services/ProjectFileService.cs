namespace InteriorDesign.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;

    public class ProjectFileService : IProjectFileService
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly ApplicationDbContext context;

        public ProjectFileService(ICloudinaryService cloudinaryService, ApplicationDbContext context)
        {
            this.context = context;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<ProjectFileVewModel> AddProjectFile(ProjectFileCreateModel projectFile)
        {
            var project = this.context
               .Projects
               .Where(p => p.Id == projectFile.ProjectId)
               .SingleOrDefault();

            var file = projectFile.File;

            string projectFileUrl = await this.cloudinaryService.UploadProjectFileAsync(projectFile.File, projectFile.Name);

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
            await this.SaveAll();

            return new ProjectFileVewModel
            {
                IsApproved = false,
                Url = newFile.Url,
                IsPublic = false,
                PublicId = Guid.NewGuid().ToString(),
            };
        }

        public async Task<ProjectViewModel> GetCurrentProject(string id)
        {
            var project = this.context.Projects.Where(x => x.Id == id);

            var result = AutoMapper.Mapper.Map<ProjectViewModel>(project);

            return result;
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}

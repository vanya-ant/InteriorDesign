namespace InteriorDesign.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<ProjectFileVewModel> AddProjectFile(string projectId, ProjectFileCreateModel projectFile)
        {
            var project = this.context
               .Projects
               .Where(p => p.Id == projectId)
               .SingleOrDefault();

            var file = projectFile.File;

            string projectFileUrl = await this.cloudinaryService.UploadProjectFileAsync(projectFile.File, project.Customer + projectFile.AddedOn.ToString("dd-MM-yyyy HH:mm"));

            var newFile = new ProjectFile
            {
                Url = projectFile.Url,
                IsApproved = false,
                AddedOn = projectFile.AddedOn,
                ProjectId = project.Id,
                PublicId = projectFile.PublicId,
                Project = project,
                IsPublic = false,
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

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}

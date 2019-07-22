namespace InteriorDesign.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.Extensions.Options;

    public class ProjectFileService : IProjectFileService
    {
        private readonly IDesignerService designerService;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private readonly Cloudinary cloudinary;
        private readonly ApplicationDbContext context;

        public ProjectFileService(
                                  IDesignerService designerService,
                                  IOptions<CloudinarySettings> cloudinaryConfig,
                                  ApplicationDbContext context)
        {
            this.context = context;
            this.designerService = designerService;
            this.cloudinaryConfig = cloudinaryConfig;
        }

        public async Task<ProjectFileVewModel> AddProjectFile(string projectId, ProjectFileCreateModel projectFile)
        {
            var project = this.context
               .Projects
               .Where(p => p.Id == projectId)
               .SingleOrDefault();

            var file = projectFile.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                                        .Width(500).Height(500)
                                        .Crop("fill")
                                        .Gravity("face"),
                    };

                    uploadResult = this.cloudinary.Upload(uploadParams);
                }
            }

            projectFile.Url = uploadResult.Uri.ToString();
            projectFile.PublicId = uploadResult.PublicId;

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

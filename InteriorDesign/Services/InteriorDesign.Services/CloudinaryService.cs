namespace InteriorDesign.Services
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;
        public CloudinaryService()
        {

        }

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadProjectFileAsync(IFormFile projectFile, string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await projectFile.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "project_files",
                    File = new FileDescription(fileName, ms),
                };

                uploadResult = this.cloudinaryUtility.Upload(uploadParams);
            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }

        public async Task DeleteImage(string url)
        {
            this.cloudinaryUtility.DeleteResources(url);
        }
    }
}

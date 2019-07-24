namespace InteriorDesign.Services.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadProjectFileAsync(IFormFile projectFile, string fileName);
    }
}

namespace InteriorDesign.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using InteriorDesign.Models.Attributes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [RequestSizeLimit(10485760)]
    public class ProjectFileCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [FileUploadValidationAttribute(ErrorMessage = "Please select a jpg/png/pdf file.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        public IFormFile File { get; set; }

        public DateTime AddedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public string ProjectId { get; set; }

    }
}

namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProjectFileCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
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

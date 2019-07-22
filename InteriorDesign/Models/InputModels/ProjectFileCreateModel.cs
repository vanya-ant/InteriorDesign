namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;
    using Microsoft.AspNetCore.Http;
    using System;


    public class ProjectFileCreateModel
    {
        public ProjectFileCreateModel()
        {
            AddedOn = DateTime.UtcNow;
        }
        public string Url { get; set; }

        public IFormFile File { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string PublicId { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }

    }
}

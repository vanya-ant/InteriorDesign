namespace InteriorDesign.Data.Models
{
    using System;

    using InteriorDesign.Data.Common.Models;
    using Microsoft.AspNetCore.Http;

    public class ProjectFile : BaseModel<string>
    {
        public string Utl { get; set; }

        public IFormFile File { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string PublicId { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }
    }
}

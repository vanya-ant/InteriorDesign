namespace InteriorDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using InteriorDesign.Data.Common.Models;
    using Microsoft.AspNetCore.Http;

    public class ProjectFile : BaseModel<string>
    {
        public string Url { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string PublicId { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

namespace InteriorDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using InteriorDesign.Data.Common.Models;
    using Microsoft.AspNetCore.Http;

    public class ProjectFile : BaseModel<string>
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime AddedOn { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

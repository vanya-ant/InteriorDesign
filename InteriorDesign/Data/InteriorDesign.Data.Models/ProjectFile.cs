namespace InteriorDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using InteriorDesign.Data.Common.Models;

    public class ProjectFile : BaseModel<string>
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string ProjectId { get; set; }
    }
}

namespace InteriorDesign.Data.Models
{
    using System;

    using InteriorDesign.Data.Common.Models;

    public class ProjectFile : BaseModel<string>
    {
        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }
    }
}

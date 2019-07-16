namespace InteriorDesign.Data.Models
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Common.Models;

    public class Project : BaseModel<string>
    {
        public Project()
        {
            this.ProjectFiles = new HashSet<ProjectFile>();
            this.DesignBoards = new HashSet<DesignBoard>();
        }

        public ProjectStatus Status { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string DesignerId { get; set; }

        public ApplicationUser Designer { get; set; }

        public ICollection<DesignBoard> DesignBoards { get; set; }

        public ICollection<ProjectFile> ProjectFiles { get; set; }

        public string ProjectReviewId { get; set; }

        public ProjectReview ProjectReview { get; set; }
    }
}

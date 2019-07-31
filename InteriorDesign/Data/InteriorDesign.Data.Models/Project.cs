namespace InteriorDesign.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using InteriorDesign.Data.Common.Models;

    public class Project : BaseModel<string>
    {
        public Project()
        {
            this.ProjectFiles = new List<ProjectFile>();
            this.DesignBoards = new List<DesignBoard>();
            this.ProjectReviews = new List<ProjectReview>();
        }

        public string Name { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.InProgress;

        public bool IsPublic { get; set; } = false;

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        [ForeignKey("Designer")]
        public string DesignerId { get; set; }

        public virtual ApplicationUser Designer { get; set; }

        public IList<DesignBoard> DesignBoards { get; set; }

        public IList<ProjectFile> ProjectFiles { get; set; }

        public IList<ProjectReview> ProjectReviews { get; set; }
    }
}

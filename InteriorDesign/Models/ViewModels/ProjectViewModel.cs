namespace InteriorDesign.Models.ViewModels
{
    using InteriorDesign.Data.Models;
    using System.Collections.Generic;

    public class ProjectViewModel 
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public bool IsPublic { get; set; } = false;

        public virtual ApplicationUser Customer { get; set; }

        public virtual ApplicationUser Designer { get; set; }

        public ICollection<DesignBoard> DesignBoards { get; set; }

        public ICollection<ProjectFile> ProjectFiles { get; set; }

        public ICollection<ProjectReview> ProjectReviews { get; set; }
    }
}

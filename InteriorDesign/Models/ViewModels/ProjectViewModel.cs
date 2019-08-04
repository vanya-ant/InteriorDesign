namespace InteriorDesign.Models.ViewModels
{
    using InteriorDesign.Data.Models;
    using System.Collections.Generic;

    public class ProjectViewModel 
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public bool IsPublic { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public virtual ApplicationUser Designer { get; set; }

        public IList<DesignBoard> DesignBoards { get; set; }

        public IList<ProjectFileViewModel> ProjectFiles { get; set; }

        public IList<ProjectReview> ProjectReviews { get; set; }
    }
}

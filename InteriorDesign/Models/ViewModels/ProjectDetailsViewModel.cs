using InteriorDesign.Data.Models;
using System.Collections.Generic;

namespace InteriorDesign.Models.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //public string Status { get; set; }

        //public bool IsPublic { get; set; } = false;

        //public string CustomerId { get; set; }

        //public string DesignerId { get; set; }

        public ICollection<DesignBoard> DesignBoards { get; set; }

        public IList<ProjectFileViewModel> ProjectFiles { get; set; }

        public IList<ProjectReview> ProjectReviews { get; set; }
    }
}

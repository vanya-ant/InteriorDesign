using InteriorDesign.Data.Models;
using System.Collections.Generic;

namespace InteriorDesign.Models.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<DesignBoard> DesignBoards { get; set; }

        public List<ProjectFileViewModel> ProjectFiles { get; set; }

        public IList<ProjectReview> ProjectReviews { get; set; }
    }
}

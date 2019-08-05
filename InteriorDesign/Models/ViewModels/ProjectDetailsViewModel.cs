namespace InteriorDesign.Models.ViewModels
{
    using InteriorDesign.Data.Models;
    using System.Collections.Generic;

    public class ProjectDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<DesignBoardViewModel> DesignBoards { get; set; }

        public List<ProjectFileViewModel> ProjectFiles { get; set; }

        public IList<ProjectReview> ProjectReviews { get; set; }
    }
}

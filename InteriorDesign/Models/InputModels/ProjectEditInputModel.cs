using InteriorDesign.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class ProjectEditInputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProjectStatus Status { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<DesignBoard> DesignBoards { get; set; }

        public ICollection<ProjectFile> ProjectFiles { get; set; }

        public ICollection<ProjectReview> ProjectReviews { get; set; }
    }
}

using InteriorDesign.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteriorDesign.Models.ViewModels
{
    public class ProjectViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public bool IsPublic { get; set; }

        public string CustomerEmail { get; set; }

        public string DesignerEmail { get; set; }

        public ICollection<DesignBoard> DesignBoards { get; set; }

        public ICollection<ProjectFile> ProjectFiles { get; set; }

        public ICollection<ProjectReview> ProjectReviews { get; set; }
    }
}

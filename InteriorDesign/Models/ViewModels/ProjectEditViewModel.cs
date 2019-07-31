using InteriorDesign.Data.Models;
using System.Collections.Generic;

namespace InteriorDesign.Models.ViewModels
{
    public class ProjectEditViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProjectStatus Status { get; set; }

        public IEnumerable<ProjectStatus> Statuses { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<ProjectFileViewModel> ProjectFiles { get; set; }
    }
}

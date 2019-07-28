using System;
using System.Collections.Generic;
using System.Text;

namespace InteriorDesign.Models.ViewModels
{
    public class CurrentProjectsViewModel
    {
        public ICollection<ProjectViewModel> Projects { get; set; }
    }
}

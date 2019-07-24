using InteriorDesign.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteriorDesign.Models.InputModels
{
    public class ProjectCreateInputModel
    {
        public string Name { get; set; }

        public string CustomerEmail { get; set; }

        public string DesignerEmail { get; set; }
    }
}

using InteriorDesign.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class DesignBoardCreateInputModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = "Project name must be between {0} and {2} characters long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string CustomerId { get; set; }
    }
}

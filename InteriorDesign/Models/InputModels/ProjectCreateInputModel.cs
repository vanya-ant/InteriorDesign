namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ProjectCreateInputModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = "Project name must be between {0} and {2} characters long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        [Required]
        public ApplicationUser Designer { get; set; }

        public bool IsPublic { get; set; }
    }
}

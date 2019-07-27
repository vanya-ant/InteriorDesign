namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ProjectCreateInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        [Required]
        public ApplicationUser Designer { get; set; }
    }
}

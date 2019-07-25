namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;

    public class ProjectCreateInputModel
    {
        public ApplicationUser Customer { get; set; }

        public ApplicationUser Designer { get; set; }
    }
}

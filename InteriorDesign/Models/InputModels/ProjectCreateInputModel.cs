namespace InteriorDesign.Models.InputModels
{
    using InteriorDesign.Data.Models;

    public class ProjectCreateInputModel
    {
        public string Name { get; set; }

        public ApplicationUser Customer { get; set; }

        public ApplicationUser Designer { get; set; }
    }
}

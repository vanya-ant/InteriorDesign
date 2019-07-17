namespace InteriorDesign.Data.Models
{
    using InteriorDesign.Data.Common.Models;

    public class ProjectReview : BaseModel<string>
    {
        public string Review { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }
    }
}

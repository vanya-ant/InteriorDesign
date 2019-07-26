namespace InteriorDesign.Data.Models
{
    using InteriorDesign.Data.Common.Models;

    public class ProjectReview : BaseModel<string>
    {
        public string Review { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

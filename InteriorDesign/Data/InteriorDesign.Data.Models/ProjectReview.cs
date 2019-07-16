namespace InteriorDesign.Data.Models
{
    public class ProjectReview
    {
        public string Review { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}

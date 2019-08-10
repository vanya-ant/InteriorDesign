namespace InteriorDesign.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext context;

        public ReviewService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreateReview(ReviewCreateModel model)
        {
            var review = new ProjectReview
            {
                 Review = model.Review,
                 CustomerId = model.CustomerId,
                 ProjectId = model.ProjectId,
            };

            this.context.ProjectReviews.Add(review);
            await this.context.SaveChangesAsync();

            return "Review was successfully created!";
        }

        public async Task DeleteReview(string id)
        {
            var reviewToDelete = this.context.ProjectReviews.Where(x => x.Id == id).SingleOrDefault();

            this.context.ProjectReviews.Remove(reviewToDelete);

            await this.context.SaveChangesAsync();
        }
    }
}

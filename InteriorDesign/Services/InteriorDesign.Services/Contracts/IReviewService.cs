namespace InteriorDesign.Services.Contracts
{
    using System.Threading.Tasks;

    using InteriorDesign.Models.InputModels;

    public interface IReviewService
    {
        Task<string> CreateReview(ReviewCreateModel model);

        Task DeleteReview(string id);
    }
}

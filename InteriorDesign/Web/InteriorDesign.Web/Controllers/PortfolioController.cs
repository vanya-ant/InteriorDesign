namespace InteriorDesign.Web.Controllers
{
    using System.Linq;

    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        public IActionResult Portfolio()
        {
            var publicFiles = this.portfolioService.GetPublicProjectFiles().OrderBy(x => x.ProjectId).ToList();

            var result = new PortfolioViewModel
            {
                 PublicProjectFiles = publicFiles,
            };

            return this.View(result);
        }
    }
}

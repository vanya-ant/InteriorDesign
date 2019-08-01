namespace InteriorDesign.Web.Controllers
{
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

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

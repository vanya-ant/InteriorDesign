namespace InteriorDesign.Web.Controllers
{
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
            var publicFiles = this.portfolioService.GetPublicProjectFiles();

            return this.View(publicFiles);
        }
    }
}

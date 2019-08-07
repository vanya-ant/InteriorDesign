namespace InteriorDesign.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DesignBoardController : BaseController
    {
        private readonly IDesignBoardService designBoardService;
        private readonly UserManager<ApplicationUser> userManager;

        public DesignBoardController(IDesignBoardService designBoardService, UserManager<ApplicationUser> userManager)
        {
            this.designBoardService = designBoardService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet("/DesignBoard/Create")]
        public async Task<IActionResult> Create(string id)
        {
            var model = new DesignBoardCreateInputModel
            {
                ProjectId = id,
                CustomerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost("/DesignBoard/Create")]
        public async Task<IActionResult> Create(DesignBoardCreateInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.designBoardService.AddDesignBoard(model);
            }

            return this.RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }
    }
}

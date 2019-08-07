namespace InteriorDesign.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReferenceController : BaseController
    {
        private readonly IDesignBoardService designBoardService;

        public ReferenceController(IDesignBoardService designBoardService)
        {
            this.designBoardService = designBoardService;
        }

        [Authorize]
        [HttpGet("/Reference/Create")]
        public async Task<IActionResult> Create(string id)
        {
            var model = new ReferenceInputModel
            {
                DesignBoardId = id,               
                CustomerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost("/Reference/Create")]
        public async Task<IActionResult> Create(ReferenceInputModel model)
        {
            model.DesignBoard = await this.designBoardService.GetCurrentDesignBoard(model.DesignBoardId);

            if (this.ModelState.IsValid)
            {
                await this.designBoardService.AddDesignReference(model);
            }

            return this.RedirectToAction("Details", "Project", new { id = model.DesignBoard.ProjectId });
        }
    }
}
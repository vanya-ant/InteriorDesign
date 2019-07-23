namespace InteriorDesign.Web.Controllers
{
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectCalculatorController : BaseController
    {
        private readonly IProjectCalculatorService service;

        public ProjectCalculatorController(IProjectCalculatorService service)
        {
            this.service = service;
        }

        // GET: ProjectCalculator
        [HttpGet]
        public ActionResult ProjectCalculator(ProjectCalculatorInputModel model)
        {
            return this.View(model);
        }

        // POST: ProjectCalculator
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCalculatorCalculate(ProjectCalculatorInputModel model)
        {
            model.Result = this.service.Calculate(model);

            return this.RedirectToAction("ProjectCalculator", model);
        }
    }
}

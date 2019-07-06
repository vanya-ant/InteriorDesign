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
        public ActionResult ProjectCalculator()
        {
            return this.View();
        }

        // POST: ProjectCalculator
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCalculatorInputModel model)
        {
            try
            {
               var result = this.service.Calculate(model);

               return this.RedirectToAction(nameof(this.ProjectCalculator));
            }
            catch
            {
                return this.View();
            }
        }
    }
}

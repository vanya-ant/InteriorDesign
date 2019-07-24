namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DesignerController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DesignerController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("/Administration/Designer/Assign")]
        public IActionResult Index()
        {
            return this.View("Assign");
        }

        [HttpPost("/Administration/Designer/Assign")]
        public async Task<IActionResult> AssignUserToDesignerRole(string email)
        {
            var userToBeAssigned = await this.userManager.FindByEmailAsync(email);

            await this.userManager.AddToRoleAsync(userToBeAssigned, "Designer");

            return this.Redirect("/Dashboard/IndexViewModel");
        }
    }
}
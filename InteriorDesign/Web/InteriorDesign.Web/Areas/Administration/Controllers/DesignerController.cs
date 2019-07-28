namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Web.Areas.Administration.ViewModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using InteriorDesign.Services;

    public class DesignerController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AdminService adminService;

        public DesignerController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("/Administration/Designer/Assign")]
        public async Task<IActionResult> Assign()
        {
            var users = await this.userManager.GetUsersInRoleAsync("Customer");

            var viewModel = new AllUsersViewModel()
            {
                Customers = AutoMapper.Mapper.Map<IList<ApplicationUser>>(users),
            };

            return this.View("Assign", viewModel);
        }

        [HttpPost("/Administration/Designer/Assign")]
        public async Task<IActionResult> AssignUserToDesignerRole()
        {
            string selectedEmail = this.Request.Form["Customer"].ToString();

            await this.adminService.AddDesigner(selectedEmail);

            return this.Redirect("Administration/Dashboard/Index");
        }
    }
}

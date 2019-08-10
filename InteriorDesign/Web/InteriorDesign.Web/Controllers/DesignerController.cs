namespace InteriorDesign.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DesignerController : BaseController
    {
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;

        public DesignerController(UserManager<ApplicationUser> userManager, IAdminService adminService)
        {
            this.userManager = userManager;
            this.adminService = adminService;
        }

        [HttpGet("/Designer/Assign")]
        public async Task<IActionResult> Assign()
        {
            var users = await this.userManager.GetUsersInRoleAsync("Customer");

            var viewModel = new AllUsersViewModel()
            {
                Customers = AutoMapper.Mapper.Map<IList<ApplicationUser>>(users),
            };

            return this.View("Assign", viewModel);
        }

        [HttpPost("/Designer/Assign")]
        public async Task<IActionResult> AssignDesignerRole()
        {
            string selectedEmail = this.Request.Form["Customer"].ToString();

            var user = await this.userManager.FindByNameAsync(selectedEmail);

            var userRoles = await this.userManager.GetRolesAsync(user);

            if (!userRoles.Contains("Designer"))
            {
                await this.adminService.AddDesigner(selectedEmail);
            }

            return this.Redirect("/Home/IndexLoggedin");
        }
    }
}

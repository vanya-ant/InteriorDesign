namespace InteriorDesign.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet("/User/Profile")]
        public async Task<IActionResult> Profile()
        {
            var userFromDb = await this.userManager.FindByNameAsync(this.User.Identity.Name);

            var user = new UserDetailsViewModel
            {
                Email = userFromDb.UserName,
                Birthday = userFromDb.Birthday,
                FullName = userFromDb.FullName,
            };

            return this.View(user);
        }

        [Authorize]
        [HttpPost("/User/Profile")]
        public async Task<IActionResult> ProfileEdit(EditProfileInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userFromDb = await this.userManager.FindByNameAsync(this.User.Identity.Name);
                userFromDb.Birthday = model.Birthday;
                userFromDb.FullName = model.FullName;
                await this.userManager.UpdateAsync(userFromDb);

                return this.Redirect("/Home/IndexLoggedin");
            }

            return this.Content($"Please fill both your Birthday and Full Name");
        }
    }
}

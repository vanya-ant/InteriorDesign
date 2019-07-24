namespace InteriorDesign.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using AutoMapper;
    using InteriorDesign.Data;
    using InteriorDesign.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public UserController(IMapper mapper, ApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public IActionResult Profile()
        {
            return this.View(new UserDetailsViewModel()
            {
                Email = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
            });
        }
    }
}

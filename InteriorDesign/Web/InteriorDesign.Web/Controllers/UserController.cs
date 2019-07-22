namespace InteriorDesign.Web.Controllers
{
    using AutoMapper;
    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Security.Claims;

    public class UserController : BaseController
    {
        public readonly IMapper mapper;
        public readonly ApplicationDbContext context;

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

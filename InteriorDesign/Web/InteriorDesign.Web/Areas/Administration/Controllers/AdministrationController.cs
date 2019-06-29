namespace InteriorDesign.Web.Areas.Administration.Controllers
{
    using InteriorDesign.Common;
    using InteriorDesign.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

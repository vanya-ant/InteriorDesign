namespace InteriorDesign.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;

    public class AllUsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<UserViewModel> Designers { get; set; }

        public string Roles { get; set; }
    }
}

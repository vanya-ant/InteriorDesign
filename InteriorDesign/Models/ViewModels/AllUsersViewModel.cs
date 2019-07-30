namespace InteriorDesign.Models.ViewModels
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Models;

    public class AllUsersViewModel
    {
        public string ProjectName { get; set; }

        public IEnumerable<ApplicationUser> Customers { get; set; }

        public IEnumerable<ApplicationUser> Designers { get; set; }

        public string Roles { get; set; }
    }
}

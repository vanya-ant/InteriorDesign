namespace InteriorDesign.Web.Areas.Administration.ViewModels.Dashboard
{
    using System.Collections.Generic;

    using InteriorDesign.Models.ViewModels;

    public class IndexViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public int SettingsCount { get; set; }
    }
}

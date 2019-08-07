namespace InteriorDesign.Models.ViewModels
{
    using InteriorDesign.Data.Models;
    using System;

    public class ProjectFileViewModel
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }

        public string Name { get; set; }
    }
}

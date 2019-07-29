namespace InteriorDesign.Models.ViewModels
{
    using System;

    public class ProjectFileVewModel
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsPublic { get; set; }

        public string PublicId { get; set; }
    }
}

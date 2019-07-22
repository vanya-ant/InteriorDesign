using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteriorDesign.Models.ViewModels
{
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

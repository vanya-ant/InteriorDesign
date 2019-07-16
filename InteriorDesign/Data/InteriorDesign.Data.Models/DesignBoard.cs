namespace InteriorDesign.Data.Models
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Common.Models;

    public class DesignBoard : BaseModel<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public string ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<DesignReference> DesignReferences { get; set; }
    }
}

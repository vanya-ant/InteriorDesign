namespace InteriorDesign.Data.Models
{
    using System.Collections.Generic;

    using InteriorDesign.Data.Common.Models;

    public class DesignBoard : BaseModel<string>
    {
        public string Name { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public ICollection<DesignReference> DesignReferences { get; set; }
    }
}

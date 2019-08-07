namespace InteriorDesign.Models.ViewModels
{
    using InteriorDesign.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DesignBoardViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<DesignReference> DesignReferences { get; set; }
    }
}

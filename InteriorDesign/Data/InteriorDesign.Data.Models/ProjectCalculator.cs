namespace InteriorDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectCalculator
    {
        public string Id { get; set; }

        public TypeOfProperty Property { get; set; }

        public TypeOfProject Project { get; set; }

        public int NumberOfBedrooms { get; set; }

        public decimal NumberOfBathrooms { get; set; }

        public decimal HousingArea { get; set; }

        public string UserId { get; set; }

        public ApplicationUser Customer { get; set; }
    }
}

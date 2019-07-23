using InteriorDesign.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class ProjectCalculatorInputModel
    {
        public ProjectCalculatorInputModel()
        {
            this.Result = 0;
        }

        [Required]
        public TypeOfProperty Property { get; set; }

        [Required]
        public TypeOfProject Project { get; set; }

        [Required]
        [Range(0, 10000)]
        public int NumberOfBedrooms { get; set; }

        [Required]
        [Range(1, 1000)]
        public decimal NumberOfBathrooms { get; set; }

        [Required]
        [Range(10, 20000)]
        public decimal HousingArea { get; set; }

        public string Description { get; set; }

        public decimal Result { get; set; }
    }
}

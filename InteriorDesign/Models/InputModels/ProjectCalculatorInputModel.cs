namespace InteriorDesign.Models.InputModels
{
    public class ProjectCalculatorInputModel
    {
        public string Property { get; set; }

        public string Project { get; set; }

        public int NumberOfBedrooms { get; set; }

        public decimal NumberOfBathrooms { get; set; }

        public decimal HousingArea { get; set; }

        public string Description { get; set; }
    }
}

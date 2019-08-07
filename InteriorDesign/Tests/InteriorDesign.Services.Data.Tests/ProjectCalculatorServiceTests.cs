namespace InteriorDesign.Services.Data.Tests
{
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;

    using Xunit;

    public class ProjectCalculatorServiceTests
    {
        private IProjectCalculatorService projectCalculatorService;

        [Fact]
        public async Task Calculate_ShouldReturnCorrectResultsForStudio()
        {
            this.projectCalculatorService = new ProjectCalculatorService();

            var projectCalculatorInput = new ProjectCalculatorInputModel
            {
                HousingArea = 50m,
                NumberOfBathrooms = 1,
                NumberOfBedrooms = 1,
                Project = TypeOfProject.Basic,
                Property = TypeOfProperty.Studio,
            };

            var estimate = this.projectCalculatorService.Calculate(projectCalculatorInput);

            Assert.Equal(244m, estimate);
        }

        [Fact]
        public async Task Calculate_ShouldReturnCorrectResultsForApartment()
        {
            this.projectCalculatorService = new ProjectCalculatorService();

            var projectCalculatorInput = new ProjectCalculatorInputModel
            {
                HousingArea = 100m,
                NumberOfBathrooms = 2,
                NumberOfBedrooms = 2,
                Project = TypeOfProject.Full,
                Property = TypeOfProperty.Apartment,
            };

            var estimate = this.projectCalculatorService.Calculate(projectCalculatorInput);

            Assert.Equal(3336m, estimate);
        }

        [Fact]
        public async Task Calculate_ShouldReturnCorrectResultsForHouse()
        {
            this.projectCalculatorService = new ProjectCalculatorService();

            var projectCalculatorInput = new ProjectCalculatorInputModel
            {
                HousingArea = 200m,
                NumberOfBathrooms = 2,
                NumberOfBedrooms = 2,
                Project = TypeOfProject.Full,
                Property = TypeOfProperty.House,
            };

            var estimate = this.projectCalculatorService.Calculate(projectCalculatorInput);

            Assert.Equal(7339.2m, estimate);
        }

        [Fact]
        public async Task Calculate_ShouldReturnCorrectResultsForRetail()
        {
            this.projectCalculatorService = new ProjectCalculatorService();

            var projectCalculatorInput = new ProjectCalculatorInputModel
            {
                HousingArea = 200m,
                NumberOfBathrooms = 2,
                NumberOfBedrooms = 2,
                Project = TypeOfProject.Consultation,
                Property = TypeOfProperty.RetailProperty,
            };

            var estimate = this.projectCalculatorService.Calculate(projectCalculatorInput);

            Assert.Equal(1890m, estimate);
        }
    }
}

namespace InteriorDesign.Services
{
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;

    public class ProjectCalculatorService : IProjectCalculatorService
    {
        private const decimal BaseProjectRate = 6.88m;
        private const decimal FullProjectRate = 22.34m;
        private const decimal ConsultationRate = 30m;
        private const decimal ConsultationInHouseRate = 50m;

        private const decimal House = 1.8m;
        private const decimal Office = 1.2m;
        private const decimal RetailProperty = 2m;

        public decimal Calculate(ProjectCalculatorInputModel model)
        {
            decimal result = 0m;

            switch (model.Project)
            {
                case "Apartment": result = this.CalculatePropertyArea(model) *
                        (model.NumberOfBathrooms + model.NumberOfBedrooms);
                    break;
                case "Studio":
                    result = this.CalculatePropertyArea(model);
                    break;
                case "House":
                    result = this.CalculatePropertyArea(model) *
                        (model.NumberOfBathrooms + model.NumberOfBedrooms) * House;
                    break;
                case "Office":
                    result = this.CalculatePropertyArea(model) *
                       (model.NumberOfBathrooms + model.NumberOfBedrooms) * Office;
                    break;
                case "RetailProperty":
                    result = this.CalculatePropertyArea(model) *
                       (model.NumberOfBathrooms + model.NumberOfBedrooms) * RetailProperty;
                    break;
                default:
                    break;
            }

            return result;
        }

        internal decimal CalculatePropertyArea(ProjectCalculatorInputModel model)
        {
            decimal result = 0m;

            switch (model.Project)
            {
                case "BasicInteriorDesignProject":
                    result = model.HousingArea * BaseProjectRate;
                    break;

                case "FullInteriorDesignProject":
                    result = model.HousingArea * FullProjectRate;
                    break;

                case "Consultation":
                    result = model.HousingArea * ConsultationRate;
                    break;

                case "ConsultationInHome":
                    result = model.HousingArea * ConsultationInHouseRate;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}

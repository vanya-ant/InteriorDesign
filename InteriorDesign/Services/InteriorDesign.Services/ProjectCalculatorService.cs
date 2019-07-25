namespace InteriorDesign.Services
{
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;

    public class ProjectCalculatorService : IProjectCalculatorService
    {
        private const decimal BaseProjectRate = 6.88m;
        private const decimal FullProjectRate = 22.34m;
        private const decimal ConsultationRate = 3.15m;

        private const decimal House = 1.8m;
        private const decimal Office = 1.2m;
        private const decimal RetailProperty = 2m;

        public decimal Calculate(ProjectCalculatorInputModel model)
        {
            decimal result = 0m;

            switch (model.Property)
            {
                case TypeOfProperty.Apartment: result = this.CalculatePropertyArea(model) *
                        (model.NumberOfBathrooms + model.NumberOfBedrooms);
                    break;
                case TypeOfProperty.Studio:
                    result = this.CalculatePropertyArea(model);
                    break;
                case TypeOfProperty.House:
                    result = this.CalculatePropertyArea(model) *
                        (model.NumberOfBathrooms + model.NumberOfBedrooms) * House;
                    break;
                case TypeOfProperty.Office:
                    result = this.CalculatePropertyArea(model) *
                       (model.NumberOfBathrooms + model.NumberOfBedrooms) * Office;
                    break;
                case TypeOfProperty.RetailProperty:
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
                case TypeOfProject.Basic:
                    result = model.HousingArea * BaseProjectRate;
                    break;

                case TypeOfProject.Full:
                    result = model.HousingArea * FullProjectRate;
                    break;

                case TypeOfProject.Consultation:
                    result = model.HousingArea * ConsultationRate;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}

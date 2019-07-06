namespace InteriorDesign.Services.Contracts
{
    using InteriorDesign.Models.InputModels;

    public interface IProjectCalculatorService
    {
        decimal Calculate(ProjectCalculatorInputModel model);
    }
}

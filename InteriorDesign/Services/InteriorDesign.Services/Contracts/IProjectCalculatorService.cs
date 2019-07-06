namespace InteriorDesign.Services.Contracts
{
    using Models.InteriorDesign.InputModels;

    public interface IProjectCalculatorService
    {
        decimal Calculate(ProjectCalculatorInputModel model);
    }
}

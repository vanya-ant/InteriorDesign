namespace InteriorDesign.Services.Mapping
{
    using AutoMapper;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;

    public class MappingProfile : Profile, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserDetailsViewModel, ApplicationUser>();
        }
    }
}

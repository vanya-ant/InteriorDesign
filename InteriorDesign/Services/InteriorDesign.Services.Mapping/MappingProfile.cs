namespace InteriorDesign.Services.Mapping
{
    using AutoMapper;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;

    public class MappingProfile : Profile, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserDetailsViewModel>();
            configuration.CreateMap<UserDetailsViewModel, ApplicationUser>();
            configuration.CreateMap<Project, ProjectViewModel>();
            configuration.CreateMap<ProjectViewModel, Project>();
        }
    }
}

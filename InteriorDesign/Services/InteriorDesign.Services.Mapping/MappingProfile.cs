namespace InteriorDesign.Services.Mapping
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.ViewModels;

    public class MappingProfile : Profile, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserDetailsViewModel, ApplicationUser>();
            configuration.CreateMap<ApplicationUser, UserDetailsViewModel>();
            configuration.CreateMap<Project, ProjectViewModel>().ReverseMap();
            configuration.CreateMap<ProjectViewModel, Project>().PreserveReferences();
        }
    }
}

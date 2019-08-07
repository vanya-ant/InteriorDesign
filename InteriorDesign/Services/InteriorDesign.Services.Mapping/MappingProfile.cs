namespace InteriorDesign.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;

    public class MappingProfile : Profile, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserDetailsViewModel, ApplicationUser>().ReverseMap();
            configuration.CreateMap<Project, ProjectViewModel>().ReverseMap();
            configuration.CreateMap<ProjectFileViewModel, ProjectFile>().ReverseMap();
            configuration.CreateMap<List<ProjectFile>, List<ProjectFileViewModel>>().ReverseMap();

            configuration.CreateMap<ProjectCreateInputModel, ProjectEditInputModel>().ReverseMap();
            configuration.CreateMap<DesignBoard, DesignBoardViewModel>().ReverseMap();
        }
    }
}

namespace InteriorDesign.Services.Data.Tests.Common
{
    using System.Reflection;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;
    using InteriorDesign.Services.Mapping;

    public class MapperInitializer
    {
       public static void InitializeMapper()
       {
           AutoMapperConfig.RegisterMappings(
               typeof(ProjectCreateInputModel).GetTypeInfo().Assembly,
               typeof(ProjectEditInputModel).GetTypeInfo().Assembly);

           AutoMapperConfig.RegisterMappings(
               typeof(Project).GetTypeInfo().Assembly,
               typeof(ProjectViewModel).GetTypeInfo().Assembly);
        }
    }
}

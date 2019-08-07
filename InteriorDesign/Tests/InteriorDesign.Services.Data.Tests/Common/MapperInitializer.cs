namespace InteriorDesign.Services.Data.Tests.Common
{
    using System.Reflection;

    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Mapping;

    public class MapperInitializer
    {
       public static void InitializeMapper()
       {
           AutoMapperConfig.RegisterMappings(
               typeof(ProjectCreateInputModel).GetTypeInfo().Assembly,
               typeof(ProjectEditInputModel).GetTypeInfo().Assembly);
       }
    }
}

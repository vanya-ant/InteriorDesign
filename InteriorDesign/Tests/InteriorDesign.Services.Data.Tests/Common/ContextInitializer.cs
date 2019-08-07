namespace InteriorDesign.Services.Data.Tests.Common
{
    using System;

    using InteriorDesign.Data;
    using Microsoft.EntityFrameworkCore;

    public class ContextInitializer
    {
        public static ApplicationDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new ApplicationDbContext(options);
        }
    }
}

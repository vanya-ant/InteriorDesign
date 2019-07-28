namespace InteriorDesign.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Services.Contracts;

    public class DesignerService : IDesignerService
    {
        private readonly ApplicationDbContext context;

        public DesignerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddProjectFile()
        {
            throw new NotImplementedException();
        }

        public void DeleteProjectFile()
        {
            throw new NotImplementedException();
        }

        public void EditProject()
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> GetActiveDesignerProjects(string designerId)
        {
            var allActiveProjects = this.context.Projects.Where(p => p.DesignerId == designerId && p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }
    }
}

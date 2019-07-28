namespace InteriorDesign.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Services.Contracts;

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<Project> GetActiveCustomerProjects(string customerId)
        {
            var allActiveProjects = this.context.Projects.Where(p => p.CustomerId == customerId && p.Status == ProjectStatus.InProgress).ToList();

            return allActiveProjects;
        }

        public void ApproveProjectFile()
        {
            throw new NotImplementedException();
        }

        public void PreviewProject()
        {
            throw new NotImplementedException();
        }
    }
}

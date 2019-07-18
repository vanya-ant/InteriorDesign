namespace InteriorDesign.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IDesignerService
    {
        void EditProject();

        void AddProjectFile();

        void DeleteProjectFile();
    }
}

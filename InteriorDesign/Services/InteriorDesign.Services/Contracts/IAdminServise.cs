namespace InteriorDesign.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAdminServise
    {
        void CreateProject();

        void EditProject();

        void AddProjectFile();

        void DeleteProjectFIle();

        void AddDesigner();

        void DeleteDeigner();

        void DeleteREview();
    }
}

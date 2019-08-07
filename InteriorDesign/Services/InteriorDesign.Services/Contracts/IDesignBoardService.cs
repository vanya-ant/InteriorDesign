namespace InteriorDesign.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Models.ViewModels;

    public interface IDesignBoardService
    {
        Task AddDesignBoard(DesignBoardCreateInputModel model);

        Task AddDesignReference(ReferenceInputModel model);

        Task<IList<DesignReference>> GetDesignBoardReferences(string id);

        Task<DesignBoard> GetCurrentDesignBoard(string id);
    }
}

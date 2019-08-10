namespace InteriorDesign.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InteriorDesign.Data;
    using InteriorDesign.Data.Models;
    using InteriorDesign.Models.InputModels;
    using InteriorDesign.Services.Contracts;

    public class DesignBoardService : IDesignBoardService
    {
        private readonly ApplicationDbContext context;

        public DesignBoardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddDesignBoard(DesignBoardCreateInputModel model)
        {
            var designBoard = new DesignBoard
            {
                Name = model.Name,
                CustomerId = model.CustomerId,
                ProjectId = model.ProjectId,
            };

            this.context.DesignBoards.Add(designBoard);

            await this.context.SaveChangesAsync();

            return "DesignBoard created successfully!";
        }

        public async Task<string> AddDesignReference(ReferenceInputModel model)
        {
            var reference = new DesignReference
            {
                CustomerId = model.CustomerId,
                DesignBoardId = model.DesignBoardId,
                DesignBoard = await this.GetCurrentDesignBoard(model.DesignBoardId),
                ImageUrl = model.ImageUrl,
            };

            this.context.DesignReferences.Add(reference);

            await this.context.SaveChangesAsync();

            return "DesignReference created successfully!";
        }

        public async Task<IList<DesignReference>> GetDesignBoardReferences(string id)
        {
           return this.context.DesignReferences.Where(x => x.DesignBoardId == id).ToList();
        }

        public async Task<DesignBoard> GetCurrentDesignBoard(string id)
        {
            var designBoard = this.context.DesignBoards.Where(x => x.Id == id).SingleOrDefault();

            return designBoard;
        }
    }
}

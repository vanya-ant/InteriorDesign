namespace InteriorDesign.Data.Models
{
    using InteriorDesign.Data.Common.Models;

    public class DesignReference : BaseModel<string>
    {
        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string DesignBoardId { get; set; }

        public virtual DesignBoard DesignBoard { get; set; }

        public string ImageUrl { get; set; }
    }
}

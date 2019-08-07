using InteriorDesign.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class ReferenceInputModel
    {
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public string CustomerId { get; set; }

        public string DesignBoardId { get; set; }

        public virtual DesignBoard DesignBoard { get; set; }
    }
}

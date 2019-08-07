using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class ReviewCreateModel
    {
        [Required]
        [StringLength(1000, ErrorMessage ="Project review should be between {0} and {2} characters long!", MinimumLength =3)]
        public string Review { get; set; }

        public string CustomerId { get; set; }

        public string ProjectId { get; set; }
    }
}

namespace InteriorDesign.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Full name must be between {0} and {2} characters long!", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Full name must be between {0} and {2} characters long!", MinimumLength = 3)]
        public string Message { get; set; }
    }
}

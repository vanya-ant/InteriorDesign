using System;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Models.InputModels
{
    public class EditProfileInputModel
    {
        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Full Name mmust be between {0} and {2} characters long", MinimumLength = 3)]
        public string FullName { get; set; }
    }
}

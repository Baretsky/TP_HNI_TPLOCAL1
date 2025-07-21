using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class PersonalInfo
    {
        // Personal Information
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Forename { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip code must be 5 numeric characters")]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        public string Town { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        // Training Information
        [Required]
        public DateTime StartDateTraining { get; set; }

        [Required]
        public string TypeOfTraining { get; set; } = string.Empty;

        // Training Reviews
        [Required]
        public string CobolFormation { get; set; } = string.Empty;

        [Required]
        public string CSharpFormation { get; set; } = string.Empty;
    }
}
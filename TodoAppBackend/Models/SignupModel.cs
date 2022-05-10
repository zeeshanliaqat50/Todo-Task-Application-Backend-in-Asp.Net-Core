using System.ComponentModel.DataAnnotations;
namespace TodoAppBackend.Models
{
    public class SignupModel
    {
        [Required]
        public string firstName { get; set; } = "";
        [Required]
        public string lastName { get; set; } = "";
        [Required]
        [EmailAddress]
        public string email { get; set; } = "";
       
        [Required]
        [Compare("confirmPassword")]
        public string password { get; set; } = "";

        [Required]
        public string confirmPassword { get; set; } = "";

    }
}

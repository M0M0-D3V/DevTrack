using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models.Users
{
    public class AuthenticateModel
    {
        [Required(ErrorMessage = " is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = " is required.")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
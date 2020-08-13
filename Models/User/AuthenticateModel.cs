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
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
        , ErrorMessage = "Must have at least 1 number, 1 capital letter, and a special character")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
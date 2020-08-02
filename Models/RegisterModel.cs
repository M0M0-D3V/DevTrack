using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models.Users
{
    public class RegisterModel
    {
        [Required(ErrorMessage = " is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = " is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = " is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = " is required.")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
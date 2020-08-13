using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
        , ErrorMessage = "Must have at least 1 number, 1 capital letter, and a special character")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        [NotMapped]
        [Required(ErrorMessage = " is required.")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Needs to match password")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
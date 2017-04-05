using System;
using System.ComponentModel.DataAnnotations;

namespace AutomapperTest.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="User Name")]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Compare("Agreed", ErrorMessage = "user shoud agreed to terms")]
        [Display(Name = "I agree the Terms")]
        public bool AgreedToTerms { get; set; }

        public bool Agreed => true;
    }
}
using System.ComponentModel.DataAnnotations;

namespace LocalizationSample.Models
{
    public class RequestModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Text field is required.")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long. but less than {1}", MinimumLength = 6)]
        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.UI.Models.SecurityModels
{
    /// <summary>
    /// Model class for Registering an user
    /// </summary>
    public class RegisterUserModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// StudentId 
        /// </summary>
        [Required]
        [Display(Name ="Teacher Id")]
        public int TeacherId { get; set; }
        
        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Email Address must be a valid email address
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Confirm Password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

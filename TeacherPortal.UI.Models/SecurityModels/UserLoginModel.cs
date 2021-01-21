using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.UI.Models.SecurityModels
{
    /// <summary>
    /// Model class for login
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        public string UserName { get; set; }

        
        /// <summary>
        /// Password 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Remember Me
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

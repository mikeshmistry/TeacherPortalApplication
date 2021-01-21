using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Security.Application
{
    /// <summary>
    /// Class to represent an user
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        #region Properties
        
        /// <summary>
        /// The teacher Id of the teacher
        /// </summary>
        [Required]
        public int TeacherId { get; set; } 

        #endregion 

    }
}

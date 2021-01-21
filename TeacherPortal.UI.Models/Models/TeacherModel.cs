using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.UI.Models.Models
{
    /// <summary>
    /// Model class to represent a teacher
    /// </summary>
    public class TeacherModel
    {
        #region Properties 

        /// <summary>
        /// TeacherId
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// FirstName of the teacher this is a required field
        /// </summary>
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName of the teacher this is a required field
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Full name of the teacher
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// List of courses that the teacher teachers
        /// </summary>
        public List<CourseModel> Courses { get; set; }
        
        #endregion
    }
}

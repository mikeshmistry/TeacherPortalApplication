using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.UI.Models.Models
{
    /// <summary>
    /// Model class to represent a course
    /// </summary>
    public class CourseModel
    {

        #region Properties

        /// <summary>
        /// CourseId 
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Name of the course this is required
        /// </summary>
        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the course this is required
        /// </summary>
        [Required]
        [Display(Name = "Course Description")]
        public string Description { get; set; }
        #endregion

    }


}

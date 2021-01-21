using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.UI.Models.Models
{
    /// <summary>
    /// Model class to represent a student 
    /// </summary>
    public class StudentModel
    { 
        #region Properties 

        /// <summary>
        /// StudentId 
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// FirstName of the student this is a required field
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName of the student this is a required field
        /// </summary>
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

       /// <summary>
       /// Field for the combination of firstName and LastName 
       /// </summary>
        public string FullName{ get; set; }


        /// <summary>
        /// List of Course for the student 
        /// </summary>
        public List<CourseModel> Courses { get; set; }

        #endregion

        #region Default Constructor

        public StudentModel()
        {

        }

        #endregion 

    }
}

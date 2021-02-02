using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherPortal.UI.Models.Models
{
    /// <summary>
    /// Model class used for assigning grades to students
    /// </summary>
    public class AssignGradeModel
    {

        #region Properties

        /// <summary>
        /// Selected CourseId
        /// </summary>
        [Range(1, Int32.MaxValue, ErrorMessage = "You Must Select A Course")]
        public int CourseId { get; set; }

        /// <summary>
        /// List of courses that a teacher is assigned to 
        /// </summary>
        [Display( Name = "Select a Course")]
        public List<CourseModel> Courses {get; set;}

        /// <summary>
        /// List of students that are associated with the course 
        /// </summary>
        public List<StudentModel> Students { get; set; }


        #endregion 

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherPortal.UI.Models.Models
{
    /// <summary>
    /// Model to represent a grade
    /// </summary>
    
   
    public class GradeModel
    {
        #region Properties

        /// <summary>
        /// GradeId
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
       
        public int StudentId { get; set; }

        /// <summary>
        /// CourseId
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        /// 
        [Required]
        [MaxLength(2)]
        [Display(Name = "Letter Grade")]
        public string LetterGrade { get; set; }


        /// <summary>
        /// Student assigned to the grade only used for display 
        /// </summary>
        public StudentModel Student { get; set; }


        /// <summary>
        /// Course associated with the grade only for display
        /// </summary>
        public CourseModel Course { get; set; }

       
        #endregion
    }
}


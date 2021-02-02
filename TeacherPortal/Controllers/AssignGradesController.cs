using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherPortal.BL.BusinessClasses;
using TeacherPortal.Security.Application;
using TeacherPortal.UI.Models.Models;

namespace TeacherPortal.UI.Controllers
{
    public class AssignGradesController : Controller
    {

        #region Fields

        /// <summary>
        /// Field to the logger 
        /// </summary>
        private readonly ILogger<AssignGradesController> _logger;

        /// <summary>
        /// Field to the teacher business object class
        /// </summary>
        private readonly Teacher teacherBusinessObject;

        /// <summary>
        /// Field to the course business object class
        /// </summary>
        private readonly Course courseBusinessObject;

        /// <summary>
        /// Field to the grade business object class
        /// </summary>
        private readonly Grade gradeBusinessObject;

        /// <summary>
        /// Field to the Student business object class
        /// </summary>
        private readonly Student studentBusinessObject;

        //Field to the application manager
        private ApplicationUserManager _applicationUserManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that takes in a logger 
        /// </summary>
        /// <param name="logger">the logger to be used</param>
        public AssignGradesController(ILogger<AssignGradesController> logger, ApplicationUserManager userManager)
        {
            _logger = logger;

            teacherBusinessObject = new Teacher();
            courseBusinessObject = new Course();
            studentBusinessObject = new Student();
            gradeBusinessObject = new Grade();
            
            _applicationUserManager = userManager;
        }

        #endregion

        #region Action Methods


        /// <summary>
        /// Get action the default page of assigning a grade
        /// </summary>
        /// <returns>A view to the assign grades view</returns>
        public async Task<IActionResult> Index()
        {
            var gradeModel = new AssignGradeModel();
             await GetEnrolledCoursesAsync(gradeModel);
            return View("Views/AssignGrades/AssignGrades.cshtml", gradeModel);

        }


        /// <summary>
        /// Post action method to get all students enrolled in a course
        /// </summary>
        /// <param name="course">The course model</param>
        /// <returns>A view back to the assign grades view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetStudents([Bind("CourseId")] AssignGradeModel course)
        {
          

            if (ModelState.IsValid)
            {
                var grades = new AssignGradeModel();
                
                grades.CourseId = course.CourseId;
                await GetEnrolledCoursesAsync(grades);
                grades.Students = await courseBusinessObject.GetEnrolledStudentsAsync(grades.CourseId);
                
               return View("Views/AssignGrades/AssignGrades.cshtml", grades);

            }

            return View("Views/AssignGrades/AssignGrades.cshtml",course);

            
        }

        /// <summary>
        /// Get action to add or edit a student grade
        /// </summary>
        /// <param name="courseId">The course id</param>
        /// <param name="studentId">The student id</param>
        /// <returns>A view to Add Edit Grade </returns>
        public async Task<IActionResult> AddEditGrade(int courseId, int studentId)
        {

            if (ModelState.IsValid)
            {
                var doesGradeExist = await gradeBusinessObject.DoesGradeExistAsync(courseId, studentId);


                //do an update on the grade
                if (doesGradeExist)
                {
                    var foundGrade = await gradeBusinessObject.FindAssignedStudentGradeAsync(courseId, studentId);
                    foundGrade.StudentId = studentId;
                    foundGrade.CourseId = courseId;

                    return View("Views/AssignGrades/AddEditGrade.cshtml", foundGrade);
                }

                else
                {
                    //add it
                    var newGrade = new GradeModel();
                    newGrade.Course = await courseBusinessObject.FindCourseAsync(courseId);
                    newGrade.CourseId = courseId;
                    newGrade.Student = await studentBusinessObject.FindStudentAsync(studentId);
                    newGrade.StudentId = studentId;
                    return View("Views/AssignGrades/AddEditGrade.cshtml", newGrade);
                }
            }

            //go back to the index of this action 
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Post action method to create a grade record for a student. If it exists it will update it
        /// </summary>
        /// <param name="grade">The grade model to add</param>
        /// <returns>A view back to the assign grades view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssginGrade(GradeModel grade)
        {

            if (ModelState.IsValid)
            {
               await gradeBusinessObject.AssignGradeToStudentAsync(grade.StudentId, grade.CourseId, grade.LetterGrade);

            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Non Action Methods

        /// <summary>
        /// Gets all enrolled courses for a teacher
        /// </summary>
        [NonAction]
        private async Task GetEnrolledCoursesAsync(AssignGradeModel teacher)
        {
            //Get the teacher Id
            var foundTeacherId = await GetTeacherId();
            teacher.Courses = await teacherBusinessObject.GetEnrolledCoursesAsync(foundTeacherId);
            teacher.Courses.Insert(0, new CourseModel { CourseId=0, Name="--Select A Course--" });

        }


        /// <summary>
        /// Non action method to retrieve the logged in teachers teacherId 
        /// </summary>
        /// <returns>The teacherId</returns>
        [NonAction]
        private async Task<int> GetTeacherId()
        {
            var teacherId = 0;
            //get the user
            var user = await _applicationUserManager.GetUserAsync(User);

            //found the user
            if (user != null)
                teacherId = _applicationUserManager.GetTeacherId(user);

            return teacherId;
        }

#endregion
    }
}

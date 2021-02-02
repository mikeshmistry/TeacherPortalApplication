using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TeacherPortal.BL.BusinessClasses;
using TeacherPortal.Security.Application;
using TeacherPortal.UI.Models.Models;

namespace TeacherPortal.UI.Controllers
{
    /// <summary>
    /// Controller class for viewing enrolled courses
    /// </summary>
    [Authorize]
    public class ViewAssignedCoursesController : Controller
    {
        #region Fields

        /// <summary>
        /// Field to the logger
        /// </summary>
        private readonly ILogger<ViewAssignedCoursesController> _logger;

        /// <summary>
        /// Field to the teacher business object
        /// </summary>
        private readonly Teacher teacherBusinessObject;

        private ApplicationUserManager _applicationUserManager;

        #endregion

        #region Constructors



        /// <summary>
        /// Constructor that takes in a logger 
        /// </summary>
        /// <param name="logger">The logger to use</param>
        public ViewAssignedCoursesController(ILogger<ViewAssignedCoursesController> logger,ApplicationUserManager userManager)
        {
            _logger = logger;
            teacherBusinessObject = new Teacher();
            _applicationUserManager = userManager;
        }

        #endregion

        #region Action Methods

        /// <summary>
        /// Get action to the default 
        /// </summary>
        /// <returns>A view back to the view enrolled courses view</returns>
        public async Task<IActionResult> Index()
        {
            var teacher = new TeacherModel();
            await GetEnrolledCoursesAsync(teacher);

            return View("Views/AssignedCourses/ViewAssignedCourses.cshtml", teacher);
        }

        #endregion

        #region Non Action Methods

        /// <summary>
        /// Gets all enrolled courses for a teacher
        /// </summary>
        /// <param name="teacher">The teacher to get the course for</param>
        [NonAction]
        private async Task GetEnrolledCoursesAsync(TeacherModel teacher)
        {
            //Get the teacher Id
            var foundTeacherId =  await GetTeacherId();
            teacher.Courses = await teacherBusinessObject.GetEnrolledCoursesAsync(foundTeacherId);
        }


        /// <summary>
        /// Non action method to retrieve the logged in teachers teacherId 
        /// </summary>
        /// <returns>The teacherId</returns>
        [NonAction]
        private async Task<int> GetTeacherId()
        {
            var studentId = 0; 
            //get the user
            var user = await _applicationUserManager.GetUserAsync(User);

            //found the user
            if (user != null)
                studentId = _applicationUserManager.GetTeacherId(user);

                return studentId;
        }

        #endregion 
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.UI.Controllers
{
    /// <summary>
    /// Controller For the Logged in teacher
    /// </summary>
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class MainController : Controller
    {

        #region Action Methods

        /// <summary>
        /// Get action method for main
        /// </summary>
        /// <returns>The main view for the logged in user</returns>
        public IActionResult Index()
        {
            return View("Views/Main.cshtml");
           
        }

        #endregion
    }
}

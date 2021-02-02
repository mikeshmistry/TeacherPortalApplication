using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace TeacherPortal.BL
{
    /// <summary>
    /// Business base class for communicating with the database layer 
    /// </summary>
    public abstract class BusinessBase
    {
        #region Properties
        
        /// <summary>
        /// Property to the context
        /// </summary>
        protected StudentGradingContext StudentGradingContext { get; set; }

        #endregion 

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BusinessBase()
        {
           
            StudentGradingContext = new StudentGradingContext();
              
        }

        #endregion

    }
}

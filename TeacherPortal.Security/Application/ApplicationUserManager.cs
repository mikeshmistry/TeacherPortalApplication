using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TeacherPortal.Security.Application
{
    /// <summary>
    /// Custom User Manager Class
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {

        #region Fields

        //Field to the dbContext
        private ApplicationDbContext dbContext;
        #endregion 

        #region Constructor


        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger, ApplicationDbContext applicationDbContext)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

            dbContext = applicationDbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method To get the studentId for a given user
        /// </summary>
        /// <param name="user">The user object</param>
        /// <returns>The teacherId of the teacher</returns>
        public int GetTeacherId(ApplicationUser user)
        {
            var teacherId = 0;
     
                //Get the teacher  
                teacherId = (from appUser in dbContext.Users
                             where appUser.Id == user.Id
                             select appUser.TeacherId).FirstOrDefault();
            
            return teacherId;
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;


namespace TeacherPortal.Security
{
    /// <summary>
    /// Class to set options for various settings 
    /// </summary>
    public abstract class ConfigurationOptions
    {

        /// <summary>
        /// Method to configure the password options
        /// </summary>
        /// <param name="options">The identity options for the password</param>
        public static void PasswordOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        }


        /// <summary>
        /// Method to configure the LockOut options 
        /// </summary>
        /// <param name="options">The identity options for the lockout options</param>
        public static void LockOutOptions(IdentityOptions options)
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

        }


        /// <summary>
        /// Method to configure the User options
        /// </summary>
        /// <param name="options">The identity options for the user options</param>
        public static void UserOptions(IdentityOptions options)
        {
          
            options.User.AllowedUserNameCharacters ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        }


        /// <summary>
        /// Method to configure the cookie options 
        /// </summary>
        /// <param name="options">The cookie options</param>
        public static void CookieOptions(CookieAuthenticationOptions options)
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        }


    }
}

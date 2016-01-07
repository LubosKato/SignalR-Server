using System;
using System.Configuration;
using System.Linq;

namespace Messenger.Server.Custom
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AuthorizeAttribute : Microsoft.AspNet.SignalR.AuthorizeAttribute
    {
        protected override bool UserAuthorized(System.Security.Principal.IPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var roles = ConfigurationManager.AppSettings["AuthorisedRoles"];
            
            // No roles required? Let em through
            if (!roles.Any()) return true;

            // If a role is required, ensure the user has it
            if (roles.Split(',').Any(user.IsInRole))
            {
                return true;
            }

            return false;
        }
    }
}
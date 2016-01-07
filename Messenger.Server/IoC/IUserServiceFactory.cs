using Messenger.Server.Security;

namespace Messenger.Server.IoC
{
    /// <summary>
    /// User Service Factory
    /// </summary>
    public interface IUserServiceFactory
    {
        /// <summary>
        /// Create A User Service
        /// </summary>
        /// <returns></returns>
        IUserService Create();
        /// <summary>
        /// Release a user service
        /// </summary>
        /// <param name="userService"></param>
        void Release(IUserService userService);
    }
}
using Omnitudo.Core.Entities;

namespace Omnitudo.Core.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// <summary>
        /// Validate password for a user.
        /// </summary>
        /// <param name="email">E-mail</param>
        /// <param name="password">Password</param>
        /// <returns>Validated user</returns>
        User? ValidatePassword(string email, string password);
    }
}

namespace Omnitudo.Shared.Security
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Get a hash for a password.
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <returns>The hash</returns>
        public static string GetHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Validates a password.
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="password">The password to check against</param>
        /// <returns>Boolean</returns>
        public static bool IsValid(string input, string password)
        {
            return BCrypt.Net.BCrypt.Verify(input, password);
        }
    }
}

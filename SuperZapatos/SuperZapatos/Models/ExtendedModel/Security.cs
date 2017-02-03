namespace SuperZapatos.Models.ExtendedModel
{
    /// <summary>
    /// Class to validate credentials
    /// </summary>
    public class Security
    {
        
        private const string baseUserName = "my_user";
        private const string basePassword = "my_password";

        /// <summary>
        /// Validate the credentials.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Validation.</returns>
        public static bool Login(string userName, string password)
        {
            return userName.Equals(baseUserName) && password.Equals(basePassword);
        }
    }
}
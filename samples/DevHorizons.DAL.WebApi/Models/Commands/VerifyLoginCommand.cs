namespace DevHorizons.DAL.WebApi.Models.Commands
{
    using Shared;
    using Sql.Attributes;
    
    public enum LoginStatus
    {
        /// <summary>
        ///    Authentication succeeded.
        /// </summary>
        Succeeded = 0,

        /// <summary>
        ///    The user does not exist.
        /// </summary>
        UserNotExist = 1,

        /// <summary>
        ///    The user exists but the specified password does not match.
        /// </summary>
        WrongPassword = 2,

        /// <summary>
        ///    Authentication succeeded, but the user is already locked.
        /// </summary>
        UserLocked = 3,

        /// <summary>
        ///    Authentication succeeded, but the user is disabled by the system or admins.
        /// </summary>
        UserDisabled = 4,

        /// <summary>
        ///    Authentication succeeded, but the user is disabled by the system or admins.
        /// </summary>
        UserLockedAndDisabled = 7,

        /// <summary>
        ///   For the authentication verification, either the username or email needs to be specified along side with the password.
        ///   If this condition is not satisfied, the operation will be terminated with this status.
        /// </summary>
        MissingInputs = -1
    }

    [Attributes.CommandBody("[dbo].[VerifyLogin]")]
    public class VerifyLoginCommand : CommandBody
    {
        [SqlParameter(Name = "UserName", Encrypted = true)]
        public string? LoginName { get; set; }

        [SqlParameter(Encrypted = false)]
        public string? Email { get; set; }

        [SqlParameter(Hashed = true)]
        public string Password { get; set; }

        [SqlParameter(NotMapped = true)]
        public LoginStatus LoginStatus
        {
            get
            {
                return (LoginStatus)this.ReturnValue;
            }
        }
    }
}

namespace DevHorizons.DAL.Wpf.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Commands;
    using DAL.Interfaces;
    using Models;

    public class UserService
    {
        #region Private Fields
        private readonly ICommand sqlCmd;
        #endregion Private Fields

        #region Constructors
        public UserService(ICommand sqlCmd)
        {
            this.sqlCmd = sqlCmd;
            this.sqlCmd.ErrorRaised += SqlCmd_ErrorRaised;
            this.sqlCmd.WarningRaised += SqlCmd_WarningRaised;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<List<User>?> GetAllUsers()
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteQuery<User>(new GetAllUsersCommand()));
            if (result == null && this.sqlCmd.Errors.Count > 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        #endregion Public Methods

        #region Private Methods
        private void SqlCmd_ErrorRaised(ILogDetails error)
        {

        }

        private void SqlCmd_WarningRaised(ILogDetails error)
        {
        }
        #endregion Private Methods
    }
}
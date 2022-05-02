namespace DevHorizons.DAL.WebApi.Services
{
    using DAL.Interfaces;
    using DevHorizons.DAL.DependencyInjection;
    using Models;
    using Models.Commands;

    public class UserService
    {
        #region Private Fields
        private readonly ILogger<UserService> logger;
        private readonly ICommand sqlCmd;
        private readonly IApplicationConfiguration appConfig;
        #endregion Private Fields

        #region Constructors
        public UserService(ILogger<UserService> logger, ICommand sqlCmd, IApplicationConfiguration appConfig)
        {
            this.logger = logger;
            this.sqlCmd = sqlCmd;
            this.appConfig = appConfig;
            this.sqlCmd.ErrorRaised += SqlCmd_ErrorRaised;
            this.sqlCmd.WarningRaised += SqlCmd_WarningRaised;
        }
        #endregion Constructors

        #region Public Methods

        public async Task<AddUserCommand?> AddUser(AddUserCommand userCommand)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteCommand(userCommand));
            return result ? userCommand : null;
        }

        public async Task<List<AddUserCommand>?> AddUserList(List<AddUserCommand> userCommandList)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteTranCommands(userCommandList.Cast<ICommandBody>().ToList()));
            return result ? userCommandList : null;
        }

        public async Task<bool> AddUserBulkUsers(AddBuklUsersCommand buklUsersCommand)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteCommand(buklUsersCommand));
            return result;
        }

        public async Task<VerifyLoginCommand?> VerifyLogin(VerifyLoginCommand verifyLoginCommand)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteCommand(verifyLoginCommand));
            return result ? verifyLoginCommand : null;
        }

        public async Task<List<User>?> GetAllUsers(GetAllUsersCommand getAllUsersCommand)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteQuery<User>(getAllUsersCommand));
            if (result == null && this.sqlCmd.Errors.Count > 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<List<User>?> GetUser(GetUserCommand getUserCommand)
        {
            var result = await Task.FromResult(this.sqlCmd.ExecuteQuery<User>(getUserCommand));
            if (result.Count == 0 && this.sqlCmd.Errors.Count > 0)
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
            var advancedErrrorDetails = this.appConfig.DataAccessSettings.AdvancedErrorDetails ? (AdvacedErrorDetails)error : new AdvacedErrorDetails(error);
            this.logger.LogError("An Error has been raised with the following details.", advancedErrrorDetails);
        }

        private void SqlCmd_WarningRaised(ILogDetails error)
        {
            var advancedErrrorDetails = this.appConfig.DataAccessSettings.AdvancedErrorDetails? (AdvacedErrorDetails)error: new AdvacedErrorDetails(error);
            this.logger.LogError("An Error has been raised with the following details.", advancedErrrorDetails);
        }
        #endregion Private Methods
    }
}
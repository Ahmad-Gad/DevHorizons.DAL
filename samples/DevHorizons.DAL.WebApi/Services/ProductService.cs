namespace DevHorizons.DAL.WebApi.Services
{
    using DAL.Interfaces;
    using DevHorizons.DAL.DependencyInjection;
    using Interfaces;
    using Models;
    using Models.Commands;

    public class ProductService
    {
        #region Private Fields
        private readonly ILogger<ProductService> logger;
        private readonly ICommand sqlCmd;
        private readonly IApplicationConfiguration appConfig;
        #endregion Private Fields

        #region Constructors
        public ProductService(ILogger<ProductService> logger, ICommand sqlCmd, IApplicationConfiguration appConfig)
        {
            this.logger = logger;
            this.sqlCmd = sqlCmd;
            this.appConfig = appConfig;
            this.sqlCmd.ErrorRaised += SqlCmd_ErrorRaised;
            this.sqlCmd.WarningRaised += SqlCmd_WarningRaised;
        }
        #endregion Constructors

        #region Public Methods
        public async Task<Product?> AddProduct(Product product)
        {
            //var result = await Task.FromResult(this.sqlCmd.ExecuteCommand(product, CommandAction.Insert));
            //return result ? product : null;

            throw new NotImplementedException();
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
            var advancedErrrorDetails = this.appConfig.DataAccessSettings.AdvancedErrorDetails ? (AdvacedErrorDetails)error : new AdvacedErrorDetails(error);
            this.logger.LogError("An Error has been raised with the following details.", advancedErrrorDetails);
        }
        #endregion Private Methods
    }
}

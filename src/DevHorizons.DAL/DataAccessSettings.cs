// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccessSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the needed settings for the data access layers.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using Cache;
    using Cryptography;
    using Interfaces;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///    Defines all the needed settings for the data access layers.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public class DataAccessSettings : IDataAccessSettings
    {
        #region Properties

        /// <inheritdoc/>
        public IConnectionSettings ConnectionSettings { get; set; } = new ConnectionSettings();

        /// <inheritdoc/>
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        /// <inheritdoc/>
        public bool AdvancedErrorDetails { get; set; }

        /// <inheritdoc/>
        public CacheSettings CacheSettings { get; set; } = new CacheSettings();

        /// <inheritdoc/>
        public CryptographySettings CryptographySettings { get; set; } = new CryptographySettings();
        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails()
        {
            return this.AdvancedErrorDetails ? new AdvacedErrorDetails() : new ErrorDetails();
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber)
        {
            var error = this.CreateErrorDetails();
            error.LogLevel = LogLevel.Critical;
            error.Exception = ex;
            error.StackTrace = ex.StackTrace;
            error.Message = ex.Message;
            error.Number = errorNumber;
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber, string description)
        {
            var error = this.CreateErrorDetails(ex, errorNumber);
            error.Description = description;
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber, string description, string source)
        {
            var error = this.CreateErrorDetails(ex, errorNumber, description);
            error.Source = source;
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(LogLevel logLevel, string stackTrace, string source, int errorNumber, string message)
        {
            var error = this.CreateErrorDetails();
            error.LogLevel = logLevel;
            error.StackTrace = stackTrace;
            error.Source = source;
            error.Number = errorNumber;
            error.Message = message;
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(LogLevel logLevel, string stackTrace, string source, int errorNumber, string message, string description)
        {
            var error = this.CreateErrorDetails(logLevel, stackTrace, source, errorNumber, message);
            error.Description = description;
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(string stackTrace, string source, int errorNumber, string message)
        {
            var error = this.CreateErrorDetails(LogLevel.Error, stackTrace, source, errorNumber, message);
            return error;
        }

        /// <inheritdoc/>
        public ILogDetails CreateErrorDetails(string stackTrace, string source, int errorNumber, string message, string description)
        {
            var error = this.CreateErrorDetails(stackTrace, source, errorNumber, message);
            error.Description = description;
            return error;
        }
        #endregion Methods
    }
}

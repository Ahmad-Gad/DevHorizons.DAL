// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataAccessSettings.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Interfaces
{
    using Cache;
    using Cryptography;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///    Defines all the needed settings for the data access layers.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public interface IDataAccessSettings
    {
        #region Properties

        /// <summary>
        ///    Gets or sets all the data source connection/access related settings.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        IConnectionSettings ConnectionSettings { get; set; }

        /// <summary>
        ///    Gets or sets the log level for the "<see cref="Microsoft.Extensions.Logging.ILogger"/>" parameter passed by the dependency inject to the "<see cref="Abstracts.ACommand"/>" constructors to decide which level it will write to logs or to be totally disabled.
        ///    <para>The Default Value: Warning >> 4.</para>
        /// </summary>
        /// <remarks>If set to "None", then the whole logging will be disabled and won't write any message to the logs.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        LogLevel LogLevel { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the engine will capture and expose the raised errors/exceptions from the "<see cref="AdvacedErrorDetails"/>" instead of the base one "<see cref="ErrorDetails"/>".
        ///    <para>If set to "<c>true</c>", the error details class will include extra deep details about the current environment/platform, resources, process, etc.</para>
        ///    <para>This operation may consume extra milliseconds and extra size of the object which may consume extra disk space in the logs if being logged.</para>
        ///    <para>The Default Value: <c>false</c>.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        bool AdvancedErrorDetails { get; set; }

        /// <summary>
        ///    Gets or sets the cache settings for the data access layers.
        ///    <para>The object will be automatically initiated with the default values if not explicitly set.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>13/02/2022 06:17 PM</DateTime>
        /// </Created>
        CacheSettings CacheSettings { get; set; }

        /// <summary>
        ///    Gets or sets all the cryptography settings required for the <c>DAL</c> engine to encrypt, decrypt and hash data.
        ///    <para>The object will be automatically initiated with the default values if not explicitly set.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        CryptographySettings CryptographySettings { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails();

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="ex">The raised exception.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="ex">The raised exception.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="description">The description of the error.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber, string description);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="ex">The raised exception.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="description">The description of the error.</param>
        /// <param name="source">The source name of the error which could be a method or constructor.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(System.Exception ex, int errorNumber, string description, string source);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="stackTrace">The detailed stack trace.</param>
        /// <param name="source">The source name of the error which could be a method or constructor.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="message">The d error's message.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(LogLevel logLevel, string stackTrace, string source, int errorNumber, string message);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="stackTrace">The detailed stack trace.</param>
        /// <param name="source">The source name of the error which could be a method or constructor.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="message">The d error's message.</param>
        /// <param name="description">The description of the error.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(LogLevel logLevel, string stackTrace, string source, int errorNumber, string message, string description);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="stackTrace">The detailed stack trace.</param>
        /// <param name="source">The source name of the error which could be a method or constructor.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="message">The d error's message.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(string stackTrace, string source, int errorNumber, string message);

        /// <summary>
        ///    Create an instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".
        /// </summary>
        /// <param name="stackTrace">The detailed stack trace.</param>
        /// <param name="source">The source name of the error which could be a method or constructor.</param>
        /// <param name="errorNumber">The error number.</param>
        /// <param name="message">The d error's message.</param>
        /// <param name="description">The description of the error.</param>
        /// <returns>An instance of either "<see cref="ErrorDetails"/>" or "<see cref="AdvacedErrorDetails"/>" based on the setting "<see cref="AdvancedErrorDetails"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>16/02/2022 10:22 PM</DateTime>
        /// </Created>
        ILogDetails CreateErrorDetails(string stackTrace, string source, int errorNumber, string message, string description);
        #endregion Methods
    }
}

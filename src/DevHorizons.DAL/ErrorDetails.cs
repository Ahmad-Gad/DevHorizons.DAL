// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ErrorDetails.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines all the needed members for raised error/exceptions.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using Interfaces;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///    A class defines all the needed members for raised error/exceptions.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>02/11/2018 05:33 PM</DateTime>
    /// </Created>
    public class ErrorDetails : ILogDetails
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ErrorDetails"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:34 PM</DateTime>
        /// </Created>
        public ErrorDetails()
        {
            this.SourceMachine = Environment.MachineName;
            this.LogTime = DateTime.UtcNow;
            var stackTrace = new StackTrace();
            this.StackTrace = new StackTrace().ToString();
            this.Source = stackTrace.GetFrame(1).GetMethod().Name;
        }
        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public LogLevel LogLevel { get; set; } = LogLevel.Error;

        /// <inheritdoc/>
        public int Number { get; set; }

        /// <inheritdoc/>
        public string Message { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string Source { get; set; }

        /// <inheritdoc/>
        public ConnectionState? ConnectionState { get; set; }

        /// <inheritdoc/>
        public Exception Exception { get; set; }

        /// <inheritdoc/>
        public string StackTrace { get; set; }

        /// <inheritdoc/>
        public string SourceMachine { get; set; }

        /// <inheritdoc/>
        public string DataSourceName { get; set; }

        /// <inheritdoc/>
        public string DatabaseName { get; set; }

        /// <inheritdoc/>
        public DateTime LogTime { get; set; }

        /// <inheritdoc/>
        public string CommandText { get; set; }

        /// <inheritdoc/>
        public bool? HasParameters { get; set; }

        /// <inheritdoc/>
        public CommandExecutionType? CommandExecutionType { get; set; }

        /// <inheritdoc/>
        public CommandSource? CommandSource { get; set; }

        /// <inheritdoc/>
        public ParametersSource? ParametersSource { get; set; }

        /// <inheritdoc/>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <inheritdoc/>
        public long FirstLevelCacheMemorySize { get; set; }

        /// <inheritdoc/>
        public long SecondLevelCacheMemorySize { get; set; }

        /// <inheritdoc/>
        public long ThirdLevelCacheMemorySize { get; set; }

        /// <inheritdoc/>
        public string DataSourceVersion { get; set; }

        /// <inheritdoc/>
        public bool? DataExecutionSuccessful { get; set; }
        #endregion Properties
    }
}

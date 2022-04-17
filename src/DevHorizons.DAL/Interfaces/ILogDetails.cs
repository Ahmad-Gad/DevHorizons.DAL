// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogDetails.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the needed members for raised error/exceptions/warnings/etc.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Interfaces
{
    using System;
    using System.Data;

    using Cache;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///    An interface defines all the needed members for raised error/exceptions/warnings/etc.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>02/11/2018 05:33 PM</DateTime>
    /// </Created>
    public interface ILogDetails
    {
        #region Properties

        /// <summary>
        ///    Gets or sets Log Level of the error, warning, etc.
        /// </summary>
        /// <value>
        ///    The Log Level.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        LogLevel LogLevel { get; set; }

        /// <summary>
        ///    Gets or sets the error number.
        /// </summary>
        /// <value>
        ///    The error number.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        int Number { get; set; }

        /// <summary>
        ///    Gets or sets the error message.
        /// </summary>
        /// <value>
        ///    The error message.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        string Message { get; set; }

        /// <summary>
        ///    Gets or sets the error Description.
        /// </summary>
        /// <value>
        ///    The error Description.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:36 PM</DateTime>
        /// </Created>
        string Description { get; set; }

        /// <summary>
        ///    Gets or sets the error source. E.g. Specific constructor or method.
        /// </summary>
        /// <value>
        ///    The error source.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:38 PM</DateTime>
        /// </Created>
        string Source { get; set; }

        /// <summary>
        ///    Gets or sets the current connection state with the sepcified data source.
        /// </summary>
        /// <value>
        ///    The current connection state with the sepcified data source.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:38 PM</DateTime>
        /// </Created>
        ConnectionState? ConnectionState { get; set; }

        /// <summary>
        ///    Gets or sets the raised exception.
        /// </summary>
        /// <value>
        ///    The raised exception.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:37 PM</DateTime>
        /// </Created>
        Exception Exception { get; set; }

        /// <summary>
        ///    Gets or sets the stack trace.
        /// </summary>
        /// <value>
        ///    The stack trace.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        string StackTrace { get; set; }

        /// <summary>
        ///    Gets or sets the source machine/server name.
        /// </summary>
        /// <value>
        ///    The stack trace.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        string SourceMachine { get; set; }

        /// <summary>
        ///    Gets or sets the database machine name.
        /// </summary>
        /// <value>
        ///    The data source serve name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        string DataSourceName { get; set; }

        /// <summary>
        ///    Gets or sets the database server/product version details in line string.
        /// </summary>
        /// <value>
        ///    The database server/product version details in line string.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        string DataSourceVersion { get; set; }

        /// <summary>
        ///    Gets or sets the database name.
        /// </summary>
        /// <value>
        ///    The connected database name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        string DatabaseName { get; set; }

        /// <summary>
        ///    Gets or sets the UTC/GMT date/time of the raised error/warning/etc..
        /// </summary>
        /// <value>
        ///    The stack trace.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/11/2018 02:24 PM</DateTime>
        /// </Created>
        DateTime LogTime { get; set; }

        /// <summary>
        ///    Gets or sets the stored procedure name or the clear "<c>SQL</c>" command text to execute.
        /// </summary>
        /// <value>
        ///    The stored procedure name or the clear "<c>SQL</c>" command text to execute.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        string CommandText { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the specified command (stored procedure) includes parameters or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> ifthe specified command (stored procedure) includes parameters; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        bool? HasParameters { get; set; }

        /// <summary>
        ///    Gets or sets the way/behaviour the command (stored procedure) will be executed as command, scalar or query.
        /// </summary>
        /// <value>
        ///    The behaviour of the command (stored procedure) execution as command, scalar or query.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        CommandExecutionType? CommandExecutionType { get; set; }

        /// <summary>
        ///    Gets or sets the definition source of the command (stored procedure) name which could be explicitly defined or through an "<see cref="ICommandBody"/>" implemented instance.
        /// </summary>
        /// <value>
        ///    The definition source of the command (stored procedure) name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        CommandSource? CommandSource { get; set; }

        /// <summary>
        ///    Gets or sets the definition source of the required parameters for the specified command (stored procedure) which could be explicitly defined one or more of "<see cref="IParameter"/>", a generic dictionary or through an "<see cref="ICommandBody"/>" implemented instance.
        /// </summary>
        /// <value>
        ///    The definition source of the command (stored procedure) name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        ParametersSource? ParametersSource { get; set; }

        /// <summary>
        ///    Gets or sets the transaction locking behavior for the connection.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 12:25 PM</DateTime>
        /// </Created>
        DAL.IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the first level cached objects.
        /// </summary>
        /// <remarks>This is only applicable if the "<see cref="IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long FirstLevelCacheMemorySize { get; set; }

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the second level cached objects.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of the second level cache is set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long SecondLevelCacheMemorySize { get; set; }

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the third level cached objects.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of the third level cache is set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long ThirdLevelCacheMemorySize { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the specified command (stored procedure) execution has been completed from the data source side.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the specified command (stored procedure) execution has been completed from the data source side; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///    If <c>true</c>, but error(s) or warning(s) are being raised, it means an error/warning from the engine client data layer side which could be issue in output parameter updates, output data transforamtion, etc.
        ///    <para>If the command is doing any '<c>DML</c>' operation on the database, it's always recommended to check for this value before trying to rerun this operation again to avoid data inconsistency (data quality issues like data duplicates).</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>18/02/2022 07:00 PM</DateTime>
        /// </Created>
        bool? DataExecutionSuccessful { get; set; }
        #endregion Properties
    }
}

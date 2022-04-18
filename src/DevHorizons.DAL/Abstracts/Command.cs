// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Command.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the Command abstract class.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Abstracts
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;

    using Attributes;

    using Cache;

    using Cryptography;

    using Interfaces;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    using Shared;

    /// <summary>
    ///    The <c>DAL</c> Command abstract class which holds all the required members and operations to access the database and <c>T-SQL</c> command executions.
    /// <para>This abstract class can be used for the <c>DI</c> (Dependency Injection) design pattern.</para>
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 10:25 PM</DateTime>
    /// </Created>
    public abstract class Command : ICommand
    {
        #region Private Fields
        #region ReadOnly Fields

        /// <summary>
        ///    The designated data factory which identifies the data source manufacturer E.g. SQL, Oracle, etc.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        private readonly DataProviderFactory dataProviderFactory;
        #endregion ReadOnly Fields

        /// <summary>
        ///    If <c>true</c> ino further database commands/transactions will be executed until the "<see cref="ClearErrors()"/>" is being called to reset.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 12:25 PM</DateTime>
        /// </Created>
        private bool terminateFurtherExecutions;

        /// <summary>
        ///   The definition source of the command (stored procedure) name.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        private CommandSource? commandSource;

        /// <summary>
        ///   The execution type/behaviour of a command.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        private CommandExecutionType? commandExecutionType;

        /// <summary>
        ///   The definition source of the required parameters for the specified command (stored procedure).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 04:58 PM</DateTime>
        /// </Created>
        private ParametersSource? parametersSource;

        /// <summary>
        ///    Specifies the transaction locking behavior for the connection.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 12:25 PM</DateTime>
        /// </Created>
        private DAL.IsolationLevel? isolationLevel;

        /// <summary>
        ///    Gets or sets a value indicating whether the specified command (stored procedure) execution has been completed from the data source side.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the specified command (stored procedure) execution has been completed from the data source side; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///    This value will be represnted by the "<see cref="ILogDetails.DataExecutionSuccessful"/>".
        ///    <para>If <c>true</c>, but error(s) or warning(s) are being raised, it means an error/warning from the engine client data layer side which could be issue in output parameter updates, output data transforamtion, etc.</para>
        ///    <para>If the command is doing any '<c>DML</c>' operation on the database, it's always recommended to check the "<see cref="ILogDetails.DataExecutionSuccessful"/>" value before trying to rerun this operation again to avoid data inconsistency (data quality issues like data duplicates).</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>18/02/2022 07:00 PM</DateTime>
        /// </Created>
        private bool? dataExecutionSuccessful;
        #region IDisposable Support

        /// <summary>
        ///    The disposed boolean value to detect redundant calls.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 04:47 PM</DateTime>
        /// </Created>
        private bool disposedValue;

        #endregion IDisposable Support
        #endregion Private Fields

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="Command"/> class.
        ///    <para>This Constructor is used only to be implemented internally to implement the target data provider factory.</para>
        /// </summary>
        /// <param name="dataProviderFactory">The designated data factory which identifies the data source manufacturer E.g. SQL, Oracle, etc.</param>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="memoryCache">The memory cache object passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <param name="logger">The logger object of the type "<see cref="ILogger"/>" which could be registered by the Dependency Injection.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:27 PM</DateTime>
        /// </Created>
        public Command(DataProviderFactory dataProviderFactory, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, ILogger<Command> logger)
        {
            this.dataProviderFactory = dataProviderFactory;
            this.MemoryCache = memoryCache;
            this.Settings = dataAccessSettings;
            this.Logger = logger;
            var ok = this.InitializeConnection();
            if (ok)
            {
                this.ChangeDatabase(dataAccessSettings.ConnectionSettings.DatabaseName);
            }
        }
        #endregion Constructors

        #region Delegates

        /// <summary>
        ///    A delegate to handel the error raised by the class.
        /// </summary>
        /// <param name="error">The raised error.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 11:13 AM</DateTime>
        /// </Created>
        public delegate void RaiseError(ILogDetails error);

        /// <summary>
        ///    A delegate to handel the warning raised by the class.
        /// </summary>
        /// <param name="error">The raised warning.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>17/02/2022 11:13 PM</DateTime>
        /// </Created>
        public delegate void RaiseWarning(ILogDetails error);
        #endregion Delegates

        #region Event Handlers

        /// <inheritdoc/>
        public event ICommand.RaiseError ErrorRaised;

        /// <inheritdoc/>
        public event ICommand.RaiseWarning WarningRaised;
        #endregion Event Handlers

        #region Properties
        #region Public Properties

        /// <inheritdoc/>
        public List<ILogDetails> Errors { get; private set; } = new List<ILogDetails>();

        /// <inheritdoc/>
        public List<ILogDetails> Warnings { get; private set; } = new List<ILogDetails>();

        /// <inheritdoc/>
        public List<IParameter> Parameters { get; private set; } = new List<IParameter>();

        /// <inheritdoc/>
        public long FirstLevelCacheMemorySize
        {
            get
            {
                return this.MemoryCache == null || this.Settings.CacheSettings.Disabled ? 0 : this.MemoryCache.FirstLevelCacheMemorySize;
            }
        }

        /// <inheritdoc/>
        public long SecondLevelCacheMemorySize
        {
            get
            {
                return this.MemoryCache == null || this.Settings.CacheSettings.DisableSecondLevel ? 0 : this.MemoryCache.SecondLevelCacheMemorySize;
            }
        }

        /// <inheritdoc/>
        public long TotalCacheMemorySize
        {
            get
            {
                return this.MemoryCache == null || this.Settings.CacheSettings.Disabled || this.Settings.CacheSettings.DisableSecondLevel ? 0 : this.MemoryCache.FirstLevelCacheMemorySize + this.MemoryCache.SecondLevelCacheMemorySize;
            }
        }
        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        ///    Gets or sets the data connection as an instance of "<see cref="DbConnection" />".
        /// </summary>
        /// <value>
        ///    The data connection as an instance of "<see cref="DbConnection" />".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>19/02/2020 11:02 PM</DateTime>
        /// </Created>
        internal DbConnection Con { get; set; }

        /// <summary>
        ///    Gets or sets the data command as an instance of "<see cref="DbCommand" />".
        /// </summary>
        /// <value>
        ///    The data command as an instance of "<see cref="DbCommand" />".
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/11/2018 12:12 PM</DateTime>
        /// </Created>
        internal DbCommand Cmd { get; set; }

        #region Protected Fields

        /// <summary>
        ///    Gets the built-in memory cache on the host machine which is following life cycle of the host application and usually being hosted in a Singleton Dependency Injection life cycle.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        protected internal IMemoryCache MemoryCache { get; private set; }

        /// <summary>
        ///    Gets all the needed settings for the data access layers.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        protected internal IDataAccessSettings Settings { get; private set; }

        /// <summary>
        ///    Gets the logger object of the type "<see cref="ILogger"/>" which could be registered by the Dependency Injection.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        protected internal ILogger<Command> Logger { get; private set; }
        #endregion Protected Fields
        #endregion Internal Properties

        #region Private Properties

        /// <summary>
        ///    Gets or sets the database transaction within the same opened connection as an instance of "<see cref="DbTransaction"/>" which will be generated by executing the "<see cref="DbConnection.BeginTransaction()"/>" method.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>12/02/2022 12:25 PM</DateTime>
        /// </Created>
        private DbTransaction Tran { get; set; }
        #endregion Private Properties
        #endregion Properties

        #region Public Methods
        #region Operation Methods

        /// <inheritdoc/>
        public bool CanExecute()
        {
            return !this.terminateFurtherExecutions && this.Cmd != null && this.Con?.State == ConnectionState.Open;
        }

        /// <inheritdoc/>
        public string GetCurrentDatabaseName()
        {
            return this.Con?.Database;
        }

        /// <inheritdoc/>
        public bool ChangeDatabase(string database)
        {
            if (this.Con == null || database.IsNullOrEmpty(true))
            {
                return false;
            }

            database = database.Trim();
            var currentDatabase = this.GetCurrentDatabaseName();
            if (currentDatabase.Equals(database, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            ILogDetails error = null;

            try
            {
                this.Con.ChangeDatabase(database);
                return true;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ChangeDatabase(string database)",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to change the connection of the database from '{currentDatabase}' to '{database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.ChangeDatabase(string database)",
                   errorNumber: -205,
                   description: $"Excepation has been raised while attempting to change the connection of the database from '{currentDatabase}' to '{database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            finally
            {
                this.HandleError(error);
            }
        }

        /// <inheritdoc/>
        public bool ChangeConnectionString(string connectionString)
        {
            if (this.Settings?.ConnectionSettings == null)
            {
                return false;
            }

            this.Settings.ConnectionSettings.ConnectionString = connectionString;
            return this.Reset(true);
        }

        /// <inheritdoc/>
        public void ClearErrors()
        {
            this.Errors.Clear();
        }

        /// <inheritdoc/>
        public void ClearWarnings()
        {
            this.Warnings.Clear();
        }

        /// <inheritdoc/>
        public void AddParameter(IParameter parameter)
        {
            this.Parameters.Add(parameter);
            this.Cmd.Parameters.Add(this.GetDbParameter(parameter));
        }

        /// <inheritdoc/>
        public void AddParameters(ICollection<IParameter> parameters)
        {
            this.Parameters.AddRange(parameters);
            this.Cmd.Parameters.AddRange(this.GetDbParameters(this.Parameters).ToArray());
        }

        /// <inheritdoc/>
        public void AddParameters(params IParameter[] parameters)
        {
            this.AddParameters(parameters.ToList());
        }

        /// <inheritdoc/>
        public void ClearParameters()
        {
            this.Parameters.ForEach(p => p.Value = null);
            this.Parameters.Clear();
            this.Cmd.Parameters.Clear();
        }

        /// <inheritdoc/>
        public bool Reset()
        {
            this.Tran?.Dispose();
            if (this.Cmd == null || this.Con?.State != ConnectionState.Open)
            {
                return false;
            }

            this.ClearErrors();
            this.terminateFurtherExecutions = false;
            this.ClearParameters();
            this.Cmd.CommandText = null;
            this.Cmd.Transaction = null;
            this.commandSource = null;
            this.commandExecutionType = null;
            return true;
        }

        /// <inheritdoc/>
        public bool Reset(bool hardReset)
        {
            var normalResetResult = this.Reset();
            if (hardReset)
            {
                this.Cmd?.Dispose();
                this.Con?.Dispose();
                return this.InitializeConnection();
            }

            return normalResetResult;
        }

        /// <inheritdoc/>
        public bool BeginTransaction()
        {
            if (!this.CanExecute())
            {
                return false;
            }

            ILogDetails error = null;

            try
            {
                this.Reset();
                this.Tran = this.Con.BeginTransaction();
                this.Cmd.Transaction = this.Tran;
                return true;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.BeginTransaction()",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to start a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.BeginTransaction()",
                    errorNumber: -500,
                    description: $"DB Exception has been raised while attempting to start a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            finally
            {
                if (error != null)
                {
                    this.terminateFurtherExecutions = true;
                    this.HandleError(error);
                }
            }
        }

        /// <inheritdoc/>
        public bool BeginTransaction(DAL.IsolationLevel isolationLevel)
        {
            if (!this.CanExecute())
            {
                return true;
            }

            ILogDetails error = null;

            try
            {
                this.Tran = this.Con.BeginTransaction((IsolationLevel)isolationLevel);
                this.Cmd.Transaction = this.Tran;
                return true;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.BeginTransaction(DAL.IsolationLevel isolationLevel)",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to start a database transaction in the database server '{this.Con?.DataSource}' with the isolation level '{isolationLevel}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                     ex: ex,
                     source: "DAL.Command.BeginTransaction(DAL.IsolationLevel isolationLevel)",
                     errorNumber: -502,
                     description: $"DB Exception has been raised while attempting to start a database transaction in the database server '{this.Con?.DataSource}' with the isolation level '{isolationLevel}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            finally
            {
                if (error != null)
                {
                    this.terminateFurtherExecutions = true;
                }

                this.HandleError(error);
            }
        }

        /// <inheritdoc/>
        public bool CommitTransaction(bool forceCommit, bool autoRollback)
        {
            ILogDetails error = null;
            if (!forceCommit && this.Errors?.Count > 0)
            {
                return false;
            }

            if (!this.CanExecute())
            {
                error = this.Settings.CreateErrorDetails(
                    logLevel: LogLevel.Error,
                    source: "DAL.Command.CommitTransaction(bool forceCommit, bool autoRollback)",
                    stackTrace: Environment.StackTrace,
                    errorNumber: -501,
                    message: $"Failed to commit a transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!",
                    description: $"The 'DAL' service/connection may not yet initialized!");

                return false;
            }

            if (this.Cmd.Transaction == null)
            {
                error = this.Settings.CreateErrorDetails(
                    logLevel: LogLevel.Error,
                    source: "DAL.Command.CommitTransaction(bool forceCommit, bool autoRollback)",
                    stackTrace: Environment.StackTrace,
                    errorNumber: -502,
                    message: $"Failed to commit a transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!",
                    description: $"The 'DAL' command doesn't have a started transaction yet. Please make sure you call the '{this.GetType().Name}.{nameof(this.BeginTransaction)}()' first!");

                return false;
            }

            try
            {
                this.Tran.Commit();
                return true;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.CommitTransaction(bool forceCommit, bool autoRollback)",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to commit a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.CommitTransaction(bool forceCommit, bool autoRollback)",
                   errorNumber: -503,
                   description: $"DB Exception has been raised while attempting to commit a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            finally
            {
                if (error != null)
                {
                    if (autoRollback)
                    {
                        this.RollbackTransaction();
                    }

                    this.terminateFurtherExecutions = true;
                }
                else
                {
                    this.Tran?.Dispose();
                    if (this.Cmd != null)
                    {
                        this.Cmd.Transaction = null;
                    }
                }

                this.HandleError(error);
            }
        }

        /// <inheritdoc/>
        public bool CommitTransaction(bool autoRollback)
        {
            return this.CommitTransaction(false, autoRollback);
        }

        /// <inheritdoc/>
        public bool CommitTransaction()
        {
            return this.CommitTransaction(false, true);
        }

        /// <inheritdoc/>
        public bool RollbackTransaction()
        {
            this.terminateFurtherExecutions = true;
            ILogDetails error = null;

            if (!this.CanExecute())
            {
                error = this.Settings.CreateErrorDetails(
                    logLevel: LogLevel.Error,
                    source: "DAL.Command.RollbackTransaction()",
                    stackTrace: Environment.StackTrace,
                    errorNumber: -501,
                    message: $"Failed to rollback a transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!",
                    description: $"The 'DAL' service/connection may not yet initialized!");

                return false;
            }

            if (this.Cmd.Transaction == null)
            {
                error = this.Settings.CreateErrorDetails(
                    logLevel: LogLevel.Error,
                    source: "DAL.Command.RollbackTransaction()",
                    stackTrace: Environment.StackTrace,
                    errorNumber: -502,
                    message: $"Failed to rollback a transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!",
                    description: $"The 'DAL' command doesn't have a started transaction yet. Please make sure you call the '{this.GetType().Name}.{nameof(this.BeginTransaction)}()' first!");

                return false;
            }

            try
            {
                this.Tran.Rollback();
                return true;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                         ex: ex,
                         source: "DAL.Command.RollbackTransaction()",
                         errorNumber: ex.ErrorCode,
                         description: $"DB Exception has been raised while attempting to rollback a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                         ex: ex,
                         source: "DAL.Command.RollbackTransaction()",
                         errorNumber: -504,
                         description: $"DB Exception has been raised while attempting to rollback a database transaction in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the server is '{this.Con.State}'!");

                return false;
            }
            finally
            {
                this.Tran?.Dispose();
                if (this.Cmd != null)
                {
                    this.Cmd.Transaction = null;
                }

                this.HandleError(error);
            }
        }
        #endregion Operation Methods

        #region DAO Methods
        #region Execute Query

        /// <inheritdoc/>
        public List<T> ExecuteQuery<T>(ICommandBody commandBody)
        {
            if (!this.CanExecute())
            {
                return null;
            }

            this.commandExecutionType = CommandExecutionType.ExecuteQuery;
            this.commandSource = CommandSource.CommandBody;
            this.parametersSource = ParametersSource.CommandBody;

            string procName;
            if (string.IsNullOrWhiteSpace(commandBody.CommandName))
            {
                var attribute = commandBody.GetCustomAttribute<CommandBodyAttribute>();
                if (attribute == null || string.IsNullOrWhiteSpace(attribute.Name))
                {
                    var error = this.Settings.CreateErrorDetails(
                        logLevel: LogLevel.Error,
                        source: "DAL.Command.ExecuteQuery<T>(ICommandBody commandBody)",
                        stackTrace: Environment.StackTrace,
                        errorNumber: -300,
                        message: "The Command name is missing",
                        description: "The stored procedure name is neither specified in the 'CommandName' property nor the 'CommandBody' attribute!");

                    this.HandleError(error);
                    return null;
                }

                procName = attribute.Name;
            }
            else
            {
                procName = commandBody.CommandName;
            }

            var parameters = this.GetParmetersFromCommandBody(commandBody);

            var result = this.ExecuteQuery<T>(procName, parameters);
            this.UpdateCommandBody(commandBody);
            return result;
        }

        /// <inheritdoc/>
        public List<T> ExecuteQuery<T>(string proc)
        {
            if (!this.CanExecute())
            {
                return null;
            }

            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.None;
            }

            this.Cmd.CommandText = proc;
            var list = this.GetDataFromDataReader<T>();
            return this.UpdateParameters() && this.Errors.Count == 0 ? list : null;
        }

        /// <inheritdoc/>
        public List<T> ExecuteQuery<T>(string proc, ICollection<IParameter> parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteQuery<T>(proc);
        }

        /// <inheritdoc/>
        public List<T> ExecuteQuery<T>(string proc, params IParameter[] parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteQuery<T>(proc);
        }

        /// <inheritdoc/>
        public List<T> ExecuteQuery<T>(string proc, Dictionary<string, object> parameters)
        {
            this.parametersSource = ParametersSource.Dictionary;
            var list = this.GetParmetersFromDictionary(parameters);
            return this.ExecuteQuery<T>(proc, list);
        }
        #endregion Execute Query

        #region Execute Scalar
        #region Object

        /// <inheritdoc/>
        public object ExecuteScalar(ICommandBody commandBody)
        {
            if (!this.CanExecute())
            {
                return null;
            }

            this.commandExecutionType = CommandExecutionType.ExecuteScalar;
            this.commandSource = CommandSource.CommandBody;
            this.parametersSource = ParametersSource.CommandBody;

            ILogDetails error = null;
            if (string.IsNullOrWhiteSpace(commandBody.CommandName))
            {
                var attribute = commandBody.GetCustomAttribute<CommandBodyAttribute>();
                if (attribute == null || string.IsNullOrWhiteSpace(attribute.Name))
                {
                    error = this.Settings.CreateErrorDetails(
                       logLevel: LogLevel.Error,
                       source: "DAL.Command.ExecuteScalar(ICommandBody commandBody)",
                       stackTrace: Environment.StackTrace,
                       errorNumber: -300,
                       message: "The Command name is missing",
                       description: "The stored procedure name is neither specified in the 'CommandName' property nor the 'CommandBody' attribute!");

                    this.HandleError(error);
                    return null;
                }

                this.Cmd.CommandText = attribute.Name;
            }
            else
            {
                this.Cmd.CommandText = commandBody.CommandName;
            }

            var parameters = this.GetParmetersFromCommandBody(commandBody);

            try
            {
                this.ResetParameters(parameters);
                var result = this.Cmd.ExecuteScalar();
                this.dataExecutionSuccessful = true;
                return this.UpdateParameters() && this.UpdateCommandBody(commandBody) ? result : null;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.ExecuteScalar(ICommandBody commandBody)",
                   errorNumber: ex.ErrorCode,
                   description: $"DB Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");

                return null;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.ExecuteScalar(ICommandBody commandBody)",
                   errorNumber: -301,
                   description: $"An Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");

                return null;
            }
            finally
            {
                this.HandleError(error);
            }
        }

        /// <inheritdoc/>
        public object ExecuteScalar(string proc)
        {
            if (!this.CanExecute())
            {
                return default;
            }

            this.commandExecutionType = CommandExecutionType.ExecuteScalar;
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.None;
            }

            ILogDetails error = null;
            this.Cmd.CommandText = proc;
            try
            {
                var result = this.Cmd.ExecuteScalar();
                this.dataExecutionSuccessful = true;
                return this.UpdateParameters() ? result : null;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteScalar(string proc)",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to fetch a scalar value by the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteScalar(string proc)",
                    errorNumber: -301,
                    description: $"An Exception has been raised while attempting to fetch a scalar value by the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            finally
            {
                if (error != null)
                {
                    this.commandExecutionType = CommandExecutionType.ExecuteScalar;
                    if (this.commandSource == null)
                    {
                        this.commandSource = CommandSource.Explicit;
                    }

                    if (this.Parameters.Count == 0)
                    {
                        this.parametersSource = ParametersSource.None;
                    }

                    this.HandleError(error);
                }
            }

            return default;
        }

        /// <inheritdoc/>
        public object ExecuteScalar(string proc, ICollection<IParameter> parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteScalar(proc);
        }

        /// <inheritdoc/>
        public object ExecuteScalar(string proc, params IParameter[] parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteScalar(proc);
        }

        /// <inheritdoc/>
        public object ExecuteScalar(string proc, Dictionary<string, object> parameters)
        {
            this.parametersSource = ParametersSource.Dictionary;
            var list = this.GetParmetersFromDictionary(parameters);
            return this.ExecuteScalar(proc, list);
        }
        #endregion Object

        #region Generic

        /// <inheritdoc/>
        public T ExecuteScalar<T>(ICommandBody commandBody)
        {
            this.commandSource = CommandSource.CommandBody;
            this.parametersSource = ParametersSource.CommandBody;
            var result = this.ExecuteScalar(commandBody);
            this.UpdateCommandBody(commandBody);
            return result == null ? default : result.To<T>();
        }

        /// <inheritdoc/>
        public T ExecuteScalar<T>(string proc)
        {
            var result = this.ExecuteScalar(proc);
            return result == null ? default : result.To<T>();
        }

        /// <inheritdoc/>
        public T ExecuteScalar<T>(string proc, ICollection<IParameter> parameters)
        {
            var result = this.ExecuteScalar(proc, parameters);
            return result == null ? default : result.To<T>();
        }

        /// <inheritdoc/>
        public T ExecuteScalar<T>(string proc, params IParameter[] parameters)
        {
            var result = this.ExecuteScalar(proc, parameters);
            return result == null ? default : result.To<T>();
        }

        /// <inheritdoc/>
        public T ExecuteScalar<T>(string proc, Dictionary<string, object> parameters)
        {
            var result = this.ExecuteScalar(proc, parameters);
            return result == null ? default : result.To<T>();
        }
        #endregion Generic
        #endregion Execute Scalar

        #region Execute Command

        /// <inheritdoc/>
        public bool ExecuteCommand(IDataTable dataTable, CommandAction commandAction)
        {
            if (!this.CanExecute())
            {
                return false;
            }

            ILogDetails error = null;

            this.commandSource = CommandSource.DataTable;
            if (this.commandExecutionType == null)
            {
                this.commandExecutionType = CommandExecutionType.ExecuteCommand;
            }

            try
            {
                var parmeters = dataTable.GetParmeters(commandAction);
                this.AddParameters(parmeters);
                var commandText = dataTable.GetCommandText(this.Parameters, commandAction);
                this.Cmd.CommandText = commandText;
                this.Cmd.CommandType = CommandType.Text;
                dataTable.RowsCount = this.Cmd.ExecuteNonQuery();

                this.dataExecutionSuccessful = true;
                return this.UpdateParameters() && this.UpdateCommandBody(dataTable);
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.ExecuteCommand(IDataTable dataTable, CommandAction commandAction)",
                   errorNumber: ex.ErrorCode,
                   description: $"DB Exception has been raised while attempting to execute the '{commandAction}' command '{this.Cmd.CommandText}' on the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteCommand(IDataTable dataTable, CommandAction commandAction)",
                    errorNumber: -304,
                    description: $"An Exception has been raised while attempting to execute the '{commandAction}' command '{this.Cmd.CommandText}' on the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            finally
            {
                this.Cmd.CommandType = CommandType.StoredProcedure;
                this.HandleError(error);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(ICommandBody commandBody)
        {
            if (!this.CanExecute())
            {
                return false;
            }

            if (this.commandExecutionType == null)
            {
                this.commandExecutionType = CommandExecutionType.ExecuteCommand;
            }

            this.commandSource = CommandSource.CommandBody;
            this.parametersSource = ParametersSource.CommandBody;

            ILogDetails error = null;
            if (string.IsNullOrWhiteSpace(commandBody.CommandName))
            {
                var attribute = commandBody.GetCustomAttribute<CommandBodyAttribute>();
                if (attribute == null || string.IsNullOrWhiteSpace(attribute.Name))
                {
                    error = this.Settings.CreateErrorDetails(
                       source: "DAL.Command.ExecuteCommand(ICommandBody commandBody)",
                       errorNumber: -300,
                       stackTrace: Environment.StackTrace,
                       message: "The Command name is missing",
                       description: "The stored procedure name is neither specified in the 'CommandName' property nor the 'CommandBody' attribute!");

                    this.HandleError(error);
                    return false;
                }

                this.Cmd.CommandText = attribute.Name;
            }
            else
            {
                this.Cmd.CommandText = commandBody.CommandName;
            }

            var parameters = this.GetParmetersFromCommandBody(commandBody);

            try
            {
                this.ResetParameters(parameters);
                this.Cmd.ExecuteNonQuery();
                this.dataExecutionSuccessful = true;
                return this.UpdateParameters() && this.UpdateCommandBody(commandBody);
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                   ex: ex,
                   source: "DAL.Command.ExecuteCommand(ICommandBody commandBody)",
                   errorNumber: ex.ErrorCode,
                   description: $"DB Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteCommand(ICommandBody commandBody)",
                    errorNumber: -302,
                    description: $"An Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            finally
            {
                this.HandleError(error);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool ExecuteTranCommands(ICollection<ICommandBody> commandBodyList)
        {
            if (!this.CanExecute())
            {
                return false;
            }

            this.commandExecutionType = CommandExecutionType.ExecuteTranCommands;

            if (!this.BeginTransaction())
            {
                return false;
            }

            foreach (var commandBody in commandBodyList)
            {
                if (!this.ExecuteCommand(commandBody))
                {
                    this.RollbackTransaction();
                    return false;
                }
            }

            return this.CommitTransaction();
        }

        /// <inheritdoc/>
        public bool ExecuteTranCommands(params ICommandBody[] commandBody)
        {
            return this.ExecuteTranCommands(commandBody.ToList());
        }

        /// <inheritdoc/>
        public bool ExecuteTranCommands(DAL.IsolationLevel isolationLevel, params ICommandBody[] commandBody)
        {
            return this.ExecuteTranCommands(commandBody, isolationLevel);
        }

        /// <inheritdoc/>
        public bool ExecuteTranCommands(ICollection<ICommandBody> commandBodyList, DAL.IsolationLevel isolationLevel)
        {
            if (!this.CanExecute())
            {
                return false;
            }

            this.isolationLevel = isolationLevel;
            this.commandExecutionType = CommandExecutionType.ExecuteTranCommands;

            if (!this.BeginTransaction(isolationLevel))
            {
                return false;
            }

            foreach (var commandBody in commandBodyList)
            {
                if (!this.ExecuteCommand(commandBody))
                {
                    this.RollbackTransaction();
                    return false;
                }
            }

            return this.CommitTransaction();
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(string proc)
        {
            if (!this.CanExecute())
            {
                return false;
            }

            if (this.commandExecutionType == null)
            {
                this.commandExecutionType = CommandExecutionType.ExecuteCommand;
            }

            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.None;
            }

            ILogDetails error = null;
            this.Cmd.CommandText = proc;
            try
            {
                return this.UpdateParameters();
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteCommand(string proc)",
                    errorNumber: -ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.ExecuteCommand(string proc)",
                    errorNumber: -302,
                    description: $"An Exception has been raised while attempting to execute the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");
            }
            finally
            {
                this.HandleError(error);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(string proc, ICollection<IParameter> parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteCommand(proc);
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(string proc, params IParameter[] parameters)
        {
            if (this.commandSource == null)
            {
                this.commandSource = CommandSource.Explicit;
            }

            if (this.parametersSource == null)
            {
                this.parametersSource = ParametersSource.Explicit;
            }

            this.ResetParameters(parameters);
            return this.ExecuteCommand(proc);
        }

        /// <inheritdoc/>
        public bool ExecuteCommand(string proc, Dictionary<string, object> parameters)
        {
            this.parametersSource = ParametersSource.Dictionary;
            var list = this.GetParmetersFromDictionary(parameters);
            return this.ExecuteCommand(proc, list);
        }
        #endregion Execute Command
        #endregion DAO Methods

        #region IDisposable Support

        /// <summary>
        ///    Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:13 PM</DateTime>
        /// </Created>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable Support
        #endregion Public Methods

        #region Internal Methods
        #region Error Handle Methods

        /// <summary>
        ///    Handles the error.
        /// </summary>
        /// <param name="error">The error details.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 11:12 AM</DateTime>
        /// </Created>
        protected internal void HandleError(ILogDetails error)
        {
            if (error == null)
            {
                return;
            }

            this.UpdateErrorDetails(error);

            if (error.LogLevel == LogLevel.Warning)
            {
                this.Warnings.Add(error);
                this.WarningRaised?.Invoke(error);
            }
            else
            {
                this.Errors.Add(error);
                this.ErrorRaised?.Invoke(error);
            }

            if (this.Logger != null && this.Settings != null && error.LogLevel != LogLevel.None && this.Settings.LogLevel <= error.LogLevel)
            {
                this.Logger.Log(error.LogLevel, "The follwoing Exception/Error has been raised by the 'DAL' engine:", error);
            }
        }
        #endregion Error Handle Methods
        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        ///    Gets the factory database connection.
        ///    <para>This method can be be overridden by the derived class to return an implementation object of the "<see cref="DbConnection"/>" that match the target provider factory.</para>
        /// </summary>
        /// <param name="provider">The data provider factory name of the type "<see cref="DataProviderFactory"/>".</param>
        /// <returns>An instance of a class that implements "<see cref="DbConnection"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:15 PM</DateTime>
        /// </Created>
        protected DbConnection GetFactoryDbConnection(DataProviderFactory provider)
        {
            ILogDetails error = null;
            try
            {
                var factory = this.GetDataProviderFactory(provider);
                if (factory == null)
                {
                    error = this.Settings.CreateErrorDetails(
                        errorNumber: -200,
                        source: "DAL.Command.GetFactoryDbConnection(DataProviderFactory provider)",
                        message: "DataProviderFactory is null!",
                        stackTrace: Environment.StackTrace,
                        description: $"Failed to create a data connection from the factory provider from nullable 'DataProviderFactory' '{provider}'!");

                    return null;
                }

                var con = factory.CreateConnection();
                return con;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    errorNumber: ex.ErrorCode,
                    source: "DAL.Command.GetFactoryDbConnection(DataProviderFactory provider)",
                    description: $"DB Exception has been raised while attempting to create a data connection from the factory provider '{provider}'!");
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    errorNumber: -201,
                    source: "DAL.Command.GetFactoryDbConnection(DataProviderFactory provider)",
                    description: $"An Exception has been raised while attempting to create a data connection from the factory provider '{provider}'!");
            }
            finally
            {
                this.HandleError(error);
            }

            return null;
        }

        /// <summary>
        ///    Gets the database parameter as an instance of a class that implements "<see cref="DbParameter"/>".
        ///    <para>This method can be be overridden by the derived class to return an implementation object of the "<see cref="DbParameter"/>" that match the target provider factory.</para>
        /// </summary>
        /// <param name="parameter">The parameter as an instance of a class that implements "<see cref="IParameter"/>".</param>
        /// <returns>An instance of a class that implements "<see cref="DbParameter"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:07 PM</DateTime>
        /// </Created>
        protected virtual DbParameter GetDbParameter(IParameter parameter)
        {
            var dbParameter = this.Cmd.CreateParameter();
            if (parameter == null)
            {
                return dbParameter;
            }

            this.UpdateParameter(parameter);
            dbParameter.ParameterName = parameter.Name;
            dbParameter.Direction = (ParameterDirection)parameter.Direction;
            dbParameter.Size = parameter.Size;
            dbParameter.Scale = parameter.Scale;
            dbParameter.Precision = parameter.Precision;
            if (dbParameter.Direction != ParameterDirection.ReturnValue && dbParameter.Direction != ParameterDirection.Output)
            {
                if (parameter.Value != null)
                {
                    if (parameter.Encrypted || (parameter.ParameterAttribute != null && parameter.ParameterAttribute.Encrypted))
                    {
                        var nonDeterministic = parameter.ParameterAttribute.EncryptionType == EncryptionType.Randomized || this.Settings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType == EncryptionType.Randomized;
                        var cryptoResult = parameter.Value.ToString().EncryptSymmetric(this.Settings, nonDeterministic, this.MemoryCache);
                        if (cryptoResult.OutputError != null)
                        {
                            this.HandleError(cryptoResult.OutputError);
                            throw cryptoResult.OutputError.Exception;
                        }

                        var value = cryptoResult.Value;
                        parameter.Value = value;
                        if (parameter.ParameterAttribute.SpecialType != SpecialType.Xml && parameter.ParameterAttribute.SpecialType != SpecialType.Json && parameter.ParameterAttribute.SpecialType != SpecialType.Base64 && dbParameter.DbType != System.Data.DbType.Xml)
                        {
                            parameter.Size = value.Length;
                        }
                    }
                    else if (parameter.Hashed || (parameter.ParameterAttribute != null && parameter.ParameterAttribute.Hashed))
                    {
                        var cryptoResult = parameter.Value.ToString().ToHash(this.Settings, this.MemoryCache);
                        if (cryptoResult.OutputError != null)
                        {
                            this.HandleError(cryptoResult.OutputError);
                            throw cryptoResult.OutputError.Exception;
                        }

                        var value = cryptoResult.Value;
                        parameter.Value = value;
                        parameter.Size = value.Length;
                    }

                    dbParameter.Value = parameter.Value;
                    dbParameter.Size = parameter.Size;
                }
            }

            this.MapDataType(dbParameter, parameter);
            return dbParameter;
        }

        /// <summary>
        ///    Maps data type for the implemented provider factory. This method should be overridden by the derived class to map the data type that match the target provider factory.
        /// </summary>
        /// <param name="dbParameter">The database parameter as an instance of "<see cref="DbParameter"/>" or any class that implements it.</param>
        /// <param name="parameter">The parameter as an instance of a class that implements "<see cref="IParameter"/>".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:08 PM</DateTime>
        /// </Created>
        protected virtual void MapDataType(DbParameter dbParameter, IParameter parameter)
        {
            if (dbParameter != null && parameter != null)
            {
                dbParameter.DbType = (System.Data.DbType)parameter.GetPropertyValue("DataType");
            }
        }

        /// <summary>
        ///    Gets the parameters from dictionary as <see cref="List{T}"/> of <see cref="IParameter"/>.
        /// </summary>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IParameter"/>.</returns>
        /// <remarks>Needs to be implemented by the implementor class for each data factory library.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:03 PM</DateTime>
        /// </Created>
        protected virtual List<IParameter> GetParmetersFromDictionary(Dictionary<string, object> parameters)
        {
            return new List<IParameter>();
        }

        /// <summary>
        ///    Gets the parameters from dictionary as <see cref="List{T}"/> of <see cref="IParameter"/>.
        /// </summary>
        /// <param name="commandBody">The request/command buddy which holds the stored procedure name and the designated parameters.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IParameter"/>.</returns>
        /// <remarks>Needs to be implemented by the implementor class for each data factory library.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:03 PM</DateTime>
        /// </Created>
        protected virtual List<IParameter> GetParmetersFromCommandBody(ICommandBody commandBody)
        {
            return new List<IParameter>();
        }

        /// <summary>
        ///    Update the property with the correct type, value and size based on the parameter direction, assigned values, data type and the sepcial type.
        /// </summary>
        /// <param name="parameter">The <c>DAL</c> parameter.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:13 AM</DateTime>
        /// </Created>
        protected virtual void UpdateParameter(IParameter parameter)
        {
            var dalParameter = parameter as DAL.Shared.Parameter;
            if (dalParameter.DataType == DAL.Shared.DbType.Auto)
            {
                if (dalParameter.Direction == Direction.ReturnValue)
                {
                    dalParameter.DataType = DAL.Shared.DbType.Int32;
                }
                else
                {
                    this.SetParameterAutoType(dalParameter);
                }
            }
        }

        /// <summary>
        ///    Sets the type of the parameter automatically.
        /// </summary>
        /// <param name="parameter">The <c>DAL</c> parameter.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:56 PM</DateTime>
        /// </Created>
        protected virtual void SetParameterAutoType(IParameter parameter)
        {
            var dalParameter = parameter as DAL.Shared.Parameter;

            if (dalParameter.Value is string)
            {
                dalParameter.DataType = DAL.Shared.DbType.String;
                dalParameter.Size = dalParameter.Value.ToString().Length;
            }
            else if (dalParameter.Value is bool)
            {
                dalParameter.DataType = DAL.Shared.DbType.Boolean;
            }
            else if (dalParameter.Value is ulong)
            {
                dalParameter.DataType = DAL.Shared.DbType.UInt64;
            }
            else if (dalParameter.Value is long)
            {
                dalParameter.DataType = DAL.Shared.DbType.Int64;
            }
            else if (dalParameter.Value is uint)
            {
                dalParameter.DataType = DAL.Shared.DbType.UInt32;
            }
            else if (dalParameter.Value is int)
            {
                dalParameter.DataType = DAL.Shared.DbType.Int32;
            }
            else if (dalParameter.Value is ushort)
            {
                dalParameter.DataType = DAL.Shared.DbType.UInt16;
            }
            else if (dalParameter.Value is short)
            {
                dalParameter.DataType = DAL.Shared.DbType.Int16;
            }
            else if (dalParameter.Value is char)
            {
                dalParameter.DataType = DAL.Shared.DbType.String;
                dalParameter.Size = 1;
            }
            else if (dalParameter.Value is TimeSpan)
            {
                dalParameter.DataType = DAL.Shared.DbType.Time;
            }
            else if (dalParameter.Value is byte)
            {
                dalParameter.DataType = DAL.Shared.DbType.Byte;
            }
            else if (dalParameter.Value is sbyte)
            {
                dalParameter.DataType = DAL.Shared.DbType.SByte;
            }
            else if (dalParameter.Value is double || dalParameter.Value is float)
            {
                dalParameter.DataType = DAL.Shared.DbType.Double;
            }
            else if (dalParameter.Value is decimal)
            {
                dalParameter.DataType = DAL.Shared.DbType.Decimal;
            }
            else if (dalParameter.Value is DateTime)
            {
                dalParameter.DataType = DAL.Shared.DbType.DateTime;
            }
            else if (dalParameter.Value is Guid)
            {
                dalParameter.DataType = DAL.Shared.DbType.Guid;
            }
            else if (dalParameter.Value is byte[] || dalParameter.Value is ICollection<byte>)
            {
                dalParameter.DataType = DAL.Shared.DbType.Binary;
            }
        }

        #region IDisposable Support

        /// <summary>
        ///    Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:13 PM</DateTime>
        /// </Created>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposedValue)
            {
                return;
            }

            if (disposing)
            {
                this.Tran?.Dispose();
                this.Cmd?.Dispose();
                this.Con?.Dispose();
            }

            this.disposedValue = true;
        }
        #endregion IDisposable Support
        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///    Gets the factory database connection.
        ///    <para>This method can be be overridden by the derived class to return an implementation object of the "<see cref="DbConnection"/>" that match the target provider factory.</para>
        /// </summary>
        /// <param name="provider">The data provider factory name of the type "<see cref="DataProviderFactory"/>".</param>
        /// <returns>An instance of a class that implements "<see cref="DbConnection"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:15 PM</DateTime>
        /// </Created>
        private DbProviderFactory GetDataProviderFactory(DataProviderFactory provider)
        {
            if (!this.Settings.CacheSettings.Disabled && this.MemoryCache?.DataProviderFactory != null)
            {
                return this.MemoryCache.DataProviderFactory;
            }

            ILogDetails error = null;
            try
            {
                var before = GC.GetTotalMemory(false);
                var providerDetails = provider.GetProviderFactoryDetails();
                var providerType = Type.GetType($"{providerDetails.FactoryClassName},{providerDetails.AssemblyName}");

#if NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0
                DbProviderFactories.RegisterFactory(providerDetails.Name, providerType);
#endif
                var factory = DbProviderFactories.GetFactory(providerDetails.Name);

                if (!this.Settings.CacheSettings.Disabled && this.MemoryCache != null)
                {
                    this.MemoryCache.DataProviderFactory = factory;
                    var after = GC.GetTotalMemory(false);
                    var size = after - before;

                    // 35400 bytes allocated by caching the data settings and the initial instance/container of the MemoryCached.
                    this.MemoryCache.FirstLevelCacheMemorySize += 35400 + size;
                }

                return factory;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.GetDataProviderFactory(DataProviderFactory provider)",
                    errorNumber: -200,
                    description: $"An Exception has been raised while attempting to get the Data Provider Factory '{provider}'!");
            }
            finally
            {
                this.HandleError(error);
            }

            return null;
        }

        /// <summary>
        ///    Initializes the connection.
        /// </summary>
        /// <returns><c>true</c> if connection has been initialized and the database command is being created successfully; otherwise else, <c>false</c> and no further commands/transactions can be executed.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>05/11/2018 11:47 AM</DateTime>
        /// </Created>
        private bool InitializeConnection()
        {
            ILogDetails error = null;

            if (string.IsNullOrWhiteSpace(this.Settings?.ConnectionSettings?.ConnectionString))
            {
                error = this.Settings.CreateErrorDetails(
                    source: "DAL.Command.InitializeConnection()",
                    errorNumber: -100,
                    stackTrace: Environment.StackTrace,
                    message: "Failed to initialize the connection with the data source.",
                    description: $"The connection string is either null or empty!");

                this.terminateFurtherExecutions = true;
                this.HandleError(error);
                return false;
            }

            this.Con = this.GetFactoryDbConnection(this.dataProviderFactory);

            if (this.Con == null)
            {
                this.terminateFurtherExecutions = true;
                return false;
            }

            try
            {
                this.Cmd = this.Con.CreateCommand();
                this.Cmd.CommandType = CommandType.StoredProcedure;
                if (this.Settings.ConnectionSettings.CommandTimeout.HasValue)
                {
                    this.Cmd.CommandTimeout = this.Settings.ConnectionSettings.CommandTimeout.Value;
                }

                this.Con.ConnectionString = this.Settings?.ConnectionSettings?.ConnectionString;
                this.Con.Open();
                var ok = this.Con.State == ConnectionState.Open;
                if (!ok)
                {
                    this.terminateFurtherExecutions = true;
                }

                return ok;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.InitializeConnection()",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to open the SQL connection with the database server '{this.Con?.DataSource}' and the database '{this.Con?.Database}' from the host host machine '{Environment.MachineName}'!");

                this.terminateFurtherExecutions = true;
                return false;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "DAL.Command.InitializeConnection()",
                    errorNumber: -202,
                    description: $"An Exception has been raised while attempting to open the SQL connection with the database server '{this.Con?.DataSource}' and the database '{this.Con?.Database}' from the host host machine '{Environment.MachineName}'!");

                this.terminateFurtherExecutions = true;
                return false;
            }
            finally
            {
                this.HandleError(error);
            }
        }

        /// <summary>
        ///    Gets the data from data reader which will be called by the "<see cref="ExecuteQuery{T}(string)"/>" overloads.
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <returns>The table result serialized into "<see cref="List{T}"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:20 PM</DateTime>
        /// </Created>
        private List<T> GetDataFromDataReader<T>()
        {
            var list = new List<T>();
            DbDataReader reader = null;
            ILogDetails error = null;

            try
            {
                bool ignoreNull = true;
                var type = typeof(T);
                var tableDetails = Shared.GetCustomAttribute<T, DataRowAttribute>();
                if (tableDetails != null)
                {
                    ignoreNull = tableDetails.IgnoreNullData;
                }

                var dataFields = Shared.GetDataFields<T>(this.Settings, this.MemoryCache, this.HandleError);

                reader = this.Cmd.ExecuteReader();
                this.dataExecutionSuccessful = true;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var obj = Activator.CreateInstance<T>();

                        foreach (var df in dataFields)
                        {
                            if (df.NotMapped || df.DataDirection == DataDirection.Outbound || df.DataDirection == DataDirection.None)
                            {
                                continue;
                            }
                            else if (reader[df.Name] is DBNull && (df.CanBeNull || ignoreNull))
                            {
                                continue;
                            }

                            var rawValue = reader[df.Name];
                            if (rawValue != null)
                            {
                                if (df.Encrypted || df.MayBeEncrypted)
                                {
                                    var nonDeterministic = df.EncryptionType == EncryptionType.Randomized || this.Settings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType == EncryptionType.Randomized;
                                    var cryptoResult = rawValue.ToString().DecryptSymmetric(this.Settings, nonDeterministic, this.MemoryCache);
                                    var value = cryptoResult.Value;
                                    if (value == null)
                                    {
                                        if (df.MayBeEncrypted)
                                        {
                                            rawValue = reader[df.Name];
                                            var outputError = cryptoResult.OutputError;
                                            outputError.LogLevel = LogLevel.Warning;
                                            outputError.Source = "DAL.Command.GetDataFromDataReader()";
                                            outputError.Description = $"Failed to decrypt the data for the data column '{reader[df.Name]}' which should be mapped with the property '{reader[df.Property.Name]}' with the flag 'MayBeEncrypted'.";
                                            this.HandleError(outputError);
                                        }
                                        else
                                        {
                                            var outputError = cryptoResult.OutputError;
                                            outputError.Source = "DAL.Command.GetDataFromDataReader()";
                                            outputError.Description = $"Failed to decrypt the data for the data column '{reader[df.Name]}' which should be mapped with the property '{reader[df.Property.Name]}'.";
                                            this.HandleError(outputError);
                                            return null;
                                        }
                                    }
                                    else
                                    {
                                        rawValue = value;
                                    }
                                }

                                switch (df.SpecialType)
                                {
                                    case SpecialType.Json:
                                        {
                                            rawValue = rawValue.ToString().FromJsonString(df.Property.PropertyType);
                                            break;
                                        }

                                    case SpecialType.Xml:
                                        {
                                            var value = rawValue.ToString().FromXmlString(df.Property.PropertyType);
                                            break;
                                        }

                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if (df.CanBeNull)
                                {
                                    continue;
                                }
                            }

                            if (df.Property.IsConcreteClass())
                            {
                                var subDataFields = rawValue.GetDataFieldList(this.Settings, this.MemoryCache, this.HandleError, Internal.CacheCategory.DataField);
                                rawValue.UpdateDataRowObject(subDataFields, SpecialType.None, DataDirection.Inbound, this.Settings, this.MemoryCache, this.HandleError);
                            }

                            df.Property.SetValue(obj, rawValue);
                        }

                        list.Add(obj);
                    }
                }

                return list;
            }
            catch (DbException ex)
            {
                error = this.Settings.CreateErrorDetails(
                    ex: ex,
                    source: "GetDataFromDataReader<T>()",
                    errorNumber: ex.ErrorCode,
                    description: $"DB Exception has been raised while attempting to fetch the data from the data reader by the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");

                return null;
            }
            catch (Exception ex)
            {
                error = this.Settings.CreateErrorDetails(
                     ex: ex,
                     source: "GetDataFromDataReader<T>()",
                     errorNumber: -303,
                     description: $"An Exception has been raised while attempting to fetch the data from the data reader by the sored procedure '{this.Cmd.CommandText}' from the database '{this.Con?.Database}' in the database server '{this.Con?.DataSource}' from the host web server '{Environment.MachineName}' and the current state of the connection is '{this.Con.State}'!");

                return null;
            }
            finally
            {
                reader?.Dispose();
                this.commandExecutionType = CommandExecutionType.ExecuteQuery;
                this.HandleError(error);
            }
        }

        /// <summary>
        ///    Updates the encapsulated parameters (array of "<see cref="DbParameter"/>") inside the <c>ADO.Net</c> "<see cref="DbCommand"/>" after a successful execution of the specified stored procedure.
        /// </summary>
        /// <param name="errorRaised">The result of the execution as error free or not. If set to <c>true</c>, the method will be terminated without raising exception.</param>
        /// <returns><c>true</c> if all the parameters updated successfully; otherwise else, false.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:25 PM</DateTime>
        /// </Created>
        private bool UpdateParameters(bool errorRaised = false)
        {
            if (this.Cmd.Parameters.Count == 0 || this.Parameters.Count == 0)
            {
                return true;
            }

            if (errorRaised || this.Errors.Count != 0)
            {
                return false;
            }

            foreach (DbParameter dbParameter in this.Cmd.Parameters)
            {
                if (dbParameter.Direction == ParameterDirection.ReturnValue || dbParameter.Direction == ParameterDirection.Output || dbParameter.Direction == ParameterDirection.InputOutput)
                {
                    var dalPar = this.Parameters.FirstOrDefault(p => p.Name == dbParameter.ParameterName);
                    var value = dbParameter.Value;

                    if (dalPar.Encrypted || dalPar.MayBeEncrypted)
                    {
                        var nonDeterministic = dalPar.EncryptionType == EncryptionType.Randomized || this.Settings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType == EncryptionType.Randomized;
                        var cryptoResult = value.ToString().DecryptSymmetric(this.Settings, nonDeterministic, this.MemoryCache);
                        if (cryptoResult.Value == null)
                        {
                            if (!dalPar.MayBeEncrypted)
                            {
                                var outputError = cryptoResult.OutputError;
                                outputError.Source = "DAL.Command.UpdateParameters()";
                                outputError.Description = $"Failed to decrypt the output data for the '{dbParameter.Direction}' parameter '{dbParameter.ParameterName}'.";
                                this.HandleError(outputError);
                                return false;
                            }
                        }
                        else
                        {
                            value = cryptoResult.Value;
                            var outputError = cryptoResult.OutputError;
                            outputError.LogLevel = LogLevel.Warning;
                            outputError.Source = "DAL.Command.UpdateParameters()";
                            outputError.Description = $"Failed to decrypt the output data for the '{dbParameter.Direction}' parameter '{dbParameter.ParameterName}' with the flag 'MayBeEncrypted'.";
                            this.HandleError(outputError);
                        }
                    }

                    dalPar.Value = value;
                }
            }

            return true;
        }

        /// <summary>
        ///    Updates the command body ("<see cref="ICommandBody"/>") with the result of the output and return parameters after executing the SQL command either it's executing query, executing command or executing scalar.
        /// </summary>
        /// <param name="commandBody">The request buddy which will be mainly the stored procedure name and the designated parameters of the type "<see cref="ICommandBody"/>".</param>
        /// <param name="errorRaised">The result of the execution as error free or not. If set to <c>true</c>, the method will be terminated without raising exception.</param>
        /// <returns><c>true</c> if all the parameters updated successfully; otherwise else, false.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:25 PM</DateTime>
        /// </Created>
        private bool UpdateCommandBody(ICommandBodyBase commandBody, bool errorRaised = false)
        {
            if (this.Cmd.Parameters.Count == 0 || this.Parameters.Count == 0)
            {
                return true;
            }

            if (errorRaised || this.Errors.Count != 0)
            {
                return false;
            }

            foreach (var parameter in this.Parameters)
            {
                var direction = (ParameterDirection)parameter.Direction;
                if (direction == ParameterDirection.Input)
                {
                    continue;
                }

                if (direction == ParameterDirection.ReturnValue || direction == ParameterDirection.Output || direction == ParameterDirection.InputOutput)
                {
                    var parameterAttribute = parameter.ParameterAttribute;

                    if (direction == ParameterDirection.ReturnValue)
                    {
                        parameterAttribute.Property.SetValue(commandBody, parameter.Value);
                        continue;
                    }

                    switch (parameterAttribute.SpecialType)
                    {
                        case SpecialType.Json:
                            {
                                var value = parameter.Value.ToString().FromJsonString(parameterAttribute.Property.PropertyType);
                                parameterAttribute.Property.SetValue(commandBody, value);
                                break;
                            }

                        case SpecialType.Xml:
                            {
                                var value = parameter.Value.ToString().FromXmlString(parameterAttribute.Property.PropertyType);
                                parameterAttribute.Property.SetValue(commandBody, value);
                                break;
                            }

                        case SpecialType.Structured:
                            {
                                var dataTable = parameter.Value.To<DataTable>();
                                using var stringWriter = new System.IO.StringWriter();
                                dataTable.WriteXml(stringWriter, false);
                                var xmlString = stringWriter.ToString();
                                var value = xmlString.FromXmlString(parameterAttribute.Property.PropertyType);
                                parameterAttribute.Property.SetValue(commandBody, value);

                                break;
                            }

                        case SpecialType.Binary:
                            {
                                if (parameterAttribute.Property.PropertyType == typeof(string))
                                {
                                    var value = Convert.ToBase64String((byte[])parameter.Value);
                                    parameterAttribute.Property.SetValue(commandBody, value);
                                }

                                break;
                            }

                        case SpecialType.Base64:
                            {
                                if (parameterAttribute.Property.PropertyType.IsGenericType && parameterAttribute.Property.PropertyType.GenericTypeArguments[0] == typeof(byte))
                                {
                                    var value = Convert.FromBase64String(parameter.Value.ToString());
                                    parameterAttribute.Property.SetValue(commandBody, value);
                                }

                                break;
                            }

                        default:
                            {
                                parameterAttribute.Property.SetValue(commandBody, parameter.Value);
                                break;
                            }
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///    Gets the database parameters as <see cref="List{T}"/> of <see cref="DbParameter"/>.
        /// </summary>
        /// <param name="parametersList">The parameters as <see cref="List{T}"/> of <see cref="IParameter"/>.</param>
        /// <returns>The database parameters as <see cref="List{T}"/> of <see cref="DbParameter"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:12 PM</DateTime>
        /// </Created>
        private List<DbParameter> GetDbParameters(List<IParameter> parametersList)
        {
            var list = new List<DbParameter>();
            foreach (var par in parametersList)
            {
                list.Add(this.GetDbParameter(par));
            }

            return list;
        }

        /// <summary>
        ///    Resets/clears both <c>DAL</c> parameters and the <c>ADO.Net command</c> parameters.
        /// </summary>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:00 PM</DateTime>
        /// </Created>
        private void ResetParameters(ICollection<IParameter> parameters)
        {
            this.ClearParameters();
            this.AddParameters(parameters);
        }

        /// <summary>
        ///   Update the error details with the addional data source and command details.
        /// </summary>
        /// <param name="error">The raised error/warning.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>17/02/2022 11:35 PM</DateTime>
        /// </Created>
        private void UpdateErrorDetails(ILogDetails error)
        {
            error.DatabaseName = this.GetCurrentDatabaseName();
            error.ConnectionState = this.Con?.State;
            error.DataSourceName = this.Con?.DataSource;
            error.DataSourceVersion = this.Con?.State == ConnectionState.Open ? this.Con?.ServerVersion : null;
            error.HasParameters = this.Parameters != null && this.Parameters.Count > 0;
            error.CommandText = this.Cmd?.CommandText;
            error.FirstLevelCacheMemorySize = this.FirstLevelCacheMemorySize;
            error.SecondLevelCacheMemorySize = this.SecondLevelCacheMemorySize;
            error.CommandExecutionType = this.commandExecutionType;
            error.CommandSource = this.commandSource;
            error.ParametersSource = this.parametersSource;
            error.IsolationLevel = this.isolationLevel;
            error.DataExecutionSuccessful = this.dataExecutionSuccessful;

            this.commandSource = null;
            this.commandExecutionType = null;
            this.parametersSource = null;
            this.isolationLevel = null;
            this.dataExecutionSuccessful = null;
        }
        #endregion Private Methods
    }
}

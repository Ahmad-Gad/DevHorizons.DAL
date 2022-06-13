// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommand.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Cache;

    /// <summary>
    ///    The <c>DAL</c> Command abstract class which holds all the required members and operations to access the database and <c>T-SQL</c> command executions.
    /// <para>This abstract class can be used for the <c>DI</c> (Dependency Injection) design pattern.</para>
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 10:25 PM</DateTime>
    /// </Created>
    public interface ICommand : IDisposable
    {
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

        /// <summary>
        ///    Occurs when [error raised].
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 11:13 AM</DateTime>
        /// </Created>
        event RaiseError ErrorRaised;

        /// <summary>
        ///    Occurs when [warning raised].
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>17/02/2022 11:13 PM</DateTime>
        /// </Created>
        event RaiseWarning WarningRaised;
        #endregion Event Handlers

        #region Properties

        /// <summary>
        ///    Gets the raised errors list.
        /// </summary>
        /// <value>
        ///    The raised errors.
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:39 PM</DateTime>
        /// </Created>
        List<ILogDetails> Errors { get; }

        /// <summary>
        ///    Gets the raised warnings list.
        /// </summary>
        /// <value>
        ///    The raised warnings.
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>18/02/2022 12:26 AM</DateTime>
        /// </Created>
        List<ILogDetails> Warnings { get; }

        /// <summary>
        ///    Gets the parameters.
        /// </summary>
        /// <value>
        ///    The parameters.
        /// </value>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>17/06/2019 02:28 PM</DateTime>
        /// </Created>
        List<IParameter> Parameters { get; }

        /// <summary>
        ///    Gets the allocated memory size (in bytes) for the first level cached objects.
        /// </summary>
        /// <remarks>This is only applicable if the "<see cref="CacheSettings.Disabled"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long FirstLevelCacheMemorySize { get; }

        /// <summary>
        ///    Gets the allocated memory size (in bytes) for the second level cached objects.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of the second level cache is set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="CacheSettings.Disabled"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long SecondLevelCacheMemorySize { get; }

        /// <summary>
        ///    Gets the total allocated memory size (in bytes) for all the levels of cache combined together.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of both the second and the third level cache are set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="CacheSettings.Disabled"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long TotalCacheMemorySize { get; }
        #endregion Properties

        #region Methods
        #region Operation Methods

        /// <summary>
        ///    Performs a full health check against the whole "<c>DAL</c>" service including the opened connection and all the relative initializes resources and return.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is fully successfully initialized can execute commands/queries; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:29 PM</DateTime>
        /// </Created>
        bool CanExecute();

        /// <summary>
        ///    Gets the name of the current database.
        /// </summary>
        /// <returns>The current connected database name.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>05/11/2018 11:07 AM</DateTime>
        /// </Created>
        string GetCurrentDatabaseName();

        /// <summary>
        ///    Changes the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns><c>true</c> if the database connection has been changed to the specified one, otherwise, <c>false</c>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:51 PM</DateTime>
        /// </Created>
        bool ChangeDatabase(string database);

        /// <summary>
        ///    Changes the current connection string.
        /// </summary>
        /// <param name="connectionString">The database.</param>
        /// <returns><c>true</c> if the connection string has been changed to the specified one, otherwise, <c>false</c>.</returns>
        /// <param name="updateConnectionString">If <c>true</c>, updates the connection string with all the connection settings related to the connection string in the "<see cref="ConnectionSettings"/>" class.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 05:51 PM</DateTime>
        /// </Created>
        bool ChangeConnectionString(string connectionString, bool updateConnectionString = false);

        /// <summary>
        ///    Clears the errors list.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/11/2018 09:48 PM</DateTime>
        /// </Created>
        void ClearErrors();

        /// <summary>
        ///    Clears the warnings list.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>18/02/2022 12:26 AM</DateTime>
        /// </Created>
        void ClearWarnings();

        /// <summary>
        ///    Adds the parameter as an instance of a class that implements "<see cref="IParameter"/>" to the existing list of parameters.
        /// </summary>
        /// <param name="parameter">The parameter as an instance of a class that implements "<see cref="IParameter"/>".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>13/11/2018 12:01 PM</DateTime>
        /// </Created>
        void AddParameter(IParameter parameter);

        /// <summary>
        ///    Adds the parameters from a collection of "<see cref="IParameter"/>".
        /// </summary>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <param name="reset">Default value is <c>false</c>. If set to <c>true</c>, all the parameters will be cleared first before adding the new specified ones, otherwise, it will append the specified parameters to the existing list.</param>
        /// <remarks>The "reset" argument will not reset the existing errors. If you want to reset all the errors, you need to call the "<see cref="ClearErrors"/>" void method as well.</remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/11/2018 12:01 PM</DateTime>
        /// </Created>
        void AddParameters(ICollection<IParameter> parameters, bool reset = false);

        /// <summary>
        ///    Adds the parameters from a <c>params</c> array of <see cref="IParameter"/>.
        /// </summary>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/11/2018 12:01 PM</DateTime>
        /// </Created>
        void AddParameters(params IParameter[] parameters);

        /// <summary>
        ///    Adds the parameters from a dictionary.
        /// </summary>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <param name="reset">Default value is <c>false</c>. If set to <c>true</c>, all the parameters will be cleared first before adding the new specified ones, otherwise, it will append the specified parameters to the existing list.</param>
        /// <remarks>The "reset" argument will not reset the existing errors. If you want to reset all the errors, you need to call the "<see cref="ClearErrors"/>" void method as well.</remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/06/2022 08:00 PM</DateTime>
        /// </Created>
        void AddParameters(IEnumerable<KeyValuePair<string, object>> parameters, bool reset = false);

        /// <summary>
        ///    Clears the parameters.
        /// </summary>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/11/2018 12:01 PM</DateTime>
        /// </Created>
        void ClearParameters();

        /// <summary>
        ///    Reset the whole encapsulated engine command's data/settings/properties including the encapsulated data parameters, commands and the opened transactions. Furthermore, clears all the raised errors and warnings.
        /// </summary>
        /// <remarks>
        ///    If a transaction is being initiated/opened, it will be rolled back and reset as well, and you get to manually reinitiate it again.
        /// </remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        void Reset();

        /// <summary>
        ///   Performs the full reset (calling the method "<see cref="Reset()"/>") plus resetting the whole connection and initiate it regardless the current connection state.
        /// </summary>
        /// <param name="updateConnectionString">If <c>true</c>, updates the connection string with all the connection settings related to the connection string in the "<see cref="ConnectionSettings"/>" class.</param>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool ResetHard(bool updateConnectionString);

        /// <summary>
        ///   Reset the current command engine based on the specified reset mode.
        /// </summary>
        /// <param name="resetMode">
        ///    Specify the reset modes/options.
        ///    <para>Supports the enum flags with multiple options combinations.</para>
        /// </param>
        /// <remarks>
        ///    This method's overload provides full control over the reset modes/options.
        ///    <para>If you target the "<see cref="ResetMode.Full"/>", it is better to call the parameterless "<see cref="Reset()"/>" overload which will do the same with less computing cost which is required for extra validations.</para>
        ///    <para>If you target the "<see cref="ResetMode.Hard"/>" or "<see cref="ResetMode.HardRefresh"/>", it is better to call the "<see cref="ResetHard(bool)"/>" method which will do the same with less computing cost which is required for extra validations.</para>
        /// </remarks>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool Reset(ResetMode resetMode);

        /// <summary>
        ///    Starts a database transaction with the default isolation level set by the target database server.
        /// </summary>
        /// <remarks>
        ///    This operation will trigger the command reset by executing the "<see cref="Reset()"/>" without the hard reset mode.
        ///    <para>If the transaction fails to start, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.</para>
        /// </remarks>
        /// <seealso cref="Reset()"/>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool BeginTransaction();

        /// <summary>
        ///    Starts a database transaction with the specified isolation level (locking behavior for the connection).
        /// </summary>
        /// <remarks>If the transaction fails to start, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.</remarks>
        /// <param name="isolationLevel">The specified isolation level (locking behavior for the connection).</param>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        ///    Commit the current opened transaction and dispose it.
        /// </summary>
        /// <param name="forceCommit">
        ///    If <c>true</c> it will ignore any raised error from the advance executed queries/command. Otherwise else, If error or more being raised by any command/query execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>").
        ///    <para>This should not be set to "<c>true</c>" because it may lead to data inconsetancy, unless you intend/plan to handle the raised errors manually with a proper way. Otherwise else, always set it to <c>false</c>.</para>
        /// </param>
        /// <param name="autoRollback">If <c>true</c> and the commit failed, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>").</param>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <remarks>If the transaction fails to start, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.</remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool CommitTransaction(bool forceCommit, bool autoRollback);

        /// <summary>
        ///    Commit the current opened transaction and dispose it.
        /// </summary>
        /// <param name="autoRollback">If <c>true</c> and the commit failed, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>").</param>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any command/query execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>").</para>
        /// </remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool CommitTransaction(bool autoRollback);

        /// <summary>
        ///    Commit the current opened transaction and dispose it. If the commit operation failed, the auto rollback will be executed ("<see cref="RollbackTransaction(bool)"/>").
        /// </summary>
        /// <returns><c>true</c> if the transaction has been started successfully, otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any command/query execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction(bool)"/>").</para>
        ///     <para>If you need more control, consider looking at the other overloads of this method.</para>
        /// </remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool CommitTransaction();

        /// <summary>
        ///    Rollback the current opened transaction and dispose it.
        /// </summary>
        /// <param name="silent">Default value is <c>false</c>. If set to true, it will validate for an existing opened transaction to rollback without raising any error if no valid opened transaction found.</param>
        /// <returns><c>true</c> if the transaction was already/originally initiated/opened successfully and has been rolled back successfully, otherwise, <c>false</c>.</returns>
        /// <remarks>When executed (either the rollback operation is a success or failure), the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.</remarks>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>12/02/2022 01:42 PM</DateTime>
        /// </Created>
        bool RollbackTransaction(bool silent = false);

        /// <summary>
        ///    Rollback, clear and dispose the existing transaction if found and begin a new/fresh one.
        /// </summary>
        /// <returns>
        ///    <returns><c>true</c> if the whole reset operation is completed successfully, otherwise, <c>false</c>.</returns>
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/06/2022 10:03 PM</DateTime>
        /// </Created>
        bool ResetTransaction();

        /// <summary>
        ///    Rollback, clear and dispose the existing transaction if found and begin a new/fresh one.
        /// </summary>
        /// <param name="isolationLevel">The specified isolation level (locking behavior for the connection).</param>
        /// <returns>
        ///    <returns><c>true</c> if the whole reset operation is completed successfully, otherwise, <c>false</c>.</returns>
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>13/06/2022 10:03 PM</DateTime>
        /// </Created>
        bool ResetTransaction(IsolationLevel isolationLevel);
        #endregion Operation Methods

        #region DAO Methods
        #region Execute Query

        /// <summary>
        ///    Executes the "<c>DAL</c>" command to return the table result serialized into "<see cref="List{T}"/> after extracting the designated stored procedure name and the required parameters (if exist) from the specified instance "<see cref="ICommandBody"/>" body.
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <param name="commandBody">The <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.</param>
        /// <returns>The table result serialized into "<see cref="List{T}"/>". If "<c>Null</c>", that means the operation failed and error(s) will be raised.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        List<T> ExecuteQuery<T>(ICommandBody commandBody);

        /// <summary>
        ///    Executes the specified stored procedure to return the table result serialized into "<see cref="List{T}"/>".
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <returns>The table result serialized into "<see cref="List{T}"/>". If "<c>Null</c>", that means the operation failed and error(s) will be raised.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:54 PM</DateTime>
        /// </Created>
        List<T> ExecuteQuery<T>(string proc);

        /// <summary>
        ///    Executes the specified stored procedure to return the table result serialized into "<see cref="List{T}"/>".
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <returns>The table result serialized into "<see cref="List{T}"/>". If "<c>Null</c>", that means the operation failed and error(s) will be raised.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:55 PM</DateTime>
        /// </Created>
        List<T> ExecuteQuery<T>(string proc, ICollection<IParameter> parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return the table result serialized into "<see cref="List{T}"/>".
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <returns>The table result serialized into "<see cref="List{T}"/>". If "<c>Null</c>", that means the operation failed and error(s) will be raised.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:55 PM</DateTime>
        /// </Created>
        List<T> ExecuteQuery<T>(string proc, params IParameter[] parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return the table result serialized into "<see cref="List{T}"/>".
        ///    <para>The specified parameters will be automatically converted to "<see cref="List{T}"/>" (where <c>T</c> is <see cref="IParameter"/>).</para>
        ///    <para>For the best performance results, it's strongly preferred to use the other overloads which expects <see cref="ICollection{T}"/> or array of <see cref="IParameter"/>.</para>
        /// </summary>
        /// <typeparam name="T">The declaration type of the generic return object collection.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns>The table result serialized into "<see cref="List{T}"/>". If "<c>Null</c>", that means the operation failed and error(s) will be raised.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:55 PM</DateTime>
        /// </Created>
        List<T> ExecuteQuery<T>(string proc, IEnumerable<KeyValuePair<string, object>> parameters);
        #endregion Execute Query

        #region Execute Scalar
        #region Object

        /// <summary>
        ///    Executes the "<c>DAL</c>" command to return a scalar value only after extracting the designated stored procedure name and the required parameters (if exist) from the specified instance "<see cref="ICommandBody"/>" body.
        /// </summary>
        /// <param name="commandBody">The <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.</param>
        /// <returns>The scalar value. "<c>Null</c>", value may refer to raised error/exception.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        object ExecuteScalar(ICommandBody commandBody);

        /// <summary>
        ///    Executes the specified stored procedure to return a scalar value only.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <returns>The scalar value. "<c>Null</c>", value may refer to raised error/exception.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:35 PM</DateTime>
        /// </Created>
        object ExecuteScalar(string proc);

        /// <summary>
        ///    Executes the specified stored procedure to return a scalar value only.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <returns>The scalar value. "<c>Null</c>", value may refer to raised error/exception.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:36 PM</DateTime>
        /// </Created>
        object ExecuteScalar(string proc, ICollection<IParameter> parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return a scalar value only.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <returns>The scalar value. "<c>Null</c>", value may refer to raised error/exception.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:37 PM</DateTime>
        /// </Created>
        object ExecuteScalar(string proc, params IParameter[] parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return a scalar value only.
        ///    <para>The specified parameters will be automatically converted to "<see cref="List{T}"/>" (where <c>T</c> is <see cref="IParameter"/>).</para>
        ///    <para>For the best performance results, it's strongly preferred to use the other overloads which expects <see cref="ICollection{T}"/> or array of <see cref="IParameter"/>.</para>
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns>The scalar value. "<c>Null</c>", value may refer to raised error/exception.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:37 PM</DateTime>
        /// </Created>
        object ExecuteScalar(string proc, IEnumerable<KeyValuePair<string, object>> parameters);
        #endregion Object

        #region Generic

        /// <summary>
        ///    Executes the "<c>DAL</c>" command to return a scalar value only after extracting the designated stored procedure name and the required parameters (if exist) from the specified instance "<see cref="ICommandBody"/>" body.
        /// </summary>
        /// <typeparam name="T">The type of the generic scalar value.</typeparam>
        /// <param name="commandBody">The <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.</param>
        /// <returns>The scalar value converted automaticall to the specified generic type.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        T ExecuteScalar<T>(ICommandBody commandBody);

        /// <summary>
        ///    Executes the specified stored procedure to return a generic scalar value.
        /// </summary>
        /// <typeparam name="T">The type of the generic scalar value.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <returns>The scalar value.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:53 PM</DateTime>
        /// </Created>
        T ExecuteScalar<T>(string proc);

        /// <summary>
        ///    Executes the specified stored procedure to return a generic scalar value.
        /// </summary>
        /// <typeparam name="T">The type of the generic scalar value.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <returns>The generic scalar value.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:53 PM</DateTime>
        /// </Created>
        T ExecuteScalar<T>(string proc, ICollection<IParameter> parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return a generic scalar value.
        /// </summary>
        /// <typeparam name="T">The type of the generic scalar value.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <returns>The generic scalar value.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:53 PM</DateTime>
        /// </Created>
        T ExecuteScalar<T>(string proc, params IParameter[] parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return a generic scalar value.
        ///    <para>The specified parameters will be automatically converted to "<see cref="List{T}"/>" (where <c>T</c> is <see cref="IParameter"/>).</para>
        ///    <para>For the best performance results, it's strongly preferred to use the other overloads which expects <see cref="ICollection{T}"/> or array of <see cref="IParameter"/>.</para>
        /// </summary>
        /// <typeparam name="T">The type of the generic scalar value.</typeparam>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns>The generic scalar value.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:46 PM</DateTime>
        /// </Created>
        T ExecuteScalar<T>(string proc, IEnumerable<KeyValuePair<string, object>> parameters);
        #endregion Generic
        #endregion Execute Scalar

        #region Execute Command

        /// <summary>
        ///    Executes "<c>DML SQL</c>" command and return the successful state as boolean result after populating the return/output values if applicable.
        /// </summary>
        /// <param name="dataTable">The <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.</param>
        /// <param name="commandAction">The specified "<c>DML SQL</c>" command to be executed as "Insert", "Delete" or "Update".</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///    The "<see cref="CommandAction.Select"/>" is not supported because it expects a "<c>DML</c>" command not a "<c>DQL</c>" one.
        ///    <para>Neither "<see cref="CommandAction.None"/>" not "<see cref="CommandAction.All"/>" are acceptable. If aeither is specified, the method will be terminated with error as unsupported command/action.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>06/03/2022 02:22 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(IDataTable dataTable, CommandAction commandAction);

        /// <summary>
        ///    Executes the "<c>DAL</c>" command to return the successful state as boolean result after extracting the designated stored procedure name and the required parameters (if exist) from the specified instance "<see cref="ICommandBody"/>" body.
        /// </summary>
        /// <param name="commandBody">The <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(ICommandBody commandBody);

        /// <summary>
        ///    Executes all the specified commands within an opened transaction (for the same opened/shared connection) with the default isolation level set by the target database server.
        /// </summary>
        /// <param name="commandBodyList">The "<see cref="List{ICommandBody}"/>" where "<c>T</c>" is type of "<see cref="ICommandBody"/>".</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start/begin, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any of the lised/specified commands execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>"), and whole operation will be immediatly rerminated before executing the rest of the commands as a safe measurement to avoid wasting unnessary further computing resources.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteTranCommands(ICollection<ICommandBody> commandBodyList);

        /// <summary>
        ///    Executes all the specified commands within an opened transaction (for the same opened/shared connection) with the default isolation level set by the target database server.
        /// </summary>
        /// <param name="commandBody">The <c>params</c> array of the "<see cref="ICommandBody"/>".</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start/begin, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any of the lised/specified commands execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>"), and whole operation will be immediatly rerminated before executing the rest of the commands as a safe measurement to avoid wasting unnessary further computing resources.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteTranCommands(params ICommandBody[] commandBody);

        /// <summary>
        ///    Executes all the specified commands within an opened transaction (for the same opened/shared connection) with the default isolation level set by the target database server.
        /// </summary>
        /// <param name="isolationLevel">The specified isolation level (locking behavior for the connection).</param>
        /// <param name="commandBody">The <c>params</c> array of the "<see cref="ICommandBody"/>".</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start/begin, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any of the lised/specified commands execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>"), and whole operation will be immediatly rerminated before executing the rest of the commands as a safe measurement to avoid wasting unnessary further computing resources.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteTranCommands(DAL.IsolationLevel isolationLevel, params ICommandBody[] commandBody);

        /// <summary>
        ///    Executes all the specified commands within an opened transaction (for the same opened/shared connection) with the default isolation level set by the target database server.
        /// </summary>
        /// <param name="commandBodyList">The "<see cref="List{ICommandBody}"/>" where "<c>T</c>" is type of "<see cref="ICommandBody"/>".</param>
        /// <param name="isolationLevel">The specified isolation level (locking behavior for the connection).</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///     If the transaction fails to start/begin, or failed to be commited, the current transaction will be disposed, furthermore, the whole "<c>DAL</c>" service will be susbended from executing any further commands/transactions until the reset operation is being executed by calling the "<see cref="Reset()"/>" method.
        ///     <para>If error or more being raised by any of the lised/specified commands execution after the transaction being started, the auto rollback will be executed ("<see cref="RollbackTransaction()"/>"), and whole operation will be immediatly rerminated before executing the rest of the commands as a safe measurement to avoid wasting unnessary further computing resources.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteTranCommands(ICollection<ICommandBody> commandBodyList, DAL.IsolationLevel isolationLevel);

        /// <summary>
        ///    Executes the specified stored procedure to return the successful state as boolean result.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:35 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(string proc);

        /// <summary>
        ///    Executes the specified stored procedure to return the successful state as boolean result.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="ICollection{T}"/> of <see cref="IParameter"/>.</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:50 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(string proc, ICollection<IParameter> parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return the successful state as boolean result.
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <c>params</c> array of <see cref="IParameter"/>.</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:50 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(string proc, params IParameter[] parameters);

        /// <summary>
        ///    Executes the specified stored procedure to return the successful state as boolean result.
        ///    <para>The specified parameters will be automatically converted to "<see cref="List{T}"/>" (where <c>T</c> is <see cref="IParameter"/>).</para>
        ///    <para>For the best performance results, it's strongly preferred to use the other overloads which expects <see cref="ICollection{T}"/> or array of <see cref="IParameter"/>.</para>
        /// </summary>
        /// <param name="proc">The stored procedure name.</param>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns><c>true</c> if the command has been executed successfully with errors free; otherwise else, <c>false</c>.</returns>
        /// <remarks>
        ///    The specified parameters will be appended to the existing list of parameters which could be added explicitly beforehand through any of the following methods:
        ///    <para><see cref="AddParameter(IParameter)"/></para>
        ///    <para><see cref="AddParameters(ICollection{IParameter}, bool)"/></para>
        ///    <para><see cref="AddParameters(IParameter[])"/></para>
        ///    <para><see cref="AddParameters(IEnumerable{KeyValuePair{string, object}}, bool)"/></para>
        ///    You can call the "<see cref="ClearParameters"/>" method in advance to clear all the existing parameters if required.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 10:47 PM</DateTime>
        /// </Created>
        bool ExecuteCommand(string proc, IEnumerable<KeyValuePair<string, object>> parameters);
        #endregion Execute Command
        #endregion DAO Methods
        #endregion Methods
    }
}

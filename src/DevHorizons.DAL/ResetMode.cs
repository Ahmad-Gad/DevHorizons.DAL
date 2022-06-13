// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResetMode.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the reset modes/options/actions for the command engine.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>13/06/2022 07:27 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;
    using System.ComponentModel;

    /// <summary>
    ///    The reset modes/options/actions for the command engine.
    /// </summary>
    /// <remarks>
    ///    Supports the enum flags with multiple options combinations.
    ///    <para>The Default value is "<see cref="Full"/>".</para>
    /// </remarks>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>13/06/2022 07:27 PM</DateTime>
    /// </Created>
    [Flags]
    [DefaultValue(Full)]
    public enum ResetMode
    {
        /// <summary>
        ///    No action will be performed.
        /// </summary>
        None = 0,

        /// <summary>
        ///    Clear all the added parameters.
        /// </summary>
        ResetParameters = 1,

        /// <summary>
        ///    Clear the command text. E.g. Stored procudre name.
        /// </summary>
        ResetCommandName = ResetParameters << 1,

        /// <summary>
        ///    Clear all the raised warnings.
        /// </summary>
        ResetWarnings = ResetCommandName << 1,

        /// <summary>
        ///    Clear all the raised errors.
        /// </summary>
        ResetErrors = ResetWarnings << 1,

        /// <summary>
        ///    Clear the initiated/opened transaction(s).
        /// </summary>
        ResetTransaction = ResetErrors << 1,

        /// <summary>
        ///    Will apply full soft reset (clear transactions, command name, parameters and raised errors) while keeping the current connection state intact.
        ///    <para>Will imply/apply <see cref="ResetParameters"/>, <see cref="ResetErrors"/>, <see cref="ResetCommandName"/> and <see cref="ResetTransaction"/>.</para>
        ///    <para>The default value (action/mode).</para>
        /// </summary>
        Full = ResetParameters | ResetCommandName | ResetWarnings | ResetErrors | ResetTransaction,

        /// <summary>
        ///    Perform the HARD reset which will reset/clear everything, kill the current connection, dispose all the initiated objects and open new connection.
        ///    <para>Will imply/apply <see cref="Full"/>.</para>
        /// </summary>
        Hard = Full | Full << 1,

        /// <summary>
        ///    Will imply/apply full the HARD reset ("<see cref="Hard"/>") and then updates/refreshes the connection string with all the connection settings related to the connection string in the "<see cref="ConnectionSettings"/>" class.
        /// </summary>
        HardRefresh = Hard | Hard << 1
    }
}

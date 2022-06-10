// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommandExecutionType.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the execution type/behaviour of a command.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System.ComponentModel;

    /// <summary>
    ///   The execution type/behaviour of a command.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>12/02/2022 04:58 PM</DateTime>
    /// </Created>
    [DefaultValue(Unkown)]
    public enum CommandExecutionType
    {
        /// <summary>
        ///    Unkown/Unspecified execution type.
        /// </summary>
        Unkown = 0,

        /// <summary>
        ///    Expects for the command to execute whatever it holds without expecting to return anything except for the provided return/output parameters.
        /// </summary>
        ExecuteCommand = 1,

        /// <summary>
        ///    Expects for the executed command/query to return a/scalar value.
        /// </summary>
        ExecuteScalar = 2,

        /// <summary>
        ///    Expects for the executed command/query to return set of records.
        /// </summary>
        ExecuteQuery = 3,

        /// <summary>
        ///    Execute collection of commands within a transaction.
        /// </summary>
        ExecuteTranCommands = 4
    }
}

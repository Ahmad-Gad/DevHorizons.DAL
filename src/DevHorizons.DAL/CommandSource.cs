// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommandSource.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the definition source of the command (stored procedure) name.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    /// <summary>
    ///   The definition source of the command (stored procedure) name.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>12/02/2022 04:58 PM</DateTime>
    /// </Created>
    public enum CommandSource
    {
        /// <summary>
        ///   The command (stored procedure) name explicitly defined as parameter in the targeted command execution method.
        /// </summary>
        Explicit = 1,

        /// <summary>
        ///    The command (stored procedure) name extracted from the "<see cref="Interfaces.ICommandBody"/>" implemented instance.
        /// </summary>
        CommandBody = 2,

        /// <summary>
        ///    The command text is extracted from the "<see cref="Interfaces.IDataTable"/>" implemented instance as a clear "<c>SQL</c>" command text.
        /// </summary>
        DataTable = 3,
    }
}

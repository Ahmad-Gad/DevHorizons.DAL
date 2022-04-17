// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ParametersSource.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    The definition source of the required parameters for the specified command (stored procedure)
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    /// <summary>
    ///   The definition source of the required parameters for the specified command (stored procedure).
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>12/02/2022 04:58 PM</DateTime>
    /// </Created>
    public enum ParametersSource
    {
        /// <summary>
        ///    No parameters specified.
        /// </summary>
        None,

        /// <summary>
        ///    Explicitly defined one or more of "<see cref="Interfaces.IParameter"/>".
        /// </summary>
        Explicit = 1,

        /// <summary>
        ///    Explicitly defined by providing a generic dictionary as <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>..
        /// </summary>
        Dictionary = 2,

        /// <summary>
        ///    The parameters extracted from the "<see cref="Interfaces.ICommandBody"/>" implemented instance.
        /// </summary>
        CommandBody = 3
    }
}

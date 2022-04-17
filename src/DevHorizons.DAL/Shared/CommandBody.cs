// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandBody.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the needed members for the <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>02/02/2021 05:40 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    using Attributes;
    using Interfaces;

    /// <summary>
    ///    Defines all the needed members for the <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>02/02/2021 05:40 PM</DateTime>
    /// </Created>
    public class CommandBody : ICommandBody
    {
        /// <inheritdoc/>
        [Parameter(NotMapped = true)]
        public string CommandName { get; set; }

        /// <inheritdoc/>
        [Parameter(Name = nameof(ICommandBody), Direction = Direction.ReturnValue)]
        public int ReturnValue { get; set; }
    }
}

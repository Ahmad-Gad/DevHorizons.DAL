// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandBody.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Interfaces
{
    /// <summary>
    ///    Defines all the needed members for the <c>DAL</c> request buddy which will be mainly the stored procedure name and the designated parameters.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>02/02/2021 05:40 PM</DateTime>
    /// </Created>
    public interface ICommandBody : ICommandBodyBase
    {
        /// <summary>
        ///    Gets or sets the stored Procedure name including the schema name. <c>E.g. [dbo].[GetSalesData]</c>.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/02/2021 05:40 PM</DateTime>
        /// </Created>
        string CommandName { get; set; }

        /// <summary>
        ///    Gets or sets the numeric integer value returned by the stored procedure using the <c>return</c> clause inside the stored procedure body definition.
        /// </summary>
        /// <remarks>This property is totally managed/controlled by the engine internally. Please don't try to override it with anyway or even override the assigned attribute or add any additional attributes.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>02/02/2021 05:40 PM</DateTime>
        /// </Created>
        int ReturnValue { get; set; }
    }
}

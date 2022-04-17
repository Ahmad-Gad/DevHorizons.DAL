// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Direction.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    using System.Data;

    /// <summary>
    ///    The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:11 AM</DateTime>
    /// </Created>
    public enum Direction
    {
        /// <summary>
        ///    Input direction. Would be used to pass input value to the Stored Procedure.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:05 AM</DateTime>
        /// </Created>
        Input = ParameterDirection.Input,

        /// <summary>
        ///    Output direction. Would be used to return values from the Stored Procedure.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:05 AM</DateTime>
        /// </Created>
        Output = ParameterDirection.Output,

        /// <summary>
        ///   Input or Output direction. Parameter in which would be able to act as both input and output direction to hold data/value for the whole round trip of the command execution.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:05 AM</DateTime>
        /// </Created>
        InputOutput = ParameterDirection.InputOutput,

        /// <summary>
        ///    The returned value from Stored Procedure. This parameter must be ONLY an INTEGER type!
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:05 AM</DateTime>
        /// </Created>
        ReturnValue = ParameterDirection.ReturnValue,
    }
}

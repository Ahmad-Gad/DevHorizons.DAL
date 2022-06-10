// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDataField.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the required data field/parameter members.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Interfaces
{
    using System.Reflection;
    using Cryptography;
    using Shared;

    /// <summary>
    ///    A type which would represent the data field/parameter.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:00 AM</DateTime>
    /// </Created>
    /// <seealso cref="IDataFieldBase" />
    public interface IDataField : IDataFieldBase
    {
        #region Properties
        /// <summary>
        ///    Gets the bound/mapped property as an instance of "<see cref="PropertyInfo"/>".
        /// </summary>
        /// <remarks>
        ///    This value is totally managed by the engine and designed to serve the library internally only.
        /// </remarks>
        /// <value>
        ///    The mapped property as an instance of "<see cref="PropertyInfo"/>".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        PropertyInfo Property { get; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Sets the bound/mapped property as an instance of "<see cref="PropertyInfo"/>".
        /// </summary>
        /// <remarks>
        ///    This method is totally managed by the engine and designed to serve the library internally only.
        /// </remarks>
        /// <param name="property">The bound/mapped property as an instance of "<see cref="PropertyInfo"/>".</param>|
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>06/05/2022 04:41 PM</DateTime>
        /// </Created>
        void SetPropertyInfo(PropertyInfo property);
        #endregion Methods
    }
}

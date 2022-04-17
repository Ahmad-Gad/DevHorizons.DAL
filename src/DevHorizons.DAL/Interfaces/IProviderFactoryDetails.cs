// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IProviderFactoryDetails.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the required data for the data provider factory details.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Interfaces
{
    /// <summary>
    ///    An interface that defines all the required data provider factory details to implement the data connection factory for the target provider.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 12:30 PM</DateTime>
    /// </Created>
    public interface IProviderFactoryDetails
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the provider friendly name. This name should be unique for the provider and express the actual name of the provider factory.
        /// </summary>
        /// <value>
        ///    The provider friendly name. This name should be unique for the provider and express the actual name of the provider factory.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:31 PM</DateTime>
        /// </Created>
        string Name { get; set; }

        /// <summary>
        ///    Gets or sets the actual factory class name e.g. "Microsoft.Data.SqlClient.SqlClientFactory".
        /// </summary>
        /// <value>
        ///    The actual factory class name e.g. "Microsoft.Data.SqlClient.SqlClientFactory".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:32 PM</DateTime>
        /// </Created>
        string FactoryClassName { get; set; }

        /// <summary>
        ///    Gets or sets the actual assembly fully qualified name which hosts the provider e.g. "Microsoft.Data.SqlClient".
        /// </summary>
        /// <value>
        ///    The actual assembly fully qualified name which hosts the provider e.g. "Microsoft.Data.SqlClient".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:33 PM</DateTime>
        /// </Created>
        string AssemblyName { get; set; }
        #endregion Properties
    }
}

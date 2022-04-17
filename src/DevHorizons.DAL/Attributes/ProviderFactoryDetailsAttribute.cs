// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ProviderFactoryDetailsAttribute.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Attributes
{
    using System;
    using Interfaces;

    /// <summary>
    ///    An attribute class that defines all the required data provider factory details to implement the data connection factory for the target provider.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="DevHorizons.DAL.Interfaces.IProviderFactoryDetails" />
    /// <Created>
    ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///   <DateTime>11/02/2020 12:30 PM</DateTime>
    /// </Created>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ProviderFactoryDetailsAttribute : Attribute, IProviderFactoryDetails
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ProviderFactoryDetailsAttribute"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:36 PM</DateTime>
        /// </Created>
        public ProviderFactoryDetailsAttribute()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="ProviderFactoryDetailsAttribute"/> class.
        /// </summary>
        /// <param name="name">The provider friendly name. This name should be unique for the provider and express the actual name of the provider factory.</param>
        /// <param name="factoryClassName">The actual factory class name e.g. "Microsoft.Data.SqlClient.SqlClientFactory".</param>
        /// <param name="assemblyName">The actual assembly fully qualified name which hosts the provider e.g. "Microsoft.Data.SqlClient".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:36 PM</DateTime>
        /// </Created>
        public ProviderFactoryDetailsAttribute(string name, string factoryClassName, string assemblyName)
        {
            this.Name = name;
            this.FactoryClassName = factoryClassName;
            this.AssemblyName = assemblyName;
        }
        #endregion Constructors

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
        public string Name { get; set; }

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
        public string FactoryClassName { get; set; }

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
        public string AssemblyName { get; set; }
        #endregion Properties
    }
}

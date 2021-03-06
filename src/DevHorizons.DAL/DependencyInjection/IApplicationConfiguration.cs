// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationConfiguration.cs" company="Retail inMotion Corp">
//    Copyright (c) Retail inMotion Corp. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the required members to have the application configuration implementation in a typed format.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
//    <DateTime>23/04/2021 12:41 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.DependencyInjection
{
    using Interfaces;

    /// <summary>
    ///    The application configuration abstract in a typed format.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
    ///    <DateTime>27/04/2021 01:11 PM</DateTime>
    /// </Created>
    public interface IApplicationConfiguration
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the name of the running host deployed/running application. This property is automatically set by the host to the assembly containing the application entry point.
        /// </summary>
        /// <value>
        ///    The name of the host application.
        /// </value>
        string AppName { get; set; }

        /// <summary>
        ///    Gets or sets the deployed/running host application version.
        /// </summary>
        /// <value>
        ///    The host application version.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:09 PM</DateTime>
        /// </Created>
        string AppVersion { get; set; }

        /// <summary>
        ///    Gets or sets the all the ("<c>DAL</c>") data access settings required to connect to the data source and to control the engine.
        /// </summary>
        /// <value>
        ///    The data access settings.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:11 PM</DateTime>
        /// </Created>
        IDataAccessSettings DataAccessSettings { get; set; }
        #endregion Properties
    }
}

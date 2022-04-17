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
namespace DevHorizons.DAL.WebApi.Interfaces
{
    using Configuration;
    using Sql;

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
        ///    Gets or sets the name of the application. This property is automatically set by the host to the assembly containing the application entry point.
        /// </summary>
        /// <value>
        ///    The name of the application.
        /// </value>
        string ApplicationName { get; set; }

        /// <summary>
        ///    Gets or sets the deploy API version.
        /// </summary>
        /// <value>
        ///    The API version.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:09 PM</DateTime>
        /// </Created>
        string ApiVersion { get; set; }

        /// <summary>
        ///    Gets or sets the Application's host Enviornment details.
        /// </summary>
        /// <value>
        ///    The host environment.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:09 PM</DateTime>
        /// </Created>
        HostEnvironment HostEnvironment { get; set; }

        /// <summary>
        ///    Gets or sets the all the ("<c>DAL</c>") data access settings required to connect to the data source and to control the engine.
        /// </summary>
        /// <value>
        /// The data access settings
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:11 PM</DateTime>
        /// </Created>
        DataAccessSettings DataAccessSettings { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Gets the the value with the specified key and converts it to type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">The specified returned type.</typeparam>
        /// <param name="section">The section/container name where it host the specified key.</param>
        /// <param name="key">The key name.</param>
        /// <param name="defaultValue">The failover value to return if no value is found.</param>
        /// <returns>
        /// The the value with the specified key and converts it to type <c>T</c>.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        T GetValue<T>(string section, string key, T defaultValue = default!);

        /// <summary>
        ///    Gets the the value with the specified key and converts it to type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">The specified returned type.</typeparam>
        /// <param name="key">The key name.</param>
        /// <param name="defaultValue">The failover value to return if no value is found.</param>
        /// <returns>
        ///    The the value with the specified key and converts it to type <c>T</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:04 PM</DateTime>
        /// </Created>
        T GetValue<T>(string key, T defaultValue = default!);
        #endregion Methods
    }
}

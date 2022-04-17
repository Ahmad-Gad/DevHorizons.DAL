// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationConfiguration.cs" company="Retail inMotion Corp">
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
namespace DevHorizons.DAL.WebApi.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Configuration;
    using Interfaces;
    using Sql;

    /// <summary>
    ///    The application configuration implementation in a typed format.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
    ///    <DateTime>27/04/2021 01:12 PM</DateTime>
    /// </Created>
    /// <seealso cref="IApplicationConfiguration" />
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        #region Private Fields

        /// <summary>
        ///    Represents a set of key/value application configuration properties.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>26/04/2021 11:49 AM</DateTime>
        /// </Created>
        private readonly IConfiguration configuration;
        #endregion Private Fields

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ApplicationConfiguration"/> class.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 12:48 PM</DateTime>
        /// </Created>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public string ApplicationName { get; set; }

        /// <inheritdoc/>
        public string ApiVersion { get; set; }

        /// <inheritdoc/>
        public HostEnvironment HostEnvironment { get; set; }

        /// <inheritdoc/>
        public DataAccessSettings DataAccessSettings { get; set; } = new DataAccessSettings();
        #endregion Properties

        #region Public Methods

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
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:10 PM</DateTime>
        /// </Created>
        public T GetValue<T>(string section, string key, T defaultValue = default!)

        {
            return this.configuration.GetValue(section, key, defaultValue);
        }

        /// <summary>
        ///    Gets the the value with the specified key and converts it to type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">The specified returned type.</typeparam>
        /// <param name="key">The key name.</param>
        /// <param name="defaultValue">The failover value to return if no value is found.</param>
        /// <returns>
        /// The the value with the specified key and converts it to type <c>T</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 01:10 PM</DateTime>
        /// </Created>
        public T GetValue<T>(string key, T defaultValue = default!)
        {
            return this.configuration.GetValue(key, defaultValue);
        }
        #endregion Public Methods
    }
}

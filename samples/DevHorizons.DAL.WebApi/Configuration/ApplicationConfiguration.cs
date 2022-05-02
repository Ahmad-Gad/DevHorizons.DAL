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
    using DevHorizons.DAL.DependencyInjection;
    using DevHorizons.DAL.Interfaces;

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
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="ApplicationConfiguration"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///    <DateTime>27/04/2021 12:48 PM</DateTime>
        /// </Created>
        public ApplicationConfiguration( )
        {
        }
        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public string AppName { get; set; }

        /// <inheritdoc/>
        public string AppVersion { get; set; }

        /// <inheritdoc/>
        public IDataAccessSettings DataAccessSettings { get; set; } = new DataAccessSettings();
        #endregion Properties
    }
}

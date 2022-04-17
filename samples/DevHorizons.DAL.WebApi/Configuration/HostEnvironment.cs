// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HostEnvironment.cs" company="Retail inMotion Corp">
//    Copyright (c) Retail inMotion Corp. All rights reserved.
// </copyright>
//  <summary>
//    Defines the application's host Enviornment details.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
//    <DateTime>23/04/2021 12:41 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.WebApi.Configuration
{
    /// <summary>
    ///   The application's host Enviornment details.
    /// </summary>
    public class HostEnvironment
    {
        /// <summary>
        ///    Gets or sets the absolute path to the directory that contains the application content files.
        /// </summary>
        /// <value>
        ///    The content root path.
        /// </value>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ContentRootPath { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        ///    Gets or sets the name of the environment. The host automatically sets this property to the value of the of the "environment" key as specified in configuration.
        /// </summary>
        /// <value>
        ///    The name of the environment.
        /// </value>
        public EnvironmentName EnvironmentName { get; set; }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnvironmentName.cs" company="Retail inMotion Corp">
//    Copyright (c) Retail inMotion Corp. All rights reserved.
// </copyright>
//  <summary>
//    Defines the host Environment's enumerators/names.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
//    <DateTime>23/04/2021 12:41 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.WebApi.Configuration
{
    /// <summary>
    ///    Defines the host Environment's enumerators/names.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
    ///    <DateTime>23/04/2021 12:41 PM</DateTime>
    /// </Created>
    public enum EnvironmentName
    {
        /// <summary>
        ///    The local dev/debug enviornment/machine.
        /// </summary>
        Local = 0,

        /// <summary>
        ///    The Development enviornment.
        /// </summary>
        Development = 1,

        /// <summary>
        ///    The Test enviornment.
        /// </summary>
        Test = 2,

        /// <summary>
        ///    The User Acceptance Testing (<c>UAT</c>) enviornment.
        /// </summary>
        Uat = 4,

        /// <summary>
        ///    The preprod enviornment.
        /// </summary>
        Preprod = 8,

        /// <summary>
        ///    The Production enviornment.
        /// </summary>
        Prod = 16,
    }
}

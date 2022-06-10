// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the needed cache settings for the data access layers.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>13/02/2022 06:17 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cache
{
    /// <summary>
    ///    Defines all the needed cache settings for the data access layers.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>13/02/2022 06:17 PM</DateTime>
    /// </Created>
    public class CacheSettings
    {
        #region Properties

        /// <summary>
        ///    Gets or sets a value indicating whether the whole cache module is being disabled including all the level of cache. Not recommended action because it may affect the performance of the engine unless you are quite sure what you are doing.
        ///    <para>The Default Value: <c>false</c>.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public bool Disabled { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the Second Level Cache is being disabled. Not recommended action because it may affect the performance of the engine unless you are quite sure what you are doing.
        ///    <para>The Default Value: <c>false</c>.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public bool DisableSecondLevel { get; set; }

        /// <summary>
        ///    Gets or sets the maximum (in bytes) whereas the memory cache can hold.
        /// </summary>
        /// <remarks>
        ///     <para>Does not apply on the first level cache.</para>
        ///     <para>If new cache is required to be persisted above the threshold, it will be rejected and a warning will be raised to decide later if you would like to increase the threshold and/or increase the host server memory.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public long MemoryCacheThreshold { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the engine will raise all the cache related errors as warning instead of errors.
        ///    <para>If set to "<c>true</c>", all the cache related errors will be silently ignored and command executions will not fail or get terminated.</para>
        ///    <para>If set to "<c>true</c>", the <c>DAL</c> command ("<see cref="Abstracts.ACommand"/>") will raise warning which can be captured by the "<see cref="Abstracts.ACommand.WarningRaised"/>" event handler.</para>
        ///    <para>The Default Value: <c>false</c>.</para>
        /// </summary>
        /// <remarks>If set to "<c>true</c>" and if the logging is not disabled ("<see cref="Interfaces.IDataAccessSettings.LogLevel"/>"), those errors will be logged as warnings.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>17/02/2022 11:25 PM</DateTime>
        /// </Created>
        public bool RaiseErrorsAsWarnings { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Check if the whole cache is allowed as well as the second level cache.
        /// </summary>
        /// <returns><c>true</c> if the whole cache is allowed as well as the second level cache.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>17/02/2022 11:25 PM</DateTime>
        /// </Created>
        internal bool IsSecondLevelCacheAllowed()
        {
            return !this.Disabled && !this.DisableSecondLevel;
        }
        #endregion Methods
    }
}

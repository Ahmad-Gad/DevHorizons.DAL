// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryCache.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the internal components which can be cached into the built-in memory cache on the host machine which is following life cycle of the host application and usually being hosted in a Singleton Dependency Injection life cycle.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cache
{
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Reflection;
    using System.Security.Cryptography;

    using Attributes;
    using Interfaces;

    /// <summary>
    ///    Defines all the internal components which can be cached into the built-in memory cache on the host machine which is following life cycle of the host application and usually being hosted in a Singleton Dependency Injection life cycle.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public class MemoryCache : IMemoryCache
    {
        #region Private Fields

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the first level cached objects.
        /// </summary>
        /// <remarks>This is only applicable if the "<see cref="IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        private long firstLevelCacheMemorySize;

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the second level cached objects.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of the second level cache is set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        private long secondLevelCacheMemorySize;
        #endregion Private Fields

        #region Properties

        /// <inheritdoc/>
        DbProviderFactory IMemoryCache.DataProviderFactory { get; set; }

        /// <inheritdoc/>
        IDictionary<string, List<DataFieldAttribute>> IMemoryCache.CachedDataFields { get; set; } = new SortedDictionary<string, List<DataFieldAttribute>>();

        /// <inheritdoc/>
        IDictionary<string, List<PropertyInfo>> IMemoryCache.CachedProperties { get; set; } = new SortedDictionary<string, List<PropertyInfo>>();

        /// <inheritdoc/>
        byte[] IMemoryCache.HashSaltKey { get; set; }

        /// <inheritdoc/>
        ICryptoTransform IMemoryCache.DeterministicEncryptor { get; set; }

        /// <inheritdoc/>
        ICryptoTransform IMemoryCache.DeterministicDecryptor { get; set; }

        /// <inheritdoc/>
        ICryptoTransform IMemoryCache.RandomizedEncryptor { get; set; }

        /// <inheritdoc/>
        ICryptoTransform IMemoryCache.RandomizedDecryptor { get; set; }

        /// <inheritdoc/>
        long IMemoryCache.FirstLevelCacheMemorySize
        {
            get => (long)(this.firstLevelCacheMemorySize * 1.5);
            set => this.firstLevelCacheMemorySize = value;
        }

        /// <inheritdoc/>
        long IMemoryCache.SecondLevelCacheMemorySize
        {
            get => (long)(this.secondLevelCacheMemorySize * 1.5);
            set => this.secondLevelCacheMemorySize = value;
        }
        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        bool IMemoryCache.ValidateThreshold(CacheSettings cacheSettings, long currentCacheMemorySize, long cacheSize)
        {
            return cacheSettings.MemoryCacheThreshold == 0 || (currentCacheMemorySize + (cacheSize * 1.5)) <= cacheSettings.MemoryCacheThreshold;
        }
        #endregion Methods
    }
}

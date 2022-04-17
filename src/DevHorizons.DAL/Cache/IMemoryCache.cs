// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMemoryCache.cs" company="DevHorizons">
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

    /// <summary>
    ///    Defines all the internal components which can be cached into the built-in memory cache on the host machine which is following life cycle of the host application and usually being hosted in a Singleton Dependency Injection life cycle.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public interface IMemoryCache
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the internal data provider factory generator. It's strognly recommended to be cached in the memory (it will conly preserve few bytes) to save time each time a connection is opened with the data source.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        DbProviderFactory DataProviderFactory { get; set; }

        /// <summary>
        ///    Gets or sets the internal cached transformed hash salt key which is required for the cryptography hashing operations for the designated sensitive/private data like the passwords.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        byte[] HashSaltKey { get; set; }

        /// <summary>
        ///    Gets or sets the internal list of the extracted attributes of data fields mapping.
        ///    <para>Caching these list for each model would avoid doing this operation each time the engine is attempting to map the query result into the designated models/types which in turn could save performance especially with large models with complix designs.</para>
        ///    <para>It is strongly recommended to use the built in memory cache instead of the "<see cref="Microsoft.Extensions.Caching.Distributed.IDistributedCache"/>" which is usually controlled by the DI. However, this option may increase the host server memory (RAM) usage significantly depends on the amount of the data models which can be only truncated with the whole app recycle/reset.</para>
        /// </summary>
        /// <remarks>Part of the second level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        IDictionary<string, List<DataFieldAttribute>> CachedDataFields { get; set; }

        /// <summary>
        ///    Gets or sets the internal list of the extracted properties from a specific type.
        ///    <para>Caching these list for some types to avoid this reflection operation each time.</para>
        ///    <para>It is strongly recommended to use the built in memory cache instead of the "<see cref="Microsoft.Extensions.Caching.Distributed.IDistributedCache"/>" which is usually controlled by the DI. However, this option may increase the host server memory (RAM) usage significantly depends on the amount of the data models which can be only truncated with the whole app recycle/reset.</para>
        /// </summary>
        /// <remarks>Part of the second level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        IDictionary<string, List<PropertyInfo>> CachedProperties { get; set; }

        /// <summary>
        ///   Gets or sets the internal cached initialized deterministic symmetric encryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        ICryptoTransform DeterministicEncryptor { get; set; }

        /// <summary>
        ///   Gets or sets the internal cached initialized deterministic symmetric decryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        ICryptoTransform DeterministicDecryptor { get; set; }

        /// <summary>
        ///   Gets or sets the internal cached initialized randomized (non-deterministic) symmetric encryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        ICryptoTransform RandomizedEncryptor { get; set; }

        /// <summary>
        ///   Gets or sets the internal cached initialized randomized (non-deterministic) symmetric decryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <remarks>Part of the first level cache.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        ICryptoTransform RandomizedDecryptor { get; set; }

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the first level cached objects.
        /// </summary>
        /// <remarks>This is only applicable if the "<see cref="Interfaces.IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long FirstLevelCacheMemorySize { get; set; }

        /// <summary>
        ///    Gets or sets the allocated memory size (in bytes) for the second level cached objects.
        /// </summary>
        /// <remarks>This is only applicable when the "<see cref="CacheMethod"/>" of the second level cache is set to "<see cref="CacheMethod.Memory"/>" and the "<see cref="Interfaces.IDataAccessSettings.DisableCache"/>" is set to "<c>false</c>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        long SecondLevelCacheMemorySize { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        ///    Validate if the new cache item will not violate the cache size threshold.
        /// </summary>
        /// <param name="cacheSettings">The target cache setting for the target cache level.</param>
        /// <param name="currentCacheMemorySize">The current accumulated cache size (bytes) for the target cache level.</param>
        /// <param name="cacheSize">The new cache item's size in bytes.</param>
        /// <returns><c>true</c> if the new cache item's size will not violate the cache size threshold; otherwise else, <c>false</c> and no further commands/transactions can be executed.</returns>
        /// <remarks>
        ///    Applicable only for the memory cache option ("<see cref="CacheMethod.Memory"/>").
        ///    <para>Does not apply on the first level cache.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>18/02/2022 12:26 AM</DateTime>
        /// </Created>
        bool ValidateThreshold(CacheSettings cacheSettings, long currentCacheMemorySize, long cacheSize);
        #endregion Methods
    }
}

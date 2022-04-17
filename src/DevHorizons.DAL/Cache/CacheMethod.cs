// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheMethod.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the possible cache containers for the internal metadata information.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cache
{
    /// <summary>
    ///    Defines all the possible cache containers options for the internal metadata information.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public enum CacheMethod
    {
        /// <summary>
        ///    The cache is being disabled for the specified action/cache level.
        /// </summary>
        None = 0,

        /// <summary>
        ///    Using the built-in memory cache ("<see cref="IMemoryCache"/>") on the host machine which is following life cycle of the host application and usually being hosted in a Singleton Dependency Injection life cycle.
        ///    <para>The most recommended option for the best performance. However, it can consume significant amount of memory on the host server depends on the number of data models registered in the host application.</para>
        ///    <para>You can monitor the allocated memory (in bytes) for this option for the designated levels using from the "<see cref="Abstracts.Command"/>" class. E.g. "<see cref="Abstracts.Command.SecondLevelCacheMemorySize"/>".</para>
        /// </summary>
        Memory = 1,
    }
}

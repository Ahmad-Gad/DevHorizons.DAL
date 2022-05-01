// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the data source connection/access related settings.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System.Data.Common;
    using Attributes;

    /// <summary>
    ///    Defines all the data source connection/access related settings.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public class ConnectionSettings : IConnectionSettings
    {
        /// <inheritdoc/>
        public string ConnectionString { get; set; }

        /// <inheritdoc/>
        public DbConnection DbConnection { get; set; }

        /// <inheritdoc/>
        public string DatabaseName { get; set; }

        /// <inheritdoc/>
        public int? CommandTimeout { get; set; }

        /// <inheritdoc/>
        [NameValuePair("Connection Lifetime")]
        public int? ConnectionLifetime { get; set; }

        /// <inheritdoc/>
        [NameValuePair("Connection Timeout")]
        public int? ConnectionTimeout { get; set; }

        /// <inheritdoc/>
        [NameValuePair("Pooling")]
        public bool? ConnectionPooling { get; set; }
    }
}

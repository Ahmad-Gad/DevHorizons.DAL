// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnectionSettings.cs" company="DevHorizons">
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

    /// <summary>
    ///    Defines all the data source connection/access related settings.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public interface IConnectionSettings
    {
        /// <summary>
        ///    Gets or sets the whole connection string for the data access.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        string ConnectionString { get; set; }

        /// <summary>
        ///    Gets or sets the data source connection instance of the type "<see cref="DbConnection"/>".
        /// </summary>
        /// <remarks>
        ///    It doesn't matter if the connection is opened or closed. If closed, the engine will open it.
        ///    <para>If the "<see cref="ConnectionString"/>" property is specified, it will override the encapsulated connection string.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/04/2022 08:19 PM</DateTime>
        /// </Created>
        DbConnection DbConnection { get; set; }

        /// <summary>
        ///    Gets or sets the name of the targeted/connected database.
        ///    <para>This is optional because the target database can be specified as part of the connection string "<see cref="ConnectionString"/>".</para>
        ///    <para>If specified, it will override the one specified in the connection string "<see cref="ConnectionString"/>".</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        string DatabaseName { get; set; }

        /// <summary>
        ///    Gets or sets the wait time (in seconds) before terminating the attempt to execute a command and generating an error.
        ///    <para>The Default Value: Null.</para>
        /// </summary>
        /// <remarks>
        ///    If Null, it will use the default value of the data source system. For exampe, if it's SQL Server, then it will be 30 seconds.
        ///    <para>A value of 0 indicates no limit (an attempt to execute a command will wait indefinitely).</para>
        ///    <para>This property is the cumulative time-out (for all network packets that are read during the invocation of a method) for all network reads during command execution or processing of the results. A time-out can still occur after the first row is returned, and does not include user processing time, only network read time.</para>
        ///    <para>For example, with a 30 second time out, if Read requires two network packets, then it has 30 seconds to read both network packets. If you call Read again, it will have another 30 seconds to read any data that it requires.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        int? CommandTimeout { get; set; }

        /// <summary>
        ///    Gets or sets the specified seconds for how long an underlying connection can exist before the driver closes the underlying connection instead of returning it to the connection pool upon connection object close. Idle pooled connections are closed and removed from the pool once they reach the defined Connection Lifetime.
        ///    <para>The Default Value: <c>Null</c>.</para>
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.connectionstring?view=dotnet-plat-ext-6.0"/></para>
        /// </summary>
        /// <value>The connection lifetime in seconds.</value>
        /// <remarks>
        ///    If not specified, it will use the default value which is (0). A value of zero (0) causes pooled connections to have the maximum connection timeout.
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/04/2022 09:51 PM</DateTime>
        /// </Created>
        int? ConnectionLifetime { get; set; }

        /// <summary>
        ///    Gets or sets the length of time (in seconds) to wait for a connection to the server before terminating the attempt and generating an error.
        ///    <para>The Default Value: <c>Null</c>.</para>
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.connectiontimeout?view=dotnet-plat-ext-6.0"/></para>
        /// </summary>
        /// <value>The connection timeout in seconds.</value>
        /// <remarks>
        ///    Valid values are greater than or equal to 0 and less than or equal to 2147483647.
        ///    <para>If not specified, it will use the default value which is (15) seconds.</para>
        ///    <para>A value of zero (0) will set the connection timeout to the maximum.</para>
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/04/2022 09:51 PM</DateTime>
        /// </Created>
        int? ConnectionTimeout { get; set; }

        /// <summary>
        ///    Gets or sets whether the connection pooling is allowed or not.
        ///    <para>The Default Value: <c>Null</c>.</para>
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-connection-pooling"/></para>
        /// </summary>
        /// <value>The <c>true</c>, the connection pooling is allowed, otherwise; <c>false</c>.</value>
        /// <remarks>
        ///    <para>If not specified, it will use the default value which is (true). By default the connection pooling is enabled for the same identical connection string parameters/values.</para>
        ///    <para>You may only need to set it to <c>false</c> to disable it.</para>
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/04/2022 09:51 PM</DateTime>
        /// </Created>
        bool? ConnectionPooling { get; set; }
    }
}

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
    }
}

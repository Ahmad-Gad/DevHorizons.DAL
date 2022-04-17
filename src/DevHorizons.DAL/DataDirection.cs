// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataDirection.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the data direction from/to a data model which either data being sent to the data source or data being received by the data source.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>13/02/2022 08:00 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;

    /// <summary>
    ///    Defines the data direction from/to a data model which either data being sent to the data source or data being received by the data source.
    /// </summary>
    /// <Created>
    ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///   <datetime>13/02/2022 08:00 PM</datetime>
    /// </Created>
    [Flags]
    public enum DataDirection
    {
        /// <summary>
        ///    Direction not being identified which may be a flag to ignore the bound field/property.
        /// </summary>
        None = 0,

        /// <summary>
        ///    The bound field/property (within a data model) which expects the data/values source coming in from the data source itself after executing a query.
        /// </summary>
        Inbound = 1,

        /// <summary>
        ///    The bound field/property expects the data/values source coming from a user request to be sent to the data source (execute query) as parameter or part of a parameter.
        /// </summary>
        Outbound = 2,

        /// <summary>
        ///    The bound field/property is expected to server both inbound and outbound connection from/to the database.
        /// </summary>
        Both = Inbound | Outbound
    }
}

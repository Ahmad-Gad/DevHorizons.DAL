// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DmlAction.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the DML (Data Manipulation Language) action which would be used in CRUD operation.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>23/02/2022 05:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;

    /// <summary>
    ///    Specifies the <c>DML</c> (Data Manipulation Language) action which would be used in <c>CRUD</c> operation.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>23/02/2022 05:44 PM</DateTime>
    /// </Created>
    [Flags]
    public enum CommandAction
    {
        /// <summary>
        ///    Not involved in any <c>DML</c>/<c>CRUD</c> operation/action.
        /// </summary>
        None = 0,

        /// <summary>
        ///    To run a "<c>DQL</c>" (Data Query Language) command and retrieving data/record set back from the data source.
        /// </summary>
        Select = 1,

        /// <summary>
        ///    Would support "Insert/Add" action/operation.
        /// </summary>
        Insert = 2,

        /// <summary>
        ///    Would support "Update/Modify" action/operation.
        /// </summary>
        Update = 4,

        /// <summary>
        ///    Would support "Delete/Remove" action/operation.
        /// </summary>
        Delete = 8,

        /// <summary>
        ///    Would support all the <c>DML</c>/<c>CRUD</c> actions/operations.
        /// </summary>
        All = Select | Insert | Update | Delete
    }
}
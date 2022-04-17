// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataRowAttribute.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the Data Table/Row/Record Attribute class.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Attributes
{
    using System;
    using Shared;

    /// <summary>
    ///    The attribute can be added to the designed data model classes to be implemented and populated by the <c>DAL</c> library.
    ///    <para>This data model may represent a table or a row/record schema/structure.</para>
    ///    <para>It could be a member/property of parent model or collection of members to serve either of the special data types like "<see cref="SpecialType.Json"/>", "<see cref="SpecialType.Xml"/>" and "<see cref="SpecialType.Structured"/>".</para>
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:57 PM</DateTime>
    /// </Created>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DataRowAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataRowAttribute"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:59 PM</DateTime>
        /// </Created>
        public DataRowAttribute()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataRowAttribute"/> class.
        /// </summary>
        /// <param name="name">The mapped database table's name.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:59 PM</DateTime>
        /// </Created>
        public DataRowAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRowAttribute"/> class.
        /// </summary>
        /// <param name="name">The mapped database table's name.</param>
        /// <param name="ignoreNullData">if set to <c>true</c>, all the returned null-able data will be ignored, and the mapped properties will be automatically set the default value by the <c>CLR</c>.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:00 AM</DateTime>
        /// </Created>
        public DataRowAttribute(string name, bool ignoreNullData) : this(name)
        {
            this.IgnoreNullData = ignoreNullData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataRowAttribute"/> class.
        /// </summary>
        /// <param name="name">The mapped database table's name.</param>
        /// <param name="ignoreNullData">if set to <c>true</c>, all the returned null-able data will be ignored, and the mapped properties will be automatically set the default value by the <c>CLR</c>.</param>
        /// <param name="allowedActions">The <c>DML</c> (Data Manipulation Language) action which would be used in <c>CRUD</c> operation.</param>
        /// <remarks>The "<c>allowedDmlActions</c>" of type "<see cref="CommandAction"/>" won't apply on the stored procedures style/concept, because the stored procedure is controlling the logic.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:00 AM</DateTime>
        /// </Created>
        public DataRowAttribute(string name, bool ignoreNullData, CommandAction allowedActions) : this(name, ignoreNullData)
        {
            this.IgnoreNullData = ignoreNullData;
            this.AllowedActions = allowedActions;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the mapped database table's name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:01 AM</DateTime>
        /// </Created>
        public string Name { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether all the returned null-able data will be ignored, and the mapped properties will be automatically set the default value by the <c>CLR</c>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ignore null data]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:03 AM</DateTime>
        /// </Created>
        public bool IgnoreNullData { get; set; }

        /// <summary>
        ///    Gets or sets the <c>DML</c> (Data Manipulation Language) action which would be used in <c>CRUD</c> operation.
        /// </summary>
        /// <remarks>This won't apply on the stored procedures style/concept, because the stored procedure is controlling the logic.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/02/2022 06:02 PM</DateTime>
        /// </Created>
        public CommandAction AllowedActions { get; set; } = CommandAction.All;
        #endregion Properties
    }
}

// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommandBodyAttribute.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the Data Table Attribute class.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Attributes
{
    using System;

    /// <summary>
    ///    The attribute can be added to the command body class which implements the "<see cref="Shared.CommandBody"/>".
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:57 PM</DateTime>
    /// </Created>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandBodyAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="CommandBodyAttribute"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:59 PM</DateTime>
        /// </Created>
        public CommandBodyAttribute()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="CommandBodyAttribute"/> class.
        /// </summary>
        /// <param name="name">The mapped stored procedure's name includung the schema name <c>e.g. [dbo].[GetSalesData]</c>.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:59 PM</DateTime>
        /// </Created>
        public CommandBodyAttribute(string name)
        {
            this.Name = name;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the mapped stored procedure's name includung the schema name <c>e.g. [dbo].[GetSalesData]</c>.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:01 AM</DateTime>
        /// </Created>
        public string Name { get; set; }
        #endregion Properties
    }
}

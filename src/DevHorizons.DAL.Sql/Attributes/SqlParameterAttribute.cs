// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SqlParameterAttribute.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the required database's parameter members required to be injected with the stored procedure.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
//    <DateTime>07/11/2018 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Sql.Attributes
{
    using System;

    /// <summary>
    ///    The attribute can be added to the properties within the command body class which implements the "<see cref="Shared.CommandBody"/>".
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:57 PM</DateTime>
    /// </Created>
    /// <seealso cref="Attribute" />
    public class SqlParameterAttribute : DAL.Attributes.ParameterAttribute
    {
        #region Properties

        /// <summary>
        ///    Gets or sets a the data type.
        /// </summary>
        /// <value>
        ///   The data type.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public SqlDbType Type { get; set; } = SqlDbType.Auto;
        #endregion Properties
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the required SQL Parameter members.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>07/11/2018 11:00 AM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    using System;

    /// <summary>
    ///    A class which would represent the SQL Parameter.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:00 AM</DateTime>
    /// </Created>
    public class Parameter : Abstracts.Parameter
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:01 AM</DateTime>
        /// </Created>
        public Parameter()
        {
            this.Direction = Direction.Input;
            this.Size = -1;
            this.DataType = DbType.Auto;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value) : this(name)
        {
            this.Value = value;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value, Enum dataType) : this(name, value)
        {
            this.DataType = (DbType)dataType;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="size">
        ///    The maximum size, in bytes, of the data within the column.
        ///    <para>The Default Value: -1 (Which would be The max value the parameter can hold).</para>
        /// </param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value, Enum dataType, int size) : this(name, value, dataType)
        {
            this.Size = size;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.
        /// <para>The Default Value: -1 (Which would be The max value the parameter can hold).</para></param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value, Enum dataType, int size, Direction direction) : this(name, value, dataType, size)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value, Enum dataType, Direction direction) : this(name, value, dataType)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, object value, Direction direction) : this(name, value)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///      <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public Parameter(string name, Direction direction) : this(name)
        {
            this.Direction = direction;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the data type as "<see cref="DbType"/>".
        ///    <para>The Default Value: <see cref="DbType.Auto"/>.</para>
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 02:13 PM</DateTime>
        /// </Created>
        public DbType DataType { get; set; }
        #endregion Properties
    }
}

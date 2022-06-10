// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SqlParameter.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Sql
{
    using Shared;

    /// <summary>
    ///    A class which holds the required database's parameter members required to be injected with the stored procedure.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:00 AM</DateTime>
    /// </Created>
    public class SqlParameter : Abstracts.AParameter
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:01 AM</DateTime>
        /// </Created>
        public SqlParameter()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter"/> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@retailinmotion.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, SqlDbType dataType) : this(name)
        {
            this.DataType = dataType;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, SqlDbType dataType, object value) : this(name, dataType)
        {
            this.Value = value;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="size">
        ///    The maximum size, in bytes, of the data within the column.
        ///    <para>The Default Value: -1 (Which would be The max value the parameter can hold).</para>
        /// </param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, SqlDbType dataType, object value, int size) : this(name, dataType, value)
        {
            this.Size = size;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.
        /// <para>The Default Value: -1 (Which would be The max value the parameter can hold).</para></param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, SqlDbType dataType, object value, int size, Direction direction) : this(name, dataType, value, size)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="dataType">The parameter data type.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, SqlDbType dataType, object value, Direction direction) : this(name, dataType, value)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, Direction direction) : this(name)
        {
            this.Direction = direction;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, object value) : this(name)
        {
            this.Value = value;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlParameter" /> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        /// <param name="direction">The direction of the parameter within the Stored Procedure as "Input", "Output" or "Return".</param>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>08/11/2018 05:28 PM</DateTime>
        /// </Created>
        public SqlParameter(string name, object value, Direction direction) : this(name, value)
        {
            this.Direction = direction;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the data type as "<see cref="Sql.SqlDbType"/>".
        ///    <para>The Default Value: Null.</para>
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 02:13 PM</DateTime>
        /// </Created>
        public virtual SqlDbType? DataType { get; set; }
        #endregion Properties
    }
}

// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IParameterBase.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Interfaces
{
    using Shared;

    /// <summary>
    ///    The attribute can be added to the properties within the command body class which implements the "<see cref="CommandBody"/>".
    ///    <para>Defines all the required properties of the mapped stored procedure's parameter.</para>
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:57 PM</DateTime>
    /// </Created>
    /// <seealso cref="IDataFieldBase" />
    public interface IParameterBase : IDataFieldBase
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the direction of the parameter as "Input", "Output" or "Return".
        ///    <para>The Default Value: <see cref="Direction.Input"/>.</para>
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:12 AM</DateTime>
        /// </Created>
        Direction Direction { get; set; }

        /// <summary>
        ///    Gets or sets the maximum size, in bytes, of the data within the column.
        ///    <para>The Default Value: -1 (Which would be The max value the parameter can hold).</para>
        /// </summary>
        /// <value>
        ///    The maximum size, in bytes, of the data within the column. The default value is inferred from the parameter value.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:23 PM</DateTime>
        /// </Created>
        int Size { get; set; }

        /// <summary>
        ///   Gets or sets the maximum number of digits for the numeric and decimal data types.
        /// </summary>
        /// <value>
        ///   The maximum number of digits used to represent the property.
        ///   <para>The default value is 0. This indicates that the data provider sets the precision for.</para>
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:26 PM</DateTime>
        /// </Created>
        byte Precision { get; set; }

        /// <summary>
        ///    Gets or sets the number of decimal places for the for the numeric and decimal data types.
        /// </summary>
        /// <value>
        ///    The number of decimal places for the numeric and decimal data types.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:28 PM</DateTime>
        /// </Created>
        byte Scale { get; set; }
        #endregion Properties
    }
}

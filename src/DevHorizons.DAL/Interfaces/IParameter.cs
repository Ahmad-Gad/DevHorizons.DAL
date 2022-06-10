// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IParameter.cs" company="DevHorizons">
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
    /// <seealso cref="IDataField" />
    public interface IParameter : IParameterBase, IDataField
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the transformed value which could be different from the mapped property value and type.
        ///    <para>This value could encrypted, decrypted, hashed or <c>JSON</c>/<c>XML</c> serialized/deserialized.</para>
        /// </summary>
        /// <value>
        ///    The final updated value.
        /// </value>
        /// <remarks>This property is managed by the "<c>DAL</c>" service.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        object Value { get; set; }
        #endregion Properties
    }
}

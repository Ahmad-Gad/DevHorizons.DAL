// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataField.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the required data field/parameter members.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>05/03/2018 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Interfaces
{
    using System;
    using System.Reflection;
    using Cryptography;
    using Shared;

    /// <summary>
    ///    A type which would represent the data field/parameter.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:00 AM</DateTime>
    /// </Created>
    public class DataField : IDataField
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>09/06/2022 07:11 PM</DateTime>
        /// </Created>
        public DataField()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataField"/> class.
        /// </summary>
        /// <param name="property">The bound/mapped property as an instance of "<see cref="PropertyInfo"/>".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>09/06/2022 07:11 PM</DateTime>
        /// </Created>
        public DataField(PropertyInfo property)
        {
            this.Property = property;
        }
        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public SpecialType SpecialType { get; set; } = SpecialType.None;

        /// <inheritdoc/>
        public bool Encrypted { get; set; }

        /// <inheritdoc/>
        public bool MayBeEncrypted { get; set; }

        /// <inheritdoc/>
        public EncryptionType EncryptionType { get; set; } = EncryptionType.Default;

        /// <inheritdoc/>
        public bool Hashed { get; set; }

        /// <inheritdoc/>
        public bool Optional { get; set; }

        /// <inheritdoc/>
        public bool NotMapped { get; set; }

        /// <inheritdoc/>
        public PropertyInfo Property { get; private set; }

        /// <summary>
        ///    Gets or sets the data direction/flow from/to a data model which either data being sent to the data source or data being received by the data source.
        /// </summary>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <datetime>13/02/2022 08:00 PM</datetime>
        /// </Created>
        public DataDirection DataDirection { get; set; } = DataDirection.Both;
        #endregion Properties

        #region Internal Properties

        ///// <summary>
        /////    Gets or sets the transformed value which could be different from the mapped property value and type.
        /////    <para>This value could encrypted, decrypted, hashed or <c>JSON</c>/<c>XML</c> serialized/deserialized.</para>
        ///// </summary>
        ///// <value>
        /////    The final updated value.
        ///// </value>
        ///// <remarks>This property is managed by the "<c>DAL</c>" service.</remarks>
        ///// <Created>
        /////    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        /////    <DateTime>10/02/2020 11:53 PM</DateTime>
        ///// </Created>
        //internal object Value { get; set; }

        /// <summary>
        ///    Gets or sets the transformed <c>CLR</c> "Type" which could be different from the mapped property value and type.
        ///    <para>This value could be encrypted, decrypted, hashed or <c>JSON</c>/<c>XML</c> serialized/deserialized.</para>
        /// </summary>
        /// <value>
        ///    The final <c>CLR</c> updated type.
        /// </value>
        /// <remarks>This property is managed by the "<c>DAL</c>" service.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        internal Type Type { get; set; }
        #endregion Internal Properties

        #region Public Methods

        /// <inheritdoc/>
        public void SetPropertyInfo(PropertyInfo property)
        {
            this.Property = property;
        }
        #endregion Public Methods
    }
}

// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataFieldAttribute.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the Data Column Attribute class.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Attributes
{
    using System;
    using System.Reflection;
    using Cryptography;
    using Shared;

    /// <summary>
    ///    The attribute can be added to the properties which is encapsulated in the designed data model classes to be implemented and populated by the <c>DAL</c> library.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:47 PM</DateTime>
    /// </Created>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataFieldAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataFieldAttribute"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:48 PM</DateTime>
        /// </Created>
        public DataFieldAttribute()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataFieldAttribute"/> class.
        /// </summary>
        /// <param name="prop">The bound property as an instance of "<see cref="PropertyInfo"/>". This property is designed to serve the library internally only.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:48 PM</DateTime>
        /// </Created>
        public DataFieldAttribute(PropertyInfo prop)
        {
            this.Property = prop;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataFieldAttribute"/> class.
        /// </summary>
        /// <param name="name">The source database table's column name or stored procedure's parameter name.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:48 PM</DateTime>
        /// </Created>
        public DataFieldAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataFieldAttribute"/> class.
        /// </summary>
        /// <param name="name">The source database table's column name or stored procedure's parameter name.</param>
        /// <param name="notMapped">if set to <c>true</c> the property will not be mapped with returned table or the command body (stored procedure).</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:49 PM</DateTime>
        /// </Created>
        public DataFieldAttribute(string name, bool notMapped) : this(name)
        {
            this.NotMapped = notMapped;
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="DataFieldAttribute"/> class.
        /// </summary>
        /// <param name="name">The source database table's column name or stored procedure's parameter name.</param>
        /// <param name="notMapped">if set to <c>true</c> the property will not be mapped with returned table or the command body (stored procedure).</param>
        /// <param name="canBeNull">if set to <c>true</c> the mapped column can be expected to return with null-able value and in this case, the <c>DAL</c> library will ignore it to be populated with the default value automatically by the <c>CLR</c>.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:50 PM</DateTime>
        /// </Created>
        public DataFieldAttribute(string name, bool notMapped, bool canBeNull) : this(name, notMapped)
        {
            this.CanBeNull = canBeNull;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the source database table's column name or stored procedure's parameter name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:51 PM</DateTime>
        /// </Created>
        public string Name { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the property will not be mapped with returned table or the command body (stored procedure).
        /// </summary>
        /// <value>
        ///   <c>true</c> if [not mapped]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public bool NotMapped { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the mapped column can be expected to return (from output parameter) with null-able value and in this case, the <c>DAL</c> library will ignore it to be populated with the default value automatically by the <c>CLR</c>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can be null; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public bool CanBeNull { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the mapped column in the designated table in the database is nullable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this input value can be null; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///    Default Value: <c>false</c>.
        ///    <para>Even if the host property is nullable type, this attribute is overriding the property behaviour.</para>
        ///    <para>If set to "<c>false</c>" while the value is null, then this property will be skipped from the data inputs into the database.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/03/2022 06:38 PM</DateTime>
        /// </Created>
        public bool AllowNull { get; set; }

        /// <summary>
        ///    Gets or sets the explicit special type of data column or parameter.
        /// </summary>
        /// <value>
        ///   The explicit special type of data column or parameter.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public SpecialType SpecialType { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value/data will be decrypted before begin assigned to the mapped property.
        /// </summary>
        /// <remarks>
        ///    The returned data/value should be in the "<c>Base64</c>" string fromat.
        ///    <para>Supress the "<see cref="Hashed"/>".</para>
        /// </remarks>
        /// <value>
        ///   <c>true</c> if [Encrypted]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public bool Encrypted { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value/data may be encrypted and will attempt to decrypt it before begin assigned to the mapped property.
        /// </summary>
        /// <remarks>
        ///    The returned data/value should be in the "<c>Base64</c>" string fromat.
        ///    <para>Supress the "<see cref="Hashed"/>".</para>
        /// </remarks>
        /// <value>
        ///   <c>true</c> if the data could be encrypted; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public bool MayBeEncrypted { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value will be hashed to the "<c>Base</c>" string fromat before begin assigned to the stored procedure parameter's value.
        ///    <para>Common for passwords.</para>
        /// </summary>
        /// <remarks>Suppressed by the "<see cref="Encrypted"/>" or by the "<see cref="MayBeEncrypted"/>" properties if either is specified.</remarks>
        /// <value>
        ///   <c>true</c> if [hashed]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        public bool Hashed { get; set; }

        /// <summary>
        ///    Gets or sets a the encryption type. Supports two types of encryption: randomized encryption and deterministic encryption.
        /// </summary>
        /// <remarks>The default value will be specified by the "<see cref="SymmetricEncryption.DefaultEncryptionType"/>" which is usually "<see cref="EncryptionType.Deterministic"/>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public EncryptionType EncryptionType { get; set; } = EncryptionType.Default;

        /// <summary>
        ///    Gets or sets the data direction from/to a data model which either data being sent to the data source or data being received by the data source.
        /// </summary>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <datetime>13/02/2022 08:00 PM</datetime>
        /// </Created>
        public DataDirection DataDirection { get; set; } = DataDirection.Both;

        /// <summary>
        ///    Gets or sets the <c>DML</c> (Data Manipulation Language) action which would be used in <c>CRUD</c> operation.
        /// </summary>
        /// <remarks>
        ///    This won't apply on the stored procedures style/concept, because the stored procedure is controlling the logic.
        ///    <para>The "<see cref="CommandAction.Delete"/>" does not apply on the property level.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/02/2022 06:02 PM</DateTime>
        /// </Created>
        public CommandAction Action { get; set; } = CommandAction.All;

        /// <summary>
        ///    Gets or sets a value indicating whether the the mapped property is supposed to return the identity/autonumber (<c>"SCOPE_IDENTITY()"</c> or "@@Identity") generated by an "Insert" DML command.
        /// </summary>
        /// <remarks>You can have only this attribute on one property in the whole class. And the declaration type should match the integer family (<see cref="short"/>, <see cref="int"/> or <see cref="long"/>).</remarks>
        /// <value>
        ///   <c>true</c> if [flagged as identity/autonumber]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/02/2022 06:02 PM</DateTime>
        /// </Created>
        public bool Identity { get; set; }

        /// <summary>
        ///    Gets the bound property as an instance of "<see cref="PropertyInfo"/>". This property is designed to serve the library internally only.
        /// </summary>
        /// <value>
        ///    The property as an instance of "<see cref="PropertyInfo"/>".
        /// </value>
        /// <remarks>This property is managed by the "<c>DAL</c>" service.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        public PropertyInfo Property { get; internal set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the mapped field will be assigned by output values after the "Insert" action.
        /// </summary>
        /// <value>
        ///    <c>true</c> if it expect to receive a value back from the data source after the "Insert" command; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Applicable only to the "<see cref="CommandAction.Insert"/>" command.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        public bool InsertedOutput { get; set; }
        #endregion Properties

        #region Internal Properties

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
        internal object Value { get; set; }

        /// <summary>
        ///    Gets or sets the transformed "Type" which could be different from the mapped property value and type.
        ///    <para>This value could encrypted, decrypted, hashed or <c>JSON</c>/<c>XML</c> serialized/deserialized.</para>
        /// </summary>
        /// <value>
        ///    The final updated type.
        /// </value>
        /// <remarks>This property is managed by the "<c>DAL</c>" service.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        internal Type DataType { get; set; }
    #endregion Internal Properties
}
}

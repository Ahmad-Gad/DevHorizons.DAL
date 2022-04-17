// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IParameterAttribute.cs" company="DevHorizons">
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
    using System.Reflection;

    using Cryptography;
    using Shared;

    /// <summary>
    ///    The attribute can be added to the properties within the command body class which implements the "<see cref="CommandBody"/>".
    ///    <para>Defines all the required properties of the mapped stored procedure's parameter.</para>
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>10/02/2020 11:57 PM</DateTime>
    /// </Created>
    /// <seealso cref="System.Attribute" />
    public interface IParameterAttribute
    {
        #region Properties

        /// <summary>
        ///    Gets or sets the parameter's name.
        /// </summary>
        /// <value>
        ///    The parameter's name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>07/11/2018 11:02 AM</DateTime>
        /// </Created>
        string Name { get; set; }

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
        ///   Gets or sets the maximum number of digits used to represent the "<see cref="System.Data.Common.DbParameter.Value"/>" property.
        /// </summary>
        /// <value>
        ///   The maximum number of digits used to represent the "<see cref="System.Data.Common.DbParameter.Value"/>" property.
        ///   The default value is 0. This indicates that the data provider sets the precision for the "<see cref="System.Data.Common.DbParameter.Value"/>".
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:26 PM</DateTime>
        /// </Created>
        byte Precision { get; set; }

        /// <summary>
        ///    Gets or sets the number of decimal places to which "<see cref="System.Data.Common.DbParameter.Value"/>" is resolved.
        /// </summary>
        /// <value>
        ///    The number of decimal places to which "<see cref="System.Data.Common.DbParameter.Value"/>" is resolved. The default is 0.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:28 PM</DateTime>
        /// </Created>
        byte Scale { get; set; }

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
        bool NotMapped { get; set; }

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
        SpecialType SpecialType { get; set; }

        /// <summary>
        ///    Gets or sets the bound property as an instance of "<see cref="PropertyInfo"/>". This property is designed to serve the library internally only.
        /// </summary>
        /// <value>
        ///    The property as an instance of "<see cref="PropertyInfo"/>"..
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:53 PM</DateTime>
        /// </Created>
        PropertyInfo Property { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value will be encrypted (to the "<c>Base</c>" string fromat) before begin assigned to the stored procedure parameter's value or decrypted back (to the "<c>Base</c>" string fromat) for the output parameters.
        /// </summary>
        /// <remarks>Suppresses the "<see cref="Hashed"/>" property if specified.</remarks>
        /// <value>
        ///   <c>true</c> if [Encrypted]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        bool Encrypted { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value will be hashed to the "<c>Base</c>" string fromat before begin assigned to the stored procedure parameter's value.
        ///    <para>Common for passwords.</para>
        /// </summary>
        /// <remarks>Suppressed by the "<see cref="Encrypted"/>" property if specified.</remarks>
        /// <value>
        ///   <c>true</c> if [hashed]; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        bool Hashed { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the value/data may be encrypted and will attempt to decrypt it before begin assigned to the mapped property.
        /// </summary>
        /// <remarks>
        ///    The returned data/value should be in the "<c>Base64</c>" string fromat.
        /// </remarks>
        /// <value>
        ///   <c>true</c> if the data could be encrypted; otherwise, <c>false</c>.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:52 PM</DateTime>
        /// </Created>
        bool MayBeEncrypted { get; set; }

        /// <summary>
        ///    Gets or sets a the encryption type. Supports two types of encryption: randomized encryption and deterministic encryption.
        /// </summary>
        /// <remarks>The default value will be specified by the "<see cref="SymmetricEncryption.DefaultEncryptionType"/>" which is usually "<see cref="EncryptionType.Deterministic"/>".</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        EncryptionType EncryptionType { get; set; }
        #endregion Properties
    }
}

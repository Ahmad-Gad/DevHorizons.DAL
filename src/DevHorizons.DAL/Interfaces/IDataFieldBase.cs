// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDataFieldBase.cs" company="DevHorizons">
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
    public interface IDataFieldBase
    {
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
        ///    Gets or sets a value indicating whether the mapped property/column/parameter is optional/nullable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this input value can be null; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///    Default Value: <c>false</c>.
        ///    <para>If set to "<c>true</c>" while the value is null, then the mapped property/column/parameter will be skipped from mapping and will follow the data source nullable rules/default assigned value/default constraint.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/03/2022 06:38 PM</DateTime>
        /// </Created>
        bool Optional { get; set; }

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
    }
}

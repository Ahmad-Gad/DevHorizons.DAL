// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CryptoResult.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for CryptoResult type.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>18/02/2022 09:59 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    using Interfaces;

    /// <summary>
    ///    A class holds the result of cryptography operation (encryption, decryption or hashing) plus the output error (if error/exception being raised during the operaion).
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <datetime>18/02/2022 09:59 PM</datetime>
    /// </Created>
    public class CryptoResult
    {
        /// <summary>
        ///    Gets or sets the result of cryptography operation (encryption, decryption or hashing).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <datetime>18/02/2022 09:59 PM</datetime>
        /// </Created>
        public string Value { get; set; }

        /// <summary>
        ///    Gets or sets the output error (if error/exception being raised during the operaion).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <datetime>18/02/2022 09:59 PM</datetime>
        /// </Created>
        public ILogDetails OutputError { get; set; }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HashingSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the cryptography hashing settings.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>20/02/2022 11:22 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    /// <summary>
    ///    Defines all the cryptography hashing settings.
    /// </summary>
    /// <remarks>Hashing is a cryptographic process that can be used to validate the authenticity and integrity of various types of input. It is widely used in authentication systems to avoid storing plaintext passwords in databases, but is also used to validate files, documents and other types of data.</remarks>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>20/02/2022 11:22 PM</DateTime>
    /// </Created>
    public class HashingSettings
    {
        /// <summary>
        ///    Gets or sets the targeted the PRF (Pseudo Random Function) which should be used for the key derivation (hash) algorithm for the hashing (one way) encryption.
        ///    <para>If not specified the engine will use the "<see cref="KeyDerivationPrf.SHA512"/>" one.</para>
        /// </summary>
        /// <remarks>
        ///    The "<see cref="KeyDerivationPrf.SHA1"/>" is being comprimised for a long while and must not be used anymore for security wise.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public KeyDerivationPrf KeyDerivationPrf { get; set; } = KeyDerivationPrf.SHA512;

        /// <summary>
        ///    Gets or sets the hash key which will be used for the hashing operations.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public string HashKey { get; set; }
    }
}

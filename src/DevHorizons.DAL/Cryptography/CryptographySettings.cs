// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CryptographySettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the cryptography settings required for the <c>DAL</c> engine to encrypt, decrypt and hash data.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    using System.Security.Cryptography;

    /// <summary>
    ///    Defines all the cryptography settings required for the <c>DAL</c> engine to encrypt, decrypt and hash data.
    /// </summary>
    /// <remarks>
    ///    If the required Symmetric Encryption Key(s) are not specified/set, the symmetric encryption/decryption functionalities will not work and exceptions will be raised if the encryption/decryption functions are required as per the consumers/developer instructions.
    ///    <para>If the "HashKey" is not specified/set, the hashing functionality will not work and exceptions will be raised if the functions are encryption/decryption functions are required as per the consumers/developer instructions.</para>
    /// </remarks>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public class CryptographySettings
    {
        /// <summary>
        ///    Gets or sets all the required settings for both the deterministic and the randomized (non-deterministic) symmetric encryption.
        /// </summary>
        /// <remarks>
        ///    If not properly configured, the whole symmetric encryption/decryption functionalities will not work and exceptions will be raised if the encryption/decryption functions are required as per the consumers/developer instructions.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public SymmetricEncryption SymmetricEncryption { get; set; } = new SymmetricEncryption();

        /// <summary>
        ///    Gets or sets all the required settings for the cryptography hashing (one way encryption) settings.
        /// </summary>
        /// <remarks>
        ///    If not properly configured, the hashing (one way encryption) functionalities will not work and exceptions will be raised if the hashing function is required as per the consumers/developer instructions.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public HashingSettings Hashing { get; set; } = new HashingSettings();

        /// <summary>
        ///    Gets or sets the hash algorithm which will be used to hash the symmetric encryption key and the hash salt key.
        ///    <para>If not specified the engine will use the "<see cref="SHA512"/>" one.</para>
        /// </summary>
        /// <value>
        ///    The targeted hash algorithm which implements the "<see cref="HashAlgorithm"/>" abstract class. E.g. "<see cref="SHA256"/>", "<see cref="SHA384"/>", "<see cref="SHA512"/>", etc.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public HashAlgorithm HashAlgorithm { get; set; } = SHA512.Create();

        /// <summary>
        ///    Gets or sets a value indicating whether the generated reusable cryptography objects can be cached with the application life cycle (Singleton) or not. This is part of the first level cache.
        ///    <para>It is recommended to not disable it for performance wise unless you are pretty sure what you are doing.</para>
        /// </summary>
        /// <remarks>If the "<see cref="Interfaces.IDataAccessSettings.DisableCache"/>" is set to true, all the cache levels will be disabled including this one and will override this option.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public bool DisableCaching { get; set; }
    }
}

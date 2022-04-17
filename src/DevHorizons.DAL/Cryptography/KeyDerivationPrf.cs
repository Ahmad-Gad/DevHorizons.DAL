// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyDerivationPrf.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines the targeted the PRF which should be used for the key derivation (hash) algorithm.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    using System;

    /// <summary>
    ///    Gets or sets the targeted the PRF which should be used for the key derivation (hash) algorithm.
    /// </summary>
    /// <remarks>
    ///    The "<see cref="KeyDerivationPrf.SHA1"/>" has been comprimised for a long while and must not be used anymore for security wise.
    /// </remarks>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public enum KeyDerivationPrf
    {
        /// <summary>
        ///    The HMAC algorithm (RFC 2104) using the SHA-1 hash function (FIPS 180-4).
        /// </summary>
        [Obsolete("This hash has been comprimised for a long while and must not be used anymore for security wise.")]
        SHA1 = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA1,

        /// <summary>
        ///    The HMAC algorithm (RFC 2104) using the SHA-1 hash function (FIPS 180-4).
        /// </summary>
        SHA256 = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA256,

        /// <summary>
        ///    The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
        /// </summary>
        SHA512 = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512
    }
}

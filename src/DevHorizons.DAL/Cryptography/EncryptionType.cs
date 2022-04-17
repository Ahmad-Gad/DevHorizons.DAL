// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EncryptionType.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the encryption type.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    /// <summary>
    ///    Defines the encryption type.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public enum EncryptionType
    {
        /// <summary>
        ///    Following the default value from the "<see cref="SymmetricEncryption.DefaultEncryptionType"/>".
        /// </summary>
        Default = 0,

        /// <summary>
        ///    The encrypted data would be the same for the same source of decrypted data.
        /// </summary>
        Deterministic = 1,

        /// <summary>
        ///    The encrypted data would be randomized (non-deterministic) and won't match each time.
        /// </summary>
        Randomized = 2
    }
}

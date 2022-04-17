// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SymmetricEncryptionSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the symmetric encryption settings.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>20/02/2022 11:22 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    using System.Security.Cryptography;

    /// <summary>
    ///    Defines symmetric encryption settings.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>20/02/2022 11:22 PM</DateTime>
    /// </Created>
    public class SymmetricEncryptionSettings
    {
        /// <summary>
        ///    Gets or sets the symmetric algorithm which could be for example type of "<see cref="Aes"/>".
        ///    <para>If not specified the engine will use the "<see cref="Aes"/>" one.</para>
        /// </summary>
        /// <remarks>
        ///    If the "<see cref="EncryptionKey"/>" is not specified/set, the encryption/decryption functionalities will not work and exceptions will be raised if the encryption/decryption functions are required as per the consumers/developer instructions.
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public SymmetricAlgorithm SymmetricAlgorithm { get; set; } = Aes.Create();

        /// <summary>
        ///    Gets or sets the key which will be used for the symmetric encryption/decryption.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public string EncryptionKey { get; set; }
    }
}

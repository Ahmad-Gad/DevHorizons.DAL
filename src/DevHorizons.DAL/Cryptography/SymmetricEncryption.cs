// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SymmetricEncryption.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the symmetric encryption members.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>20/02/2022 11:22 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    /// <summary>
    ///    Defines symmetric encryption members.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>20/02/2022 11:22 PM</DateTime>
    /// </Created>
    public class SymmetricEncryption
    {
        /// <summary>
        ///    Gets or sets the required settings for the deterministic symmetric encryption.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>20/02/2022 11:22 PM</DateTime>
        /// </Created>
        public SymmetricEncryptionSettings Deterministic { get; set; } = new SymmetricEncryptionSettings();

        /// <summary>
        ///    Gets or sets the required settings for the randomized (non-deterministic) symmetric encryption.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>20/02/2022 11:22 PM</DateTime>
        /// </Created>
        public SymmetricEncryptionSettings Randomized { get; set; } = new SymmetricEncryptionSettings();

        /// <summary>
        ///    Gets or sets the default symmetric encryption type. Supports two types of encryption: randomized encryption and deterministic encryption.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        public EncryptionType DefaultEncryptionType { get; set; } = EncryptionType.Deterministic;
    }
}

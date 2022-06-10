// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ParameterAttribute.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Attributes
{
    using System;
    using Cryptography;
    using Interfaces;
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
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute, IParameterBase
    {
        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public Direction Direction { get; set; } = Direction.Input;

        /// <inheritdoc/>
        public int Size { get; set; } = -1;

        /// <inheritdoc/>
        public byte Precision { get; set; }

        /// <inheritdoc/>
        public byte Scale { get; set; }

        /// <inheritdoc/>
        public bool NotMapped { get; set; }

        /// <inheritdoc/>
        public SpecialType SpecialType { get; set; } = SpecialType.None;

        /// <inheritdoc/>
        public bool Encrypted { get; set; }

        /// <inheritdoc/>
        public bool Hashed { get; set; }

        /// <inheritdoc/>
        public bool MayBeEncrypted { get; set; }

        /// <inheritdoc/>
        public EncryptionType EncryptionType { get; set; } = EncryptionType.Default;

        /// <inheritdoc/>
        public bool Optional { get; set; }
    }
}

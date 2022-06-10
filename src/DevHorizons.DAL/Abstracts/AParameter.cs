// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AParameter.cs" company="DevHorizons">
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
namespace DevHorizons.DAL.Abstracts
{
    using System.Diagnostics.CodeAnalysis;

    using Cryptography;
    using Interfaces;
    using Shared;

    /// <summary>
    ///    A class which holds the required database's parameter members required to be injected with the stored procedure.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>07/11/2018 11:00 AM</DateTime>
    /// </Created>
    public abstract class AParameter : DataField, IParameter
    {
        #region Protected Fields

        /// <summary>
        /// The parameter's name.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:10 AM</DateTime>
        /// </Created>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Needs to be accessed by the derived classes.")]
        protected string name;
        #endregion Protected Fields

        #region Properties

        /// <inheritdoc/>
        public new string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                if (this.name != null && !this.name[0].Equals('@'))
                {
                    this.name = $"@{this.name}";
                }
            }
        }

        /// <inheritdoc/>
        public object Value { get; set; }

        /// <inheritdoc/>
        public Direction Direction { get; set; } = Direction.Input;

        /// <inheritdoc/>
        public int Size { get; set; } = -1;

        /// <inheritdoc/>
        public byte Precision { get; set; }

        /// <inheritdoc/>
        public byte Scale { get; set; }
        #endregion Properties
    }
}

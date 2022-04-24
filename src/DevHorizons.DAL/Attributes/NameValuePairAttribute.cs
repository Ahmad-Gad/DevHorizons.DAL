// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NameValuePairAttribute.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the Key/Value Pair Attribute class.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>23/04/2022 09:48 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Attributes
{
    using System;

    /// <summary>
    ///    The attribute can be added to the properties to hold the mapped name/display name of the property and the default value.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>23/04/2022 09:48 PM</DateTime>
    /// </Created>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public class NameValuePairAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="NameValuePairAttribute"/> class.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public NameValuePairAttribute()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="NameValuePairAttribute"/> class.
        /// </summary>
        /// <param name="name">The mapped the mapped key/name/display name.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public NameValuePairAttribute(string name)
        {
            this.Name = name;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the mapped the mapped key/name/display name.
        /// </summary>
        /// <value>
        ///    The mapped the mapped key/name/display name.
        /// </value>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public string Name { get; set; }

        /// <summary>
        ///    Gets or sets the default true value which would/should be assigned to the mapped property/key for the Boolean type property.
        /// </summary>
        /// <value>
        ///    The default true value which would/should be assigned to the mapped property/key.
        /// </value>
        /// <remarks>Applies only on the "Boolean" type property.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public string TrueValue { get; set; }

        /// <summary>
        ///    Gets or sets the default false value which would/should be assigned to the mapped property/key for the Boolean type property.
        /// </summary>
        /// <value>
        ///    The default false value which would/should be assigned to the mapped property/key.
        /// </value>
        /// <remarks>Applies only on the "Boolean" type property.</remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public string FalseValue { get; set; }
        #endregion Properties
    }
}

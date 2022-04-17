// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialType.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all data special types of a "<see cref="SpecialType"/>".
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>02/02/2022 06:00 PMM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    /// <summary>
    ///    Specifies the explicit special type of data column or parameter.
    /// </summary>
    /// <Created>
    ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///      <DateTime>02/02/2022 06:00 PMM</DateTime>
    /// </Created>
    public enum SpecialType
    {
        /// <summary>
        ///   Not a special data type (The defaul value).
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        None = 0,

        /// <summary>
        ///   Xml data type to be serialized/deserialized into/from collection of objects.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        Xml = 1,

        /// <summary>
        ///    Json data type to be serialized/deserialized into/from collection of objects.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        Json = 2,

        /// <summary>
        ///    Structured data type which is sent or populated by the stored procedure as "<see cref="System.Data.DataTable"/>" and expected by the stored procedure as "Table" type parameter.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        Structured = 3,

        /// <summary>
        ///    <c>BLOB</c> (Binary Large Ojbect) data type which is sent or populated by the stored procedure as array of bytes.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        Binary = 4,

        /// <summary>
        ///    <c>BLOB</c> (Binary Large Ojbect) data type which is sent or populated by the stored procedure as string in <c>Base64</c> format/encoded.
        /// </summary>
        /// <remarks>If the original data is binary (array of bytes), it will be automatically encoded into a string as <c>BASE64</c> format/encoding.</remarks>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>02/02/2022 06:00 PMM</DateTime>
        /// </Created>
        Base64 = 5
    }
}

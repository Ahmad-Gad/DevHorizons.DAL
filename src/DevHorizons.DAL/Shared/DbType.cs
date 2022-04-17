// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbType.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all data provider factor data types of a "<see cref="System.Data.DbType"/>".
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>08/11/2018 02:38 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    /// <summary>
    ///    Specifies data provider factor data type of a "<see cref="System.Data.DbType"/>".
    /// </summary>
    /// <Created>
    ///      <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///      <DateTime>08/11/2018 02:38 PM</DateTime>
    /// </Created>
    public enum DbType
    {
        /// <summary>
        ///       Auto detect the data type as possible. Otherwise, it would reset the type to the default one which is "<see cref="DbType.String"/>".
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>08/11/2018 03:53 PM</DateTime>
        /// </Created>
        Auto = -1,

        /// <summary>
        ///       A variable-length stream of non-Unicode characters ranging between 1 and 8,000
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>08/11/2018 03:53 PM</DateTime>
        /// </Created>
        AnsiString = System.Data.DbType.AnsiString,

        /// <summary>
        ///       A variable-length stream of binary data ranging between 1 and 8,000 bytes.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:51 PM</DateTime>
        /// </Created>
        Binary = System.Data.DbType.Binary,

        /// <summary>
        ///       An 8-bit unsigned integer ranging in value from 0 to 255.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:51 PM</DateTime>
        /// </Created>
        Byte = System.Data.DbType.Byte,

        /// <summary>
        ///       A simple type representing Boolean values of true or false.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:51 PM</DateTime>
        /// </Created>
        Boolean = System.Data.DbType.Boolean,

        /// <summary>
        ///       A currency value ranging from -2 63 (or -922,337,203,685,477.5808) to 2 63 -1 (or +922,337,203,685,477.5807) with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:52 PM</DateTime>
        /// </Created>
        Currency = System.Data.DbType.Currency,

        /// <summary>
        ///    A type representing a date value.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:52 PM</DateTime>
        /// </Created>
        Date = System.Data.DbType.Date,

        /// <summary>
        ///    A type representing a date and time value.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:52 PM</DateTime>
        /// </Created>
        DateTime = System.Data.DbType.DateTime,

        /// <summary>
        ///       A simple type representing values ranging from 1.0 x 10 -28 to approximately 7.9 x 10 28 with 28-29 significant digits.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:53 PM</DateTime>
        /// </Created>
        Decimal = System.Data.DbType.Decimal,

        /// <summary>
        ///    A floating point type representing values ranging from approximately 5.0 x 10 -324 to 1.7 x 10 308 with a precision of 15-16 digits.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:53 PM</DateTime>
        /// </Created>
        Double = System.Data.DbType.Double,

        /// <summary>
        ///    A globally unique identifier (or GUID).
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:53 PM</DateTime>
        /// </Created>
        Guid = System.Data.DbType.Guid,

        /// <summary>
        ///    An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:53 PM</DateTime>
        /// </Created>
        Int16 = System.Data.DbType.Int16,

        /// <summary>
        ///    An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:54 PM</DateTime>
        /// </Created>
        Int32 = System.Data.DbType.Int32,

        /// <summary>
        ///    An integral type representing signed 64-bit integers with values between -9223372036854775808 and 9223372036854775807.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:54 PM</DateTime>
        /// </Created>
        Int64 = System.Data.DbType.Int64,

        /// <summary>
        ///    A general type representing any reference or value type not explicitly represented by another <c>DbType</c> value.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:54 PM</DateTime>
        /// </Created>
        Object = System.Data.DbType.Object,

        /// <summary>
        ///    An integral type representing signed 8-bit integers with values between -128 and 127.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:54 PM</DateTime>
        /// </Created>
        SByte = System.Data.DbType.SByte,

        /// <summary>
        ///    A floating point type representing values ranging from approximately 1.5 x 10 -45 to 3.4 x 10 38 with a precision of 7 digits.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:54 PM</DateTime>
        /// </Created>
        Single = System.Data.DbType.Single,

        /// <summary>
        ///    A type representing Unicode character strings.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:55 PM</DateTime>
        /// </Created>
        String = System.Data.DbType.String,

        /// <summary>
        ///    A type representing a SQL Server DateTime value. If you want to use a SQL Server time value, use "<see cref="System.Data.SqlDbType.Time"/>".
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:55 PM</DateTime>
        /// </Created>
        Time = System.Data.DbType.Time,

        /// <summary>
        ///    An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:56 PM</DateTime>
        /// </Created>
        UInt16 = System.Data.DbType.UInt16,

        /// <summary>
        ///    An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:56 PM</DateTime>
        /// </Created>
        UInt32 = System.Data.DbType.UInt32,

        /// <summary>
        ///    An integral type representing unsigned 64-bit integers with values between 0 and 18446744073709551615.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:56 PM</DateTime>
        /// </Created>
        UInt64 = System.Data.DbType.UInt64,

        /// <summary>
        ///    A variable-length numeric value.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:56 PM</DateTime>
        /// </Created>
        VarNumeric = System.Data.DbType.VarNumeric,

        /// <summary>
        ///    A fixed-length stream of non-Unicode characters.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:56 PM</DateTime>
        /// </Created>
        AnsiStringFixedLength = System.Data.DbType.AnsiStringFixedLength,

        /// <summary>
        ///    A fixed-length string of Unicode characters.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:57 PM</DateTime>
        /// </Created>
        StringFixedLength = System.Data.DbType.StringFixedLength,

        /// <summary>
        ///    A parsed representation of an XML document or fragment.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:57 PM</DateTime>
        /// </Created>
        Xml = System.Data.DbType.Xml,

        /// <summary>
        ///    Date and time data. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:57 PM</DateTime>
        /// </Created>
        DateTime2 = System.Data.DbType.DateTime2,

        /// <summary>
        ///    Date and time data with time zone awareness. Date value range is from January 1,1 AD through December 31, 9999 AD.
        /// <para>Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.</para>
        /// <para>Time zone value range is -14:00 through +14:00.</para>
        /// </summary>
        /// <Created>
        ///       <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///       <DateTime>11/02/2020 12:58 PM</DateTime>
        /// </Created>
        DateTimeOffset = System.Data.DbType.DateTimeOffset
    }
}

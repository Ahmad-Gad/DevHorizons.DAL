// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SqlDbType.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the SQL Server allowed data types.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
//    <DateTime>07/11/2018 11:00 AM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Sql
{
    /// <summary>
    ///    Specifies SQL Server-specific data type of a SQL Parameter.
    /// </summary>
    /// <Created>
    ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///   <DateTime>08/11/2018 02:38 PM</DateTime>
    /// </Created>
    public enum SqlDbType
    {
        /// <summary>
        ///    "<see cref="long"/>". A 64-bit signed integer.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:39 PM</DateTime>
        /// </Created>
        BigInt = System.Data.SqlDbType.BigInt,

        /// <summary>
        ///    "<see cref="Array"/>" of type "<see cref="byte"/>". A fixed-length stream of binary data ranging between 1 and 8,000 bytes.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:46 PM</DateTime>
        /// </Created>
        Binary = System.Data.SqlDbType.Binary,

        /// <summary>
        ///    "<see cref="bool"/>". An unsigned numeric value that can be 0, 1, or null.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:46 PM</DateTime>
        /// </Created>
        Bit = System.Data.SqlDbType.Bit,

        /// <summary>
        ///    "<see cref="string"/>". A fixed-length stream of non-Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:47 PM</DateTime>
        /// </Created>
        Char = System.Data.SqlDbType.Char,

        /// <summary>
        ///    "<see cref="System.DateTime"/>". Date and time data ranging in value from January 1, 1753 to December 31, 9999 to an accuracy of 3.33 milliseconds.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:48 PM</DateTime>
        /// </Created>
        DateTime = System.Data.SqlDbType.DateTime,

        /// <summary>
        ///    "<see cref="decimal"/>". A fixed precision and scale numeric value between -10 38 -1 and 10 38 -1.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:50 PM</DateTime>
        /// </Created>
        Decimal = System.Data.SqlDbType.Decimal,

        /// <summary>
        ///    "<see cref="double"/>". A floating point number within the range of -1.79E +308 through 1.79E +308.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:51 PM</DateTime>
        /// </Created>
        Float = System.Data.SqlDbType.Float,

        /// <summary>
        ///    "<see cref="Array"/>" of type "<see cref="byte"/>". A variable-length stream of binary data ranging from 0 to 2 31 -1 (or 2,147,483,647) bytes.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:51 PM</DateTime>
        /// </Created>
        Image = System.Data.SqlDbType.Image,

        /// <summary>
        ///    "<see cref="int"/>". A 32-bit signed integer.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:53 PM</DateTime>
        /// </Created>
        Int = System.Data.SqlDbType.Int,

        /// <summary>
        ///    "<see cref="decimal"/>". A currency value ranging from -2 63 (or -9,223,372,036,854,775,808) to 2 63 -1 (or +9,223,372,036,854,775,807) with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:53 PM</DateTime>
        /// </Created>
        Money = System.Data.SqlDbType.Money,

        /// <summary>
        ///    "<see cref="string"/>". A fixed-length stream of Unicode characters ranging between 1 and 4,000 characters.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:54 PM</DateTime>
        /// </Created>
        NChar = System.Data.SqlDbType.NChar,

        /// <summary>
        ///    "<see cref="string"/>". A variable-length stream of Unicode data with a maximum length of 2 30 - 1 (or 1,073,741,823) characters.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:55 PM</DateTime>
        /// </Created>
        NText = System.Data.SqlDbType.NText,

        /// <summary>
        ///     string. A variable-length stream of Unicode characters ranging between
        ///     1 and 4,000 characters.
        ///     <para>Implicit conversion fails if the string is greater than
        ///     4,000 characters. Explicitly set the object when working with strings longer
        ///     than 4,000 characters.</para>
        ///     Use "<see cref="SqlDbType.NVarChar"/>" when the database column is <c>nvarchar</c>(max).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:55 PM</DateTime>
        /// </Created>
        NVarChar = System.Data.SqlDbType.NVarChar,

        /// <summary>
        ///    "<see cref="float"/>". A floating point number within the range of -3.40E +38 through 3.40E +38.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:57 PM</DateTime>
        /// </Created>
        Real = System.Data.SqlDbType.Real,

        /// <summary>
        ///    "<see cref="System.Guid"/>". A globally unique identifier (or GUID).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:57 PM</DateTime>
        /// </Created>
        UniqueIdentifier = System.Data.SqlDbType.UniqueIdentifier,

        /// <summary>
        ///    "<see cref="System.DateTime"/>". Date and time data ranging in value from January 1, 1900 to June 6, 2079 to an accuracy of one minute.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:58 PM</DateTime>
        /// </Created>
        SmallDateTime = System.Data.SqlDbType.SmallDateTime,

        /// <summary>
        ///    "<see cref="short"/>". A 16-bit signed integer.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:58 PM</DateTime>
        /// </Created>
        SmallInt = System.Data.SqlDbType.SmallInt,

        /// <summary>
        ///    "<see cref="decimal"/>". A currency value ranging from -214,748.3648 to +214,748.3647 with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:59 PM</DateTime>
        /// </Created>
        SmallMoney = System.Data.SqlDbType.SmallMoney,

        /// <summary>
        ///    "<see cref="string"/>". A variable-length stream of non-Unicode data with a maximum length of 2 31 -1 (or 2,147,483,647) characters.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 02:59 PM</DateTime>
        /// </Created>
        Text = System.Data.SqlDbType.Text,

        /// <summary>
        ///   System.Array of type byte. Automatically generated binary numbers, which are guaranteed to be unique within a database.
        ///   <para>Timestamp is used typically as a mechanism for version-stamping table rows. The storage size is 8 bytes.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:00 PM</DateTime>
        /// </Created>
        Timestamp = System.Data.SqlDbType.Timestamp,

        /// <summary>
        ///    "<see cref="byte"/>". An 8-bit unsigned integer.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:03 PM</DateTime>
        /// </Created>
        TinyInt = System.Data.SqlDbType.TinyInt,

        /// <summary>
        ///    "<see cref="System.Array"/>" of type "<see cref="byte"/>". A variable-length stream of binary data ranging between 1 and 8,000 bytes.
        ///     <para>Implicit conversion fails if the byte array is greater than 8,000 bytes.</para>
        ///     <para>Explicitly set the object when working with byte arrays larger than 8,000 bytes.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:03 PM</DateTime>
        /// </Created>
        VarBinary = System.Data.SqlDbType.VarBinary,

        /// <summary>
        ///    "<see cref="string"/>". A variable-length stream of non-Unicode characters ranging between 1 and 8,000 characters.
        /// <para>Use "<see cref="System.Data.SqlDbType.VarChar"/>" when the database column is <c>varchar</c>(max).</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:06 PM</DateTime>
        /// </Created>
        VarChar = System.Data.SqlDbType.VarChar,

        /// <summary>
        ///    "<see cref="object"/>". A special data type that can contain numeric, string, binary, or date data as well as the
        ///    SQL Server values Empty and Null, which is assumed if no other type is declared.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:07 PM</DateTime>
        /// </Created>
        Variant = System.Data.SqlDbType.Variant,

        /// <summary>
        ///    An XML value. Obtain the XML as a string using the "<see cref="Microsoft.Data.SqlClient.SqlDataReader.GetValue(int)"/>"
        ///    method or "<see cref="System.Data.SqlTypes.SqlXml.Value"/>" property, or as an "<see cref="System.Xml.XmlReader"/>"
        ///    by calling the "<see cref="System.Data.SqlTypes.SqlXml.CreateReader"/>" method.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:07 PM</DateTime>
        /// </Created>
        Xml = System.Data.SqlDbType.Xml,

        /// <summary>
        ///    A SQL Server 2005 user-defined type (UDT).
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:09 PM</DateTime>
        /// </Created>
        Udt = System.Data.SqlDbType.Udt,

        /// <summary>
        ///    A special data type for specifying structured data contained in table-valued parameters.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:09 PM</DateTime>
        /// </Created>
        Structured = System.Data.SqlDbType.Structured,

        /// <summary>
        ///    Date data ranging in value from January 1,1 AD through December 31, 9999 AD.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:10 PM</DateTime>
        /// </Created>
        Date = System.Data.SqlDbType.Date,

        /// <summary>
        ///    Time data based on a 24-hour clock. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Corresponds to a SQL Server time value.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:10 PM</DateTime>
        /// </Created>
        Time = System.Data.SqlDbType.Time,

        /// <summary>
        ///    Date and time data. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:11 PM</DateTime>
        /// </Created>
        DateTime2 = System.Data.SqlDbType.DateTime2,

        /// <summary>
        ///    Date and time data with time zone awareness. Date value range is from January 1,1 AD through December 31, 9999 AD.
        ///    <para>Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range is -14:00 through +14:00.</para>
        /// </summary>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:12 PM</DateTime>
        /// </Created>
        DateTimeOffset = System.Data.SqlDbType.DateTimeOffset
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionSettings.cs" company="DevHorizons">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <summary>
//    Defines all the SQL Server connection/access related settings.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <DateTime>26/12/2021 05:00 PM</DateTime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Sql
{
    using DAL.Attributes;

    /// <summary>
    ///    Defines all the SQL Server connection/access related settings.
    ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax"/></para>  
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>26/12/2021 05:00 PM</DateTime>
    /// </Created>
    public class SqlConnectionSettings : ConnectionSettings
    {
        /// <summary>
        ///    Gets or sets the size (in bytes) of network packets used to communicate with an instance of SQL Server.
        ///    <para>The Default Value: <c>Null</c>.</para>
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.packetsize?view=dotnet-plat-ext-6.0"/></para>
        /// </summary>
        /// <value>The size (in bytes) of network packets. The default value is 8000.</value>
        /// <remarks>
        ///    PacketSize may be a value in the range of 512 and 32767 bytes. An exception is generated if the value is outside this range.
        ///    <para>If an application performs bulk copy operations, or sends or receives lots of text or image data, a packet size larger than the default may improve efficiency because it causes fewer network read and write operations.</para>
        ///    <para>If an application sends and receives small amounts of information, you can set the packet size to 512 bytes (using the Packet Size value in the ConnectionString), which is sufficient for most data transfer operations.</para>
        ///    <para>For most applications, the default packet size is best.</para>
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        [NameValuePair("Packet Size")]
        public int? PacketSize { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the opened connection will support the "SQL Column Always Encrypted".
        ///    <para>The Default Value: <c>false</c>.</para>
        ///    <para><see href="https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/always-encrypted-database-engine?view=sql-server-ver15"/></para>
        /// </summary>
        /// <remarks>
        ///    This setting will be merged with the provided connection string and will override the same setting if exist.
        ///    <para>Supported with SQL Server 2016 (13.x), and higher.</para>
        ///    <para>Always Encrypted is available in all editions of Azure SQL Database, starting with SQL Server 2016 (13.x) and all service tiers of SQL Database. (Prior to SQL Server 2016 (13.x) SP1, Always Encrypted was limited to the Enterprise Edition.)</para>
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        [NameValuePair(Name ="Column Encryption Setting", TrueValue = "Enabled", FalseValue = "Disabled")]
        public bool? ColumnAlwaysEncryptedSettingEnabled { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the connection between the client and the server is encrypted.
        ///    <para><see href="https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/enable-encrypted-connections-to-the-database-engine?view=sql-server-ver15"/></para>
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax"/></para>
        /// </summary>
        /// <remarks>
        ///    Starting with SQL Server 2016 (13.x), Secure Sockets Layer (SSL) has been discontinued. Use Transport Layer Security (TLS) instead.
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 07:52 PM</DateTime>
        /// </Created>
        [NameValuePair("Encrypt")]
        public bool? Encrypted { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether the client connection should trust the server certificate regardless the certificate condition by skiping the trust chain validation process.
        /// </summary>
        /// <remarks>
        ///    If you use TrustServerCertificate=true (or its equivalent) in the connection string, the connection process skips the trust chain validation. In this case, the application connects even if the certificate can't be verified. Using TrustServerCertificate=false enforces certificate validation and is a best practice.
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 07:52 PM</DateTime>
        /// </Created>
        [NameValuePair("TrustServerCertificate")]
        public bool? TrustServerCertificate { get; set; }

        /// <summary>
        ///    Gets or sets the URL for attestation the server-side enclaves. This setting will be applicable only if the "SQL Column Always Encrypted" is enabled either manually through the provided connection string or by setting the "<see cref="ColumnAlwaysEncryptedSettingEnabled"/>" to "<c>true</c>".
        ///    <para><see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.connectionstring?view=sqlclient-dotnet-standard-4.1"/></para>   
        ///    <para><see href="https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/always-encrypted-enclaves?view=sql-server-ver15"/></para>
        /// </summary>
        /// <remarks>
        ///     Always Encrypted with secure enclaves is available in SQL Server 2019 (15.x) or higher and in Azure SQL Database.
        ///    <para>This setting will be merged with the provided connection string and will override the same setting if exists.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>26/12/2021 05:00 PM</DateTime>
        /// </Created>
        [NameValuePair("Enclave Attestation Url")]
        public string EnclaveAttestationUrl { get; set; }
    }
}

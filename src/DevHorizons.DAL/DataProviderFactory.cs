// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataProviderFactory.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines all the accepted Data Provider Factories for the data connection.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System.ComponentModel;
    using Attributes;

    /// <summary>
    ///     The Data Provider Factory name for the data connection.
    ///     Note: Only the "Microsoft.Data.SqlClient" library for the "<see cref="DataProviderFactory.Sql"/>" Data Provider Factory is implemented and tested so far. And you would need to make sure the implemented provider factory is added.
    /// </summary>
    /// <created>
    ///    <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
    ///    <datetime>03/07/2019 07:44 PM</datetime>
    /// </created>
    [DefaultValue(None)]
    public enum DataProviderFactory
    {
        /// <summary>
        ///    The provider factory is not yet set.
        /// </summary>
        None = 0,

        /// <summary>
        ///    The <c>Microsoft SQL Server's Client</c> Data Provider Factory integrated with the official Microsoft "Microsoft.Data.SqlClient" library.
        /// </summary>
        [ProviderFactoryDetails(Name = "Microsoft.Data.SqlClient", FactoryClassName = "Microsoft.Data.SqlClient.SqlClientFactory", AssemblyName = "Microsoft.Data.SqlClient")]
        Sql = 1,

        /// <summary>
        ///    The <c>OLEDB</c> Data Provider Factory integrated with the official Microsoft "System.Data.OleDb" library.
        /// </summary>
        [Description("System.Data.OleDb.OleDbFactory")]
        [ProviderFactoryDetails(Name = "System.Data.OleDb", FactoryClassName = "System.Data.OleDb.OleDbFactory", AssemblyName = "System.Data.OleDb")]
        Oledb = 2,

        /// <summary>
        ///    The <c>ODBC</c> Data Provider Factory integrated with the official Microsoft "System.Data.Odbc" library.
        /// </summary>
        [ProviderFactoryDetails(Name = "System.Data.Odbc", FactoryClassName = "System.Data.Odbc.OdbcFactory", AssemblyName = "System.Data.Odbc")]
        Odbc = 3,

        /// <summary>
        ///    The <c>Oracle Client</c> Data Provider Factory integrated with the official Oracle "Oracle.ManagedDataAccess" library.
        /// </summary>
        [Description("Oracle.ManagedDataAccess.Client.OracleClientFactory")]
        [ProviderFactoryDetails(Name = "Oracle.ManagedDataAccess.Client", FactoryClassName = "Oracle.ManagedDataAccess.Client.OracleClientFactory", AssemblyName = "Oracle.ManagedDataAccess")]
        Oracle = 4,

        /// <summary>
        ///    The <c>MySql Client</c> Data Provider Factory integrated with the official Oracle "MySql.Data" library.
        /// </summary>
        [Description("MySql.Data.MySqlClient.MySqlClientFactory")]
        [ProviderFactoryDetails(Name = "MySql.Data.MySqlClient", FactoryClassName = "MySql.Data.MySqlClient.MySqlClientFactory", AssemblyName = "MySql.Data")]
        MySql = 5,

        /// <summary>
        ///    The <c>Sqlite</c> Data Provider Factory integrated with the official Microsoft "Microsoft.Data.Sqlite" library.
        /// </summary>
        [Description("Microsoft.Data.Sqlite.SqliteFactory")]
        [ProviderFactoryDetails(Name = "Microsoft.Data.Sqlite", FactoryClassName = "Microsoft.Data.Sqlite.SqliteFactory", AssemblyName = "Microsoft.Data.Sqlite")]
        Sqlite = 6,

        /// <summary>
        ///    The <c>DB2</c> Data Provider Factory integrated with the official IBM "IBM.Data.DB2.Core" library.
        /// </summary>
        [Description("IBM.Data.DB2.DB2Factory")]
        [ProviderFactoryDetails(Name = "IBM.Data.DB2.Core", FactoryClassName = "IBM.Data.DB2.Core.DB2Factory", AssemblyName = "IBM.Data.DB2.Core")]
        DB2 = 7,

        /// <summary>
        ///    The <c>Teradata</c> Data Provider Factory integrated with the official Teradata "Teradata.Client.Provider" library.
        /// </summary>
        [Description("Teradata.Client.Provider.TdFactory")]
        [ProviderFactoryDetails(Name = "Teradata.Client.Provider", FactoryClassName = "Teradata.Client.Provider.TdFactory", AssemblyName = "Teradata.Client.Provider")]
        Teradata = 8,

        /// <summary>
        ///    The <c>PostgreSQL</c> Data Provider Factory integrated with the official "<c>pgSQL</c>" ("<c>Npgsql</c>") library.
        /// </summary>
        [Description("Npgsql.NpgsqlFactory")]
        [ProviderFactoryDetails(Name = "Npgsql", FactoryClassName = "Npgsql.NpgsqlFactory", AssemblyName = "Npgsql")]
        PostgreSQL = 9,

        /// <summary>
        ///    The <c>Snowflake</c> Data Provider Factory integrated with the official pgSQL "Snowflake.Data" library.
        /// </summary>
        [Description("Snowflake.Data.Client.SnowflakeDbFactory")]
        [ProviderFactoryDetails(Name = "Snowflake.Data.Client", FactoryClassName = "Snowflake.Data.Client.SnowflakeDbFactory", AssemblyName = "Snowflake.Data")]
        Snowflake = 10,

        /// <summary>
        ///    The "SAP Adaptive Server Enterprise (Sybase)" Data Provider Factory.
        /// </summary>
        /// <remarks>
        ///    This is not an offical "<c>SAP</c>" package becase <c>SAP</c>SAP has not yet release a ADO.NET driver/client to support .NET Core/Standard.
        ///    <para><see href="https://github.com/DataAction/AdoNetCore.AseClient"/></para>
        /// </remarks>
        [Description("AdoNetCore.AseClient.AseClientFactory")]
        [ProviderFactoryDetails(Name = "AdoNetCore.AseClient", FactoryClassName = "AdoNetCore.AseClient.AseClientFactory", AssemblyName = "AdoNetCore.AseClient")]
        ASE = 11
    }
}

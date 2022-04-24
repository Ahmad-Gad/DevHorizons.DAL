// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ConnectionStringBuilder.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines all the needed extension/static methods to build/update/extract the data source (RDBMS server) connection string.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///    Static class holds all the needed extension/static methods to build/update/extract the data source (RDBMS server) connection string.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>23/04/2022 10:19 PM</DateTime>
    /// </Created>
    public static class ConnectionStringBuilder
    {
        /// <summary>
        ///    The connection string properties/values of data source (RDBMS server) extracted a key value pairs in dictionary.
        /// </summary>
        /// <param name="connectionString">The connection string of a data source (RDBMS server).</param>
        /// <returns>
        ///    Dictionary represents the properties/values of data source (RDBMS server) extracted a key value pairs in dictionary "<see cref="Dictionary{TKey, TValue}"/>" ; where "<c>TKey</c>" is string and "<c>TValue</c>" is string.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 10:19 PM</DateTime>
        /// </Created>
        public static IDictionary<string, string> ExtractConnectionString(string connectionString)
        {
            const char SEPARATOR = ';';
            const char EQUAL = '=';

            var dic = new Dictionary<string, string>();
            var conStringProps = connectionString.Trim(SEPARATOR).Split(SEPARATOR);
            foreach (var prop in conStringProps)
            {
                var keyPairValue = prop.Split(EQUAL);
                dic.Add(keyPairValue[0].Trim(), keyPairValue[1].Trim());
            }

            return dic;
        }

        /// <summary>
        ///    The connection string of data source (RDBMS server) extracted from a key value pairs in dictionary.
        /// </summary>
        /// <param name="connectionStringDic">The connection string of a data source (RDBMS server) key value pairs in dictionary "<see cref="Dictionary{TKey, TValue}"/>" ; where "<c>TKey</c>" is string and "<c>TValue</c>" is string..</param>
        /// <returns>
        ///     The connection string of data source (RDBMS server).
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 10:19 PM</DateTime>
        /// </Created>
        public static string ExtractConnectionString(IDictionary<string, string> connectionStringDic)
        {
            const char SEPARATOR = ';';
            const char EQUAL = '=';

            var connectionString = new System.Text.StringBuilder();
            foreach (var prop in connectionStringDic)
            {
                connectionString.Append($"{prop.Key.Trim()}{EQUAL}{prop.Value.Trim()}{SEPARATOR}");
            }

            return connectionString.ToString();
        }

        /// <summary>
        ///    Update the connection string with the specified advanced options within the specified settings.
        /// </summary>
        /// <param name="connectionSettings">The connection settings as an instance of "<see cref="IConnectionSettings"/>".</param>
        /// <remarks>
        ///    You may not need to use this method because it is managed/executed automatically when you register the <c>DAL</c> service/engine by the DI containers which is usually done by calling the "<see cref="RegisterSqlDal(IServiceCollection, IDataAccessSettings)"/>" method.
        ///    <para>You may only use it, if you are not using DI containers/services which could be the case of desktop application or some class library which not meant to serve web applications/APIs.</para>
        /// </remarks>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>01/02/2022 09:45 PM</DateTime>
        /// </Created>
        public static void UpdateConnectionString(this IConnectionSettings connectionSettings)
        {
            if (connectionSettings == null || string.IsNullOrWhiteSpace(connectionSettings.ConnectionString))
            {
                return;
            }

            var settingsDic = connectionSettings.GetNameValueProperties();
            if (settingsDic.Count == 0)
            {
                return;
            }

            var extractedConnectionStringDic = ExtractConnectionString(connectionSettings.ConnectionString);

            foreach (var setting in settingsDic)
            {
                var key = extractedConnectionStringDic.Keys.FirstOrDefault(k => k.Equals(setting.Key, StringComparison.OrdinalIgnoreCase));

                if (key is not null)
                {
                    extractedConnectionStringDic[key] = setting.Value?.ToString();
                }
                else
                {
                    extractedConnectionStringDic.Add(setting.Key, setting.Value?.ToString());
                }
            }

            var newConnectionString = ExtractConnectionString(extractedConnectionStringDic);
            connectionSettings.ConnectionString = newConnectionString;
        }
    }
}

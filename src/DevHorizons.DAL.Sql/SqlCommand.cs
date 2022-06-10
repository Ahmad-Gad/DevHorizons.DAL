// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Command.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed members for the <c>SQL</c> Command class which implements the abstraction class "<see cref="DAL.Abstracts.Command"/>".
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Sql
{
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.Data.SqlClient;
    using System.Data.Common;
    using Interfaces;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Cache;
    using Shared;


    /// <summary>
    ///    A class holds all the needed members for the <c>SQL</c> Command class which implements the abstraction class "<see cref="Abstracts.ACommand"/>".
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 12:05 AM</DateTime>
    /// </Created>
    /// <seealso cref="Abstracts.ACommand" />
    public sealed class SqlCommand : Abstracts.ACommand
    {
        #region Constructors
        /*
#if NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0
        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlCommand"/> class.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <param name="logger">The logger object of the type "<see cref="ILogger"/>" which could be registered by the Dependency Injection.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:03 PM</DateTime>
        /// </Created>
        public SqlCommand(IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, ILogger<SqlCommand> logger)
                : base(DataProviderFactory.Sql, dataAccessSettings, memoryCache, logger)
        {
        }
#endif
        */

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlCommand"/> class.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <param name="logger">The logger object of the type "<see cref="ILogger"/>" which could be registered by the Dependency Injection.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:03 PM</DateTime>
        /// </Created>
        public SqlCommand(IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, ILogger<SqlCommand> logger)
                : base(SqlClientFactory.Instance, dataAccessSettings, memoryCache, logger)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlCommand"/> class.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:03 PM</DateTime>
        /// </Created>
        public SqlCommand(IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache)
            : this(dataAccessSettings, memoryCache, null)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlCommand"/> class.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="logger">The logger object of the type "<see cref="ILogger"/>" which could be registered by the Dependency Injection.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:03 PM</DateTime>
        /// </Created>
        public SqlCommand(IDataAccessSettings dataAccessSettings, ILogger<SqlCommand> logger)
            : this(dataAccessSettings, null, logger)
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="SqlCommand"/> class.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>02/11/2018 05:03 PM</DateTime>
        /// </Created>
        public SqlCommand(IDataAccessSettings dataAccessSettings)
            : this(dataAccessSettings, null, null)
        {
        }
        #endregion Constructors

        #region Protected Override Methods

        /// <summary>
        ///    Maps data type for the implemented provider factory which overrides the virtual one in the parent class "<see cref="Abstracts.ACommand"/>" to map the data type that match the <c>SQL</c> provider factory.
        /// </summary>
        /// <param name="dbParameter">The database parameter as an instance of "<see cref="DbParameter" />" or any class that implements it.</param>
        /// <param name="parameter">The parameter as an instance of a class that implements "<see cref="IDataField" />".</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:07 AM</DateTime>
        /// </Created>
        /// <Created>
        ///   <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///   <DateTime>10/02/2020 11:08 PM</DateTime>
        /// </Created>
        protected override void MapDataType(DbParameter dbParameter, IParameter parameter)
        {
            if (dbParameter is null || parameter is null)
            {
                return;
            }

            if (dbParameter is not Microsoft.Data.SqlClient.SqlParameter sqlParameter)
            {
                var parameterDetails = $"{{'Name':'{dbParameter.ParameterName}', 'Direction':'{dbParameter.Direction}', 'Type':'{dbParameter.DbType}' }}";
                var description = $"Failed to map the data type for {parameterDetails}";
                var error = this.Settings.CreateErrorDetails(
                    stackTrace: Environment.StackTrace,
                    source: $"{this.GetType().FullName}.{nameof(MapDataType)}DbParameter dbParameter, IParameter parameter)",
                    message: $"The sepcified parameter is not type of ({typeof(Microsoft.Data.SqlClient.SqlParameter).FullName}).",
                    description: description,
                    errorNumber: -701
                    );
                this.HandleError(error);
                throw new Exception(description);
            }

            if (parameter is not SqlParameter dalSqlParameter)
            {
                var parameterDetails = $"{{'Name':'{parameter.Name}', 'Direction':'{parameter.Direction}', 'PropertyName':'{parameter.Property?.Name}',, 'PropertyType':'{parameter.Property?.PropertyType}' }}";
                var description = $"Failed to map the data type for {parameterDetails}";
                var error = this.Settings.CreateErrorDetails(
                    stackTrace: Environment.StackTrace,
                    source: $"{this.GetType().FullName}.{nameof(MapDataType)}(DbParameter dbParameter, IParameter parameter)",
                    message: $"The sepcified parameter is not type of ({typeof(SqlParameter).FullName}).",
                    description: description,
                    errorNumber: -702
                    );
                this.HandleError(error);
                throw new Exception(description);
            }

            if (dalSqlParameter.DataType is null)
            {
                var parameterDetails = $"{{'Name':'{dalSqlParameter.Name}', 'Direction':'{dalSqlParameter.Direction}', 'Type':'{dalSqlParameter.DataType}', 'PropertyName':'{dalSqlParameter?.Property?.Name}',, 'PropertyType':'{dalSqlParameter?.Property?.PropertyType}' }}";
                var description = $"Failed to map the data type for {parameterDetails}";
                var error = this.Settings.CreateErrorDetails(
                    stackTrace: Environment.StackTrace,
                    source: $"{this.GetType().FullName}.{nameof(MapDataType)}(DbParameter dbParameter, IParameter parameter)",
                    message: "Failed to map the data type because it is null!",
                    description: description,
                    errorNumber: -703
                    );
                this.HandleError(error);
                throw new Exception(description);
            }

            sqlParameter.SqlDbType = (System.Data.SqlDbType)dalSqlParameter.DataType;
        }

        /// <summary>
        ///    Gets the parameters from dictionary as <see cref="List{T}"/> of <see cref="IDataField"/>.
        /// </summary>
        /// <param name="parameters">The parameters as <see cref="Dictionary{TKey, TValue}"/> where <c>"TKey"</c> is <see cref="string"/> and <c>"TValue"</c> is <see cref="object"/>.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IDataField"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:03 PM</DateTime>
        /// </Created>
        protected override List<IParameter> GetParmetersFromDictionary(Dictionary<string, object> parameters)
        {
            var list = new List<IParameter>();
            if (parameters == null)
            {
                return list;
            }

            foreach (var pair in parameters)
            {
                var par = new SqlParameter(pair.Key, pair.Value);
                list.Add(par);
            }

            return list;
        }

        /// <summary>
        ///    Extracts the list of the parameters from the specified command body as type of of <see cref="ICommandBody"/>.
        /// </summary>
        /// <param name="commandBody">The request/command buddy which holds the stored procedure name and the designated parameters.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IDataField"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>01/02/2022 09:45 PM</DateTime>
        /// </Created>
        protected override List<IParameter> GetParmetersFromCommandBody(ICommandBody commandBody)
        {
            return commandBody.GetParmetersFromCommandBody();
        }

        /// <summary>
        ///    Update the property with the correct type, value and size based on the parameter direction, assigned values, data type and the sepcial type.
        /// </summary>
        /// <param name="parameter">The <c>DAL</c> engine parameter.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:13 AM</DateTime>
        /// </Created>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        protected override void UpdateParameter(IParameter parameter)
        {
            var dalSqlParameter = parameter as SqlParameter;

            if (dalSqlParameter.Direction == Direction.ReturnValue)
            {
                dalSqlParameter.DataType = SqlDbType.Int;
            }
            else
            {
                if (dalSqlParameter.Direction != Direction.Output && dalSqlParameter.Value.IsConcreteClass() && dalSqlParameter.DataType != SqlDbType.Structured && dalSqlParameter.SpecialType != SpecialType.Structured)
                {
                    var subDataFields = dalSqlParameter.Value.GetDataFieldList(this.Settings, this.MemoryCache, this.HandleError, Internal.CacheCategory.DataField);
                    dalSqlParameter.Value.UpdateDataRowObject(subDataFields, dalSqlParameter.SpecialType, DataDirection.Outbound, this.Settings, this.MemoryCache, this.HandleError, true);
                }

                if (dalSqlParameter.SpecialType == SpecialType.Json)
                {
                    dalSqlParameter.DataType = SqlDbType.NVarChar;
                    dalSqlParameter.Size = -1;
                    if (dalSqlParameter.Value != null && dalSqlParameter.Direction != Direction.Output && dalSqlParameter.Value is not string)
                    {
                        dalSqlParameter.Value = JsonConvert.SerializeObject(dalSqlParameter.Value);
                    }
                }
                else if (dalSqlParameter.DataType == SqlDbType.Xml || dalSqlParameter.SpecialType == SpecialType.Xml)
                {
                    dalSqlParameter.DataType = SqlDbType.Xml;
                    if (dalSqlParameter.Direction != Direction.Output && dalSqlParameter.Value is not string)
                    {
                        dalSqlParameter.Value = dalSqlParameter.Value.ToXmlString();
                    }
                }
                else if (dalSqlParameter.DataType == SqlDbType.Structured || dalSqlParameter.SpecialType == SpecialType.Structured)
                {
                    dalSqlParameter.DataType = SqlDbType.Structured;

                    if (dalSqlParameter.Direction != Direction.Output && !dalSqlParameter.Value.IsDataTable())
                    {
                        dalSqlParameter.Value = dalSqlParameter.Value.ToStructuredDbType(this.Settings, this.MemoryCache, this.HandleError);
                    }
                }
                else if (dalSqlParameter.DataType == SqlDbType.VarBinary || dalSqlParameter.SpecialType == SpecialType.Binary)
                {
                    dalSqlParameter.DataType = SqlDbType.VarBinary;
                    dalSqlParameter.Size = -1;
                    if (dalSqlParameter.Direction != Direction.Output && dalSqlParameter.Value != null && dalSqlParameter.Value is not ICollection<byte>)
                    {
                        if (dalSqlParameter.Value is string)
                        {
                            dalSqlParameter.Value = Convert.FromBase64String(dalSqlParameter.Value.ToString());
                        }
                        else
                        {
                            dalSqlParameter.Value = dalSqlParameter.Value.ToBinary();
                        }

                    }
                }
                else if (dalSqlParameter.SpecialType == SpecialType.Base64)
                {
                    dalSqlParameter.DataType = SqlDbType.NVarChar;
                    dalSqlParameter.Size = -1;

                    if (dalSqlParameter.Direction != Direction.Output && dalSqlParameter.Value != null && dalSqlParameter.Value is not string)
                    {
                        if (dalSqlParameter.Value is ICollection<byte>)
                        {
                            dalSqlParameter.Value = Convert.ToBase64String((byte[])dalSqlParameter.Value);
                        }
                        else
                        {
                            dalSqlParameter.Value = dalSqlParameter.Value.ToBase64String();
                        }
                    }
                }
                else if (dalSqlParameter.DataType is null)
                {
                    this.SetParameterAutoType(parameter);
                }
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        /// <summary>
        ///    Sets the type of the parameter automatically.
        /// </summary>
        /// <param name="parameter">The specified parameter.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>08/11/2018 03:56 PM</DateTime>
        /// </Created>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        protected override void SetParameterAutoType(IParameter parameter)
        {
            var dalSqlParameter = parameter as SqlParameter;

            Type type = null;
            if (dalSqlParameter.Property != null)
            {
                type = Nullable.GetUnderlyingType(dalSqlParameter.Property.PropertyType) ?? (dalSqlParameter.Property.PropertyType);
            }

            if (dalSqlParameter.Value != null && dalSqlParameter.SpecialType != SpecialType.None)
            {
                dalSqlParameter.Size = -1;
                parameter.Size = -1;

                if (dalSqlParameter.Direction != Direction.Output)
                {
                    switch (dalSqlParameter.SpecialType)
                    {
                        case SpecialType.Json:
                            {
                                dalSqlParameter.DataType = SqlDbType.NVarChar;
                                if (dalSqlParameter.Value is not string)
                                {
                                    dalSqlParameter.Value = JsonConvert.SerializeObject(dalSqlParameter.Value);
                                }

                                break;
                            }

                        case SpecialType.Xml:
                            {
                                if (dalSqlParameter.Value is not string)
                                {
                                    dalSqlParameter.Value = dalSqlParameter.Value.ToXmlString();
                                }

                                dalSqlParameter.DataType = SqlDbType.NVarChar;
                                break;
                            }

                        case SpecialType.Structured:
                            {
                                dalSqlParameter.DataType = SqlDbType.Structured;
                                if (!dalSqlParameter.Value.IsDataTable())
                                {
                                    dalSqlParameter.Value = dalSqlParameter.Value.ToStructuredDbType(this.Settings, this.MemoryCache, this.HandleError);
                                }

                                break;
                            }

                        case SpecialType.Binary:
                            {
                                dalSqlParameter.DataType = SqlDbType.VarBinary;
                                if (dalSqlParameter.Value is not string)
                                {
#pragma warning disable CS8604 // Possible null reference argument.
                                    dalSqlParameter.Value = Convert.FromBase64String(dalSqlParameter.Value.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                                }

                                break;
                            }

                        case SpecialType.Base64:
                            {
                                dalSqlParameter.DataType = SqlDbType.NVarChar;
                                if (dalSqlParameter.Value is ICollection<byte>)
                                {
                                    dalSqlParameter.Value = Convert.ToBase64String((byte[])dalSqlParameter.Value);
                                }
                                break;
                            }
                    }
                }
            }
            else if (dalSqlParameter.Value is string || (type != null && type == typeof(string)))
            {
                dalSqlParameter.DataType = SqlDbType.NVarChar;
                var size = dalSqlParameter.Value == null ? 1 : dalSqlParameter.Value.ToString().Length;
                dalSqlParameter.Size = size;
                parameter.Size = size;
            }
            else if (dalSqlParameter.Value is bool || (type != null && type == typeof(bool)))
            {
                dalSqlParameter.DataType = SqlDbType.Bit;
            }
            else if (dalSqlParameter.Value is int || dalSqlParameter.Value is ushort || (type != null && (type == typeof(int) || type == typeof(ushort))))
            {
                dalSqlParameter.DataType = SqlDbType.Int;
            }
            else if (dalSqlParameter.Value is short || (type != null && type == typeof(short)))
            {
                dalSqlParameter.DataType = SqlDbType.SmallInt;
            }
            else if (dalSqlParameter.Value is char || (type != null && type == typeof(char)))
            {
                dalSqlParameter.DataType = SqlDbType.NVarChar;
                dalSqlParameter.Size = 1;
            }
            else if (dalSqlParameter.Value is TimeSpan || (type != null && type == typeof(TimeSpan)))
            {
                dalSqlParameter.DataType = SqlDbType.Time;
            }
            else if (dalSqlParameter.Value is byte || dalSqlParameter.Value is sbyte || (type != null && (type == typeof(byte) || type == typeof(sbyte))))
            {
                dalSqlParameter.DataType = SqlDbType.TinyInt;
            }
            else if (dalSqlParameter.Value is long || dalSqlParameter.Value is uint || (type != null && (type == typeof(long) || type == typeof(uint))))
            {
                dalSqlParameter.DataType = SqlDbType.BigInt;
            }
            else if (dalSqlParameter.Value is double || (type != null && type == typeof(double)))
            {
                dalSqlParameter.DataType = SqlDbType.Float;
            }
            else if (dalSqlParameter.Value is float || (type != null && type == typeof(float)))
            {
                dalSqlParameter.DataType = SqlDbType.Real;
            }
            else if (dalSqlParameter.Value is decimal || dalSqlParameter.Value is ulong || (type != null && type == typeof(decimal)) || (type != null && type == typeof(ulong)))
            {
                dalSqlParameter.DataType = SqlDbType.Decimal;
            }
            else if (dalSqlParameter.Value is DateTime || (type != null && type == typeof(DateTime)))
            {
                dalSqlParameter.DataType = SqlDbType.DateTime;
            }
            else if (dalSqlParameter.Value is Guid || (type != null && type == typeof(Guid)))
            {
                dalSqlParameter.DataType = SqlDbType.UniqueIdentifier;
            }
            else if (dalSqlParameter.Value is ICollection<byte> || (type != null && type == typeof(byte[])))
            {
                dalSqlParameter.DataType = SqlDbType.VarBinary;
                dalSqlParameter.Size = -1;
            }
            else if (dalSqlParameter.Value is DataTable)
            {
                dalSqlParameter.DataType = SqlDbType.Structured;
            }
            else if (dalSqlParameter.Value.IsSerializableType() && dalSqlParameter.DataType is null)
            {
                dalSqlParameter.DataType = SqlDbType.Structured;

                if (!dalSqlParameter.Value.IsDataTable())
                {
                    dalSqlParameter.Value = dalSqlParameter.Value.ToStructuredDbType(this.Settings, this.MemoryCache, this.HandleError);
                }
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        #endregion Protected Override Methods
    }
}

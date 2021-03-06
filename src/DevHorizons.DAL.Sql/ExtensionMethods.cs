// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionMethods.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
//    <DateTime>01/02/2022 09:45 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Sql
{
    using System.Reflection;
    using Attributes;
    using Cache;
    using DAL.Attributes;

    using Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///    A public static class which holds all the extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>01/02/2022 09:45 PM</DateTime>
    /// </Created>
    public static class ExtensionMethods
    {
        #region Public Methods
        /// <summary>
        ///    Register the <c>SQL</c> <c>DAL</c> service into the dependency injection <c>(DI)</c> container with the scoped life cycle.
        /// </summary>
        /// <param name="services">The contract for a collection of service descriptors.</param>
        /// <param name="settings">The data access settings of the type "<see cref="IDataAccessSettings"/>"</param>
        /// <returns>The contract for a collection of service descriptors which is used in the WebApis DI.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>01/02/2022 09:45 PM</DateTime>
        /// </Created>
        public static IServiceCollection RegisterSqlDal(this IServiceCollection services, IDataAccessSettings settings)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), $"The '{nameof(RegisterSqlDal)}' failed because it doesn't expect null argument.");
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings), $"The '{nameof(RegisterSqlDal)}' failed because it doesn't expect null argument.");
            }

            if (!settings.CacheSettings.Disabled)
            {
                var memoryCache = new MemoryCache();
                services.AddSingleton<IMemoryCache, MemoryCache>();
            }

            services.AddSingleton((s) => { return settings; });
            services.AddScoped<ICommand, SqlCommand>();

            return services;
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        ///    Extracts the list of the parameters from the specified command body as type of of <see cref="ICommandBody"/>.
        /// </summary>
        /// <param name="commandBody">The request/command buddy which holds the stored procedure name and the designated parameters.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="IParameter"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/02/2020 11:03 PM</DateTime>
        /// </Created>
        internal static List<IParameter> GetParmetersFromCommandBody(this ICommandBody commandBody)
        {
            var type = commandBody.GetType();
            var parameters = new List<IParameter>();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var parameterAttributeObject = prop.GetCustomAttributes(true).FirstOrDefault(a => a is ParameterAttribute);
                var param = new SqlParameter
                {
                    Name = prop.Name,
                    Direction = Shared.Direction.Input
                };

                if (parameterAttributeObject != null)
                {
                    //var dalParameterAttribute = parameterAttribute is SqlParameterAttribute sqlParamAttribute ? sqlParamAttribute : (DAL.Attributes.ParameterAttribute)parameterAttribute;
                    var parameterAttribute = (ParameterAttribute)parameterAttributeObject;

                    if (parameterAttribute.NotMapped)
                    {
                        continue;
                    }

                    param.SetPropertyInfo(prop);
                    if (parameterAttribute.Direction == Shared.Direction.ReturnValue)
                    {
                        param.Name = $"R{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
                        param.DataType = SqlDbType.Int;
                        param.Direction = Shared.Direction.ReturnValue;

                        parameters.Add(param);
                        continue;
                    }


                    param.Encrypted = parameterAttribute.Encrypted;
                    param.MayBeEncrypted = parameterAttribute.MayBeEncrypted;
                    param.Hashed = parameterAttribute.Hashed;
                    param.EncryptionType = parameterAttribute.EncryptionType;
                    param.Precision = parameterAttribute.Precision;
                    param.Scale = parameterAttribute.Scale;
                    param.DataType = ((SqlParameterAttribute)parameterAttribute).Type;
                    param.Direction = parameterAttribute.Direction;
                    if (string.IsNullOrWhiteSpace(parameterAttribute.Name))
                    {
                        param.Name = prop.Name;
                    }
                    else
                    {
                        param.Name = parameterAttribute.Name;
                    }

                    switch (parameterAttribute.SpecialType)
                    {
                        case Shared.SpecialType.Base64:
                        case Shared.SpecialType.Json:
                            {
                                param.DataType = SqlDbType.NVarChar;
                                param.Size = -1;
                                break;
                            }

                        case Shared.SpecialType.Xml:
                            {
                                param.DataType = SqlDbType.Xml;
                                param.Size = -1;
                                break;
                            }

                        case Shared.SpecialType.Structured:
                            {
                                param.DataType = SqlDbType.Structured;
                                break;
                            }

                        case Shared.SpecialType.Binary:
                            {
                                param.DataType = SqlDbType.VarBinary;
                                param.Size = -1;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }


                if (param.Direction != Shared.Direction.Output)
                {
                    var value = prop.GetValue(commandBody);
                    param.Value = value;
                }

                parameters.Add(param);
            }

            return parameters;
        }
        #endregion Internal Methods
    }
}

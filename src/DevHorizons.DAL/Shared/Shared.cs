// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Shared.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//      Defines the needed shared/static and extension methods which will serve the whole library internally.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Attributes;
    using Cache;
    using Cryptography;
    using Interfaces;
    using Internal;
    using Newtonsoft.Json;

    /// <summary>
    ///    An internal access class holds all the internal shared/static and extension methods which will serve the whole library.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 10:33 AM</DateTime>
    /// </Created>
    public static class Shared
    {
        #region Public Methods

        /// <summary>
        ///    Determines whether the specified object is valid structured type as an instance of ("<see cref="DataTable"/>") to be passed to the data command.
        /// </summary>
        /// <param name="value">The object to be  validated as a safe structured type to be passed to the data command.</param>
        /// <returns>
        ///   <c>true</c> if [is structured type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:42 AM</DateTime>
        /// </Created>
        public static bool IsDataTable(this object value)
        {
            return value != null && value is DataTable;
        }

        /// <summary>
        ///    Determines whether the specified object is valid to be serialized into <c>Json or Xml</c> string.
        /// </summary>
        /// <param name="value">
        ///    The object to be validated of being serialized into <c>Json or Xml</c> string.
        ///    <para>Accepted inputs: Classes, User Defined Strcutures, Arrays and Generic Collections.</para>
        /// </param>
        /// <returns>
        ///   <c>true</c> if [is structured type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSerializableType(this object value)
        {
            if (value == null || value is string || value is decimal || value is DateTime || value is Guid)
            {
                return false;
            }

            if (value is System.Collections.ICollection)
            {
                return true;
            }

            var type = value.GetType();
            if (type.IsEnum || type.IsPrimitive)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///    Determines whether the specified object is a collection.
        /// </summary>
        /// <param name="value">
        ///    The object to be validated of being a collection.
        /// </param>
        /// <returns>
        ///   <c>true</c> if collection; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsCollection(this object value)
        {
            if (value == null)
            {
                return false;
            }

            return value is System.Collections.ICollection;
        }

        /// <summary>
        ///    Determines whether the specified object is instantiated from a single concrete class.
        /// </summary>
        /// <param name="value">
        ///    The object to be verified.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified object is an instance of a single class (if collection, it will return false); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSingleConcreteClass(this object value)
        {
            if (value == null || value is string || value is decimal || value is DateTime || value is Guid || value is System.Collections.ICollection)
            {
                return false;
            }

            var type = value.GetType();
            if (type.IsClass && !type.IsAbstract)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///    Determines whether the specified property type is a concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="prop">The propery to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified propery is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this PropertyInfo prop)
        {
            if (prop == null)
            {
                return false;
            }

            var type = prop.PropertyType;

            if (type.IsGenericType)
            {
                return type.GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else if (type.HasElementType)
            {
                return type.GetElementType().IsSingleConcreteClass();
            }

            return type.IsClass && !type.IsAbstract && type != typeof(string);
        }

        /// <summary>
        ///    Determines whether the specified type is a concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this Type type)
        {
            if (type.IsGenericType)
            {
                return type.GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else if (type.HasElementType)
            {
                return type.GetElementType().IsSingleConcreteClass();
            }

            return type.IsClass && !type.IsAbstract && type != typeof(string);
        }

        /// <summary>
        ///    Determines whether the specified object is concrete class which can be instantiated.
        /// </summary>
        /// <remarks>This could be single class or collection.</remarks>
        /// <param name="obj">The object to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is a concrete class which can be instantiated (either single class or collection); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClass(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            return type.IsConcreteClass();
        }

        /// <summary>
        ///    Determines whether the specified type is a type a single concrete class which can be instantiated.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is an instance of a single class (if collection, it will return false); otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsSingleConcreteClass(this Type type)
        {
            return type.IsClass && !type.IsGenericType && !type.IsAbstract && type != typeof(string);
        }

        /// <summary>
        ///    Determines whether the specified collection is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="obj">The object to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClassCollection(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not System.Collections.ICollection)
            {
                return false;
            }

            var type = obj.GetType();
            if (type.IsGenericType)
            {
                return obj.GetType().GenericTypeArguments[0].IsSingleConcreteClass();
            }
            else
            {
                return obj.GetType().GetElementType().IsSingleConcreteClass();
            }
        }

        /// <summary>
        ///    Determines the generic type behind a collection. E.g. "<![CDATA[List<string>]]>" or "<![CDATA[string[]]]>" will return "string".
        /// </summary>
        /// <param name="collecton">The specified collection type.</param>
        /// <returns>
        ///    The generic type behind a collection.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static Type GetGenericType(this System.Collections.ICollection collecton)
        {
            return collecton.GetType().GenericTypeArguments[0];
        }

        /// <summary>
        ///    Determines whether the specified type is a collection of concrete class which can be instantiated.
        /// </summary>
        /// <param name="type">The type to be verified.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is a collection of concrete class which can be instantiated; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>03/02/2022 10:00 PM</DateTime>
        /// </Created>
        public static bool IsConcreteClassCollection(this Type type)
        {
            return type.IsGenericType && type.GenericTypeArguments[0].IsSingleConcreteClass();
        }

        /// <summary>
        ///    Converts to structured data type as an instance of <see cref="DataTable"/>.
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <returns>The structured data type as an instance of <see cref="DataTable"/>.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static DataTable ToStructuredDbType(this object obj, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError)
        {
            if (obj == null)
            {
                return null;
            }

            var list = obj is System.Collections.IList ? (System.Collections.IList)obj : new List<object> { obj };
            if (list.Count == 0)
            {
                return null;
            }

            var dt = new DataTable();

            var dataColumnDetailsList = list[0].GetDataColumnDetailsList(dataAccessSettings, memoryCache, handleError);
            var dataColumnsArray = dataColumnDetailsList.GetNonReferencedCopy().ToArray();
            dt.Columns.AddRange(dataColumnsArray);

            foreach (var listItem in list)
            {
                var dr = dt.GetDataRow(listItem, dataColumnDetailsList, dataAccessSettings, memoryCache, handleError);
                if (dr != null)
                {
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        ///    Update the object (single class or collection of classes) with the targeted data transformation like encryption, decryption, hashing, serialization or deserialization.
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="dataFieldsList">The data fields list.</param>
        /// <param name="parentSpecialType">The parent (container) class special type.</param>
        /// <param name="dataDirection">The data direct either coming from data source (inbound) or going to be persisted in data source (outbound).</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <param name="childProp">The property is actually a child from another property.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static void UpdateDataRowObject(this object obj, ICollection<DataField> dataFieldsList, SpecialType parentSpecialType, DataDirection dataDirection, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError, bool childProp = false)
        {
            if (obj == null)
            {
                return;
            }

            if (obj.IsConcreteClassCollection())
            {
                var objList = (System.Collections.IList)obj;
                if (objList.Count == 0)
                {
                    return;
                }

                var subDataFieldsList = objList[0].GetDataFieldList(dataAccessSettings, memoryCache, handleError, CacheCategory.DataField);
                foreach (var objItem in objList)
                {
                    objItem.UpdateDataRowObject(subDataFieldsList, parentSpecialType, dataDirection, dataAccessSettings, memoryCache, handleError, childProp);
                }
            }
            else if (obj.IsSingleConcreteClass())
            {
                obj.UpdateDataRowSingleObject(dataFieldsList, parentSpecialType, dataDirection, dataAccessSettings, memoryCache, handleError, childProp);
            }
        }

        /// <summary>
        ///    Converts the properties of the specified source object into list of "<see cref="DataFieldAttribute"/>".
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <param name="cacheCategory">The cache category by the source type. E.g. DataField, Structured, etc.</param>
        /// <returns>List of "<see cref="DataFieldAttribute"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static List<DataField> GetDataFieldList(this object obj, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError, CacheCategory cacheCategory)
        {
            if (obj == null)
            {
                return null;
            }

            var targetObject = obj;
            if (obj is System.Collections.ICollection)
            {
                var objList = (System.Collections.IList)obj;
                if (objList.Count != 0)
                {
                    targetObject = objList[0];
                }
            }

            var type = targetObject.GetType();
            return GetDataFieldList(type, dataAccessSettings, memoryCache, handleError, cacheCategory);
        }

        /// <summary>
        ///    Converts the properties of the specified source object into list of "<see cref="DataFieldAttribute"/>".
        /// </summary>
        /// <param name="type">The source type.</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <param name="cacheCategory">The cache category by the source type. E.g. DataField, Structured, etc.</param>
        /// <returns>List of "<see cref="DataField"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static List<DataField> GetDataFieldList(this Type type, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError, CacheCategory cacheCategory)
        {
            var before = GC.GetTotalMemory(false);
            var dataFieldList = new List<DataField>();
            var cacheKey = $"{type.FullName}.{cacheCategory}";
            if (!dataAccessSettings.CacheSettings.Disabled && !dataAccessSettings.CacheSettings.DisableSecondLevel)
            {
                dataFieldList = GetDataFieldsFromCache(cacheKey, memoryCache);
                if (dataFieldList != null && dataFieldList.Count > 0)
                {
                    return dataFieldList;
                }
                else
                {
                    dataFieldList = new List<DataField>();
                }
            }

            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in props)
            {
                var dataField = prop.GetDataField();

                if (dataField != null)
                {
                    dataFieldList.Add(dataField);
                }
            }

            if (memoryCache is not null && !dataAccessSettings.CacheSettings.Disabled && !dataAccessSettings.CacheSettings.DisableSecondLevel)
            {
                var after = GC.GetTotalMemory(false);
                var size = after - before;
                if (memoryCache.ValidateThreshold(dataAccessSettings.CacheSettings, memoryCache.SecondLevelCacheMemorySize, size))
                {
                    dataFieldList.SaveDataFieldsToCacheAsync(cacheKey, memoryCache);
                    memoryCache.SecondLevelCacheMemorySize += size;
                }
                else
                {
                    var warrning = dataAccessSettings.CreateErrorDetails(
                        logLevel: Microsoft.Extensions.Logging.LogLevel.Warning,
                        errorNumber: -400,
                        stackTrace: Environment.StackTrace,
                        source: "DAL.Shared.GetDataFieldList(this object obj, IDataAccessSettings dataAccessSettings, IMemoryCached memoryCache, Action<IErrorDetails> handleError)",
                        message: $"Second level cache threshold warning. Failed to save the cache '{cacheKey}",
                        description: GetMemoryThresholdWarningJsonMessage(cacheKey, size, memoryCache, dataAccessSettings));
                    handleError(warrning);
                }
            }

            return dataFieldList;
        }

        /// <summary>
        ///    Save the data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/> into the cache.
        /// </summary>
        /// <param name="dataFieldsList">The data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/>.</param>
        /// <param name="cacheKey">The unique cache key.</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:34 AM</DateTime>
        /// </Created>
        public static void SaveDataFieldsToCache(this List<DataField> dataFieldsList, string cacheKey, IMemoryCache memoryCache)
        {
            if (memoryCache == null)
            {
                return;
            }

            if (!memoryCache.CachedDataFields.ContainsKey(cacheKey))
            {
                memoryCache.CachedDataFields.Add(cacheKey, dataFieldsList);
            }
        }

        /// <summary>
        ///    Compare the Key/Value Pairs between two dictionaries and return <c>true</c> if matches.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="sourceDictionary">The source dictionary.</param>
        /// <param name="comparerDictionary">The other dictionary to compare with the source.</param>
        /// <returns>
        ///    <c>true</c> if the two dictionaries have the same identical Key/Value Pairs with case sensitive data for both keys and values; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:34 AM</DateTime>
        /// </Created>
        public static bool Compare<TKey, TValue>(this IDictionary<TKey, TValue> sourceDictionary, IDictionary<TKey, TValue> comparerDictionary)
        {
            if (sourceDictionary == null || comparerDictionary == null)
            {
                return false;
            }

            var result = sourceDictionary.Count == comparerDictionary.Count && !sourceDictionary.Except(comparerDictionary).Any();
            return result;
        }
        #endregion Public Methods

        #region Internal Methods
        #region DAL Opearations

        /// <summary>
        ///    Gets the provider factory details.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <returns>The provider factory details.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:19 PM</DateTime>
        /// </Created>
        internal static IProviderFactoryDetails GetProviderFactoryDetails(this DataProviderFactory dataProvider)
        {
            var field = dataProvider.GetType().GetField(dataProvider.ToString());
            var customAttributes = field.GetCustomAttributes(false);
            var attribute = customAttributes.FirstOrDefault(a => a.GetType() == typeof(ProviderFactoryDetailsAttribute));

            return attribute == null ? null : attribute as ProviderFactoryDetailsAttribute;
        }

        /// <summary>
        ///    Gets the data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/>.
        /// </summary>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <typeparam name="T">The type of the passed class which represents the mapped table.</typeparam>
        /// <returns>
        ///    List of the data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:34 AM</DateTime>
        /// </Created>
        internal static List<DataField> GetDataFields<T>(IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError)
        {
            var type = typeof(T);

            return GetDataFieldList(type, dataAccessSettings, memoryCache, handleError, CacheCategory.DataField);
        }
        #endregion DAL Operations

        #region SharedMethods

        /// <summary>
        ///    Gets the custom attribute.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <returns>The custom attribute.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:33 AM</DateTime>
        /// </Created>
        internal static TAttribute GetCustomAttribute<TSource, TAttribute>()
        {
            return Attribute.GetCustomAttribute(typeof(TSource), typeof(TAttribute), true).To<TAttribute>();
        }

        /// <summary>
        ///    Gets the custom attribute.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <typeparam name="T">The type of the return attribute.</typeparam>
        /// <returns>The custom attribute.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:33 AM</DateTime>
        /// </Created>
        internal static T GetCustomAttribute<T>(this object source)
        {
            return Attribute.GetCustomAttribute(source.GetType(), typeof(T), true).To<T>();
        }

        /// <summary>
        /// Determines whether [is null or empty] [the specified trim white spaces].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="trimWhiteSpaces">if set to <c>true</c> [trim white spaces]. Default value is <c>false</c>.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified trim white spaces]; otherwise, <c>false</c>.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>20/08/2017  05:54 PM</DateTime>
        /// </Created>
        internal static bool IsNullOrEmpty(this string source, bool trimWhiteSpaces)
        {
            if (source == null)
            {
                return true;
            }

            if (trimWhiteSpaces)
            {
                source = source.Trim();
            }

            return source.Length == 0;
        }

        /// <summary>
        ///     Gets the property value with a specified data type by its name from an existing object/instance dynamically.
        /// </summary>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="source">The source object/instance.</param>
        /// <param name="property">The property name.</param>
        /// <returns>The property value with a specified data type by its name from an existing object/instance dynamically.</returns>
        /// <Created>
        ///     <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///     <DateTime>20/08/2017 03:00 PM</DateTime>
        /// </Created>
        internal static T GetPropertyValue<T>(this object source, string property)
        {
            if (source == null)
            {
                return default;
            }

            var prop = source.GetType().GetProperty(property);
            return prop == null ? default : prop.GetValue(source, null).To<T>();
        }

        /// <summary>
        ///    Gets the property value with a specified data type by its name from an existing object/instance dynamically.
        /// </summary>
        /// <param name="source">The source object/instance.</param>
        /// <param name="property">The property name.</param>
        /// <returns>
        /// The property value with a specified data type by its name from an existing object/instance dynamically.
        /// </returns>
        /// <Created>
        ///   <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///   <DateTime>20/08/2017 03:00 PM</DateTime>
        /// </Created>
        internal static object GetPropertyValue(this object source, string property)
        {
            if (source == null)
            {
                return default;
            }

            var prop = source.GetType().GetProperty(property);
            return prop == null ? default : prop.GetValue(source, null);
        }

        /// <summary>
        ///    Gets the property value with a specified data type by its name from an existing object/instance dynamically.
        /// </summary>
        /// <param name="source">The source object/instance.</param>
        /// <param name="property">The property name.</param>
        /// <param name="value">The value to be set.</param>
        /// <Created>
        ///   <Author>Ahmad Adel Gad (ahmad.adel@devhorizons.com)</Author>
        ///   <DateTime>20/08/2017 03:00 PM</DateTime>
        /// </Created>
        internal static void SetPropertyValue(this object source, string property, object value)
        {
            var prop = source.GetType().GetProperty(property);
            prop.SetValue(source, value);
        }
        #endregion SharedMethods

        #region ChangeType Methods

        /// <summary>
        ///     Gets the default value of a specific type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The default value of a specific type.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>31/08/2013  01:26 AM</DateTime>
        /// </Created>
        internal static object GetDefaultValue(this Type type)
        {
            if (type == typeof(string) || type.BaseType == typeof(System.Array))
            {
                return null;
            }

            try
            {
                return Activator.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Convers from a data type to another.
        /// </summary>
        /// <typeparam name="T">The type name.</typeparam>
        /// <param name="source">The source to be converted.</param>
        /// <returns>The converted object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/06/2012  04:29 PM</DateTime>
        /// </Created>
        internal static T ChangeType<T>(this object source)
        {
            return source.ChangeType<T>(default);
        }

        /// <summary>
        ///     Convers from a data type to another.
        /// </summary>
        /// <typeparam name="T">The type name.</typeparam>
        /// <param name="source">The source to be converted.</param>
        /// <param name="defaultValue">The default return value in case of failure.</param>
        /// <returns>The converted object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>30/06/2012  04:29 PM</DateTime>
        /// </Created>
        internal static T ChangeType<T>(this object source, T defaultValue)
        {
            if (source == null)
            {
                return defaultValue;
            }

            var type = typeof(T);
            return (T)source.ChangeType(type, defaultValue);
        }

        /// <summary>
        ///     Changes the type of specific object.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="type">The type.</param>
        /// <returns>The converted value of specific object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>31/08/2013  01:23 AM</DateTime>
        /// </Created>
        internal static object ChangeType(this object source, Type type)
        {
            return source.ChangeType(type, type.GetDefaultValue());
        }

        /// <summary>
        ///     Changes the type of specific object.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="type">The type.</param>
        /// <param name="defaultValue">The alternate value that should be returned in case of converted value.</param>
        /// <returns>The converted value of specific object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>31/08/2013  01:23 AM</DateTime>
        /// </Created>
        internal static object ChangeType(this object source, Type type, object defaultValue)
        {
            try
            {
                if (source == null)
                {
                    return defaultValue;
                }

                var conversionType = System.Nullable.GetUnderlyingType(type) ?? type;

                if (conversionType.IsEnum)
                {
                    return Enum.Parse(conversionType, source.ToString());
                }

                if (source is IntPtr)
                {
                    source = source.ToString();
                }
                else if (source is byte[])
                {
                    var result = source.ConvertFromArrayOfBytes(conversionType);
                    if (result != null)
                    {
                        return result;
                    }
                }
                else if (source.GetType().BaseType == typeof(System.Array))
                {
                    if (conversionType.Name == "List`1")
                    {
                        source = source.ConvertFromArrayToList(conversionType);
                    }
                }
                else if (source is System.Collections.IList)
                {
                    if (conversionType.BaseType == typeof(System.Array))
                    {
                        source = source.ConvertFromListToArray();
                    }
                }
                else if (conversionType.Name == "List`1")
                {
                    if (!source.GetType().IsArray && source.GetType().Name != "List`1")
                    {
                        source = source.ConvertFromObjectToList(conversionType);
                    }
                }
                else if (conversionType.IsArray)
                {
                    if (!source.GetType().IsArray && source.GetType().Name != "List`1")
                    {
                        source = source.ConvertFromObjectToArray();
                    }
                }

                return Convert.ChangeType(source, conversionType);
            }
            catch
            {
                return Convert.ChangeType(defaultValue, TypeCode.Object);
            }
        }
        #endregion ChangeType Methods
        #endregion Internal Methods

        #region Private Methods
        #region Collections Converting

        /// <summary>
        ///     Converts from object to array.
        /// </summary>
        /// <param name="source">The source object which should not be an array or a list.</param>
        /// <returns>An array from an object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>15/09/2013  11:38s AM</DateTime>
        /// </Created>
        private static object ConvertFromObjectToArray(this object source)
        {
            var array = Array.CreateInstance(source.GetType(), 1);
            array.SetValue(source, 0);
            source = array;
            return source;
        }

        /// <summary>
        ///     Converts from object to list.
        /// </summary>
        /// <param name="source">The source object which should not be an array or a list.</param>
        /// <param name="type">The destination type.</param>
        /// <returns>A list from an object.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>15/09/2013  11:38s AM</DateTime>
        /// </Created>
        private static object ConvertFromObjectToList(this object source, Type type)
        {
            var list = Activator.CreateInstance(type);
            list.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, list, new object[] { source });
            source = list;
            return source;
        }

        /// <summary>
        ///     Converts from array to list.
        /// </summary>
        /// <param name="source">The source array.</param>
        /// <param name="type">The type.</param>
        /// <returns>A list from an array.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>15/09/2013  11:38s AM</DateTime>
        /// </Created>
        private static object ConvertFromArrayToList(this object source, Type type)
        {
            var list = Activator.CreateInstance(type);
            list.GetType().InvokeMember("AddRange", BindingFlags.InvokeMethod, null, list, new object[] { source });
            source = list;
            return source;
        }

        /// <summary>
        ///     Converts from list to array.
        /// </summary>
        /// <param name="source">The source list.</param>
        /// <returns>An array from a list.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>15/09/2013  11:38s AM</DateTime>
        /// </Created>
        private static object ConvertFromListToArray(this object source)
        {
            var itemType = source.GetType().GetProperty("Item").PropertyType;
            var count = Convert.ToInt32(source.GetType().GetProperty("Count").GetValue(source, null));
            var items = source.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(source);
            var array = Array.CreateInstance(itemType, count);
            Array.Copy(items as Array, array, count);
            source = array;
            return source;
        }

        /// <summary>
        ///     Converts from array of bytes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="type">The destination type.</param>
        /// <returns>From Array of bytes.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>15/09/2013  11:38s AM</DateTime>
        /// </Created>
        private static object ConvertFromArrayOfBytes(this object source, Type type)
        {
            var sourceBytes = source as byte[];

            if (type == typeof(Guid))
            {
                return new Guid(sourceBytes);
            }
            else if (type == typeof(string))
            {
                return System.Convert.ToBase64String(sourceBytes);
            }
            else
            {
                return null;
            }
        }
        #endregion Collections Converting

        #region Cache Management
        #region DataField
        #region Get

        /// <summary>
        ///    Gets the data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataField"/> from the memory cache.
        /// </summary>
        /// <param name="cacheKey">The unique cache key.</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:34 AM</DateTime>
        /// </Created>
        private static List<DataField> GetDataFieldsFromCache(string cacheKey, IMemoryCache memoryCache)
        {
            if (memoryCache != null && memoryCache.CachedDataFields != null && memoryCache?.CachedDataFields?.Count != 0)
            {
                var valueExist = memoryCache.CachedDataFields.TryGetValue(cacheKey, out List<DataField> value);
                return valueExist ? value : null;
            }

            return null;
        }
        #endregion Get

        #region Set

        /// <summary>
        ///    Save the data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/> into the cache in a running task in the background.
        /// </summary>
        /// <param name="dataColumnAttributeList">The data columns as <see cref="List{T}"/> where <c>T</c> is <see cref="DataFieldAttribute"/>.</param>
        /// <param name="cacheKey">The unique cache key.</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:34 AM</DateTime>
        /// </Created>
        private static void SaveDataFieldsToCacheAsync(this List<DataField> dataColumnAttributeList, string cacheKey, IMemoryCache memoryCache)
        {
            Task.Run(() => dataColumnAttributeList.SaveDataFieldsToCache(cacheKey, memoryCache));
        }
        #endregion Set
        #endregion DataField
        #endregion Cache Management

        #region DataTable

        /// <summary>
        ///    Converts the properties of the specified source object into list of "<see cref="DataField"/>".
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="dataAccessSettings">The data access settings of the type "<see cref="IDataAccessSettings"/>".</param>
        /// <param name="memoryCache">The memory cached objects passed by the engine. Usually registered as Singleton Dependency Injection life cycle.</param>
        /// <param name="handleError">The error handler callback method.</param>

        /// <returns>List of "<see cref="DataColumn"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static List<DataField> GetDataColumnDetailsList(this object obj, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError)
        {
            var before = GC.GetTotalMemory(false);
            var cacheKey = $"{obj.GetType().FullName}.DataColumns";
            if (dataAccessSettings.CacheSettings.IsSecondLevelCacheAllowed())
            {
                var dataColFromCache = GetDataFieldsFromCache(cacheKey, memoryCache);

                if (dataColFromCache != null)
                {
                    return dataColFromCache;
                }
            }

            var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var colDetailsList = new List<DataField>();
            foreach (var prop in props)
            {
                var dataColumn = obj.GetDataColumnDetails(prop);

                if (dataColumn != null)
                {
                    colDetailsList.Add(dataColumn);
                }
            }

            if (dataAccessSettings.CacheSettings.IsSecondLevelCacheAllowed() && memoryCache != null)
            {
                var after = GC.GetTotalMemory(false);

                var size = after - before;
                if (memoryCache.ValidateThreshold(dataAccessSettings.CacheSettings, memoryCache.SecondLevelCacheMemorySize, size))
                {
                    colDetailsList.SaveDataFieldsToCacheAsync(cacheKey, memoryCache);
                    memoryCache.SecondLevelCacheMemorySize += size;
                }
                else
                {
                    var warrning = dataAccessSettings.CreateErrorDetails(
                        logLevel: Microsoft.Extensions.Logging.LogLevel.Warning,
                        errorNumber: -400,
                        stackTrace: Environment.StackTrace,
                        source: "DAL.Shared.GetDataColumnDetailsList<T>(IDataAccessSettings dataAccessSettings, IMemoryCached memoryCache, Action<IErrorDetails> handleError)",
                        message: $"Second level cache threshold warning. Failed to save the cache '{cacheKey}",
                        description: GetMemoryThresholdWarningJsonMessage(cacheKey, size, memoryCache, dataAccessSettings));
                    handleError(warrning);
                }
            }

            return colDetailsList;
        }

        /// <summary>
        ///    Converts to data column as an instance of "<see cref="DataColumn"/>" which will be used to create data row in a <see cref="DataTable"/> object.
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="prop">Data property info.</param>
        /// <returns>The data row as an instance of "<see cref="DataRow"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static DataField GetDataColumnDetails(this object obj, PropertyInfo prop)
        {
            var dataField = prop.GetDataField(obj);
            if (dataField.NotMapped || dataField.DataDirection == DataDirection.Inbound || dataField.DataDirection == DataDirection.None)
            {
                return null;
            }

            return dataField;
        }

        /// <summary>
        ///    Gets non reference copy of the specified list of "<see cref="DataColumn"/>".
        /// </summary>
        /// <param name="dataColumnsList">The data columns list.</param>
        /// <returns>Non reference copy of the specified data columns list.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static List<DataColumn> GetNonReferencedCopy(this ICollection<DataField> dataColumnsList)
        {
            var newList = new List<DataColumn>();
            foreach (var dc in dataColumnsList)
            {
                newList.Add(new DataColumn(dc.Name, dc.Type));
            }

            return newList;
        }

        /// <summary>
        ///    Gets to data row as an instance of "<see cref="DataRow"/>" from the specified data table ("<see cref="DataTable"/>") object.
        /// </summary>
        /// <param name="dt">The data table object.</param>
        /// <param name="obj">The source object.</param>
        /// <param name="dataFieldsList">The list of the generated data columns details.</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <returns>The data row as an instance of "<see cref="DataRow"/>".</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static DataRow GetDataRow(this DataTable dt, object obj, ICollection<DataField> dataFieldsList, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError)
        {
            var dr = dt.NewRow();
            obj.UpdateDataRowObject(dataFieldsList, SpecialType.None, DataDirection.Outbound, dataAccessSettings, memoryCache, handleError);
            foreach (var df in dataFieldsList)
            {
                var value = df.Property.GetValue(obj);
                dr[df.Name] = value;
            }

            return dr;
        }

        /// <summary>
        ///    Update the object (single class) with the targeted data transformation like encryption, decryption, hashing, serialization or deserialization.
        /// </summary>
        /// <param name="obj">The source object.</param>
        /// <param name="dataFieldsList">The list of the data fields of this type.</param>
        /// <param name="parentSpecialType">The parent (container) class special type.</param>
        /// <param name="dataDirection">The data direct either coming from data source (inbound) or going to be persisted in data source (outbound).</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <param name="childProp">The property is actually a child from another property.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static void UpdateDataRowSingleObject(this object obj, ICollection<DataField> dataFieldsList, SpecialType parentSpecialType, DataDirection dataDirection, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError, bool childProp = false)
        {
            foreach (var dataField in dataFieldsList)
            {
                var prop = dataField.Property;
                var value = prop.GetValue(obj);
                if (value == null)
                {
                    continue;
                }

                if (prop.IsConcreteClass())
                {
                    var subDataFieldsList = value.GetDataFieldList(dataAccessSettings, memoryCache, handleError, CacheCategory.DataField).Where(df => df.DataDirection != DataDirection.None).ToList();
                    if (subDataFieldsList.Count != 0)
                    {
                        value.UpdateDataRowObject(subDataFieldsList, parentSpecialType, dataDirection, dataAccessSettings, memoryCache, handleError, true);
                    }
                }

                dataField.UpdateDataRowSingleObjectProp(parentSpecialType, value, obj, dataDirection, dataAccessSettings, memoryCache, handleError, childProp);
            }
        }

        /// <summary>
        ///    Update the property with the new value inside an object (single class) with the targeted data transformation like encryption, decryption, hashing, serialization or deserialization.
        /// </summary>
        /// <param name="dataField">The field mapped to the target property.</param>
        /// <param name="parentSpecialType">The parent (container) class special type.</param>
        /// <param name="value">The current raw value to be transformed if required.</param>
        /// <param name="obj">The source parent object where as the declaration type holds this property.</param>
        /// <param name="dataDirection">The data direct either coming from data source (inbound) or going to be persisted in data source (outbound).</param>
        /// <param name="dataAccessSettings">The data access settings.</param>
        /// <param name="memoryCache">The internal memory cached object/container.</param>
        /// <param name="handleError">The handle error function passed from the command.</param>
        /// <param name="childProp">The property is actually a child from another property.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static void UpdateDataRowSingleObjectProp(this DataField dataField, SpecialType parentSpecialType, object value, object obj, DataDirection dataDirection, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCache, Action<ILogDetails> handleError, bool childProp = false)
        {
            if (dataField == null || dataField.NotMapped || dataField.DataDirection == DataDirection.None)
            {
                return;
            }

            var prop = dataField.Property;

            if (dataDirection == DataDirection.Outbound)
            {
                var newValue = value;
                if (dataField.SpecialType == SpecialType.Json && parentSpecialType != SpecialType.Json)
                {
                    newValue = JsonConvert.SerializeObject(newValue);
                }
                else if (dataField.SpecialType == SpecialType.Xml && parentSpecialType != SpecialType.Xml)
                {
                    newValue = newValue.ToXmlString();
                }

                if (dataField.Encrypted)
                {
                    var nonDeterministic = dataField.EncryptionType == EncryptionType.Randomized || dataAccessSettings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType == EncryptionType.Randomized;
                    var cryptoResult = newValue.ToString().EncryptSymmetric(dataAccessSettings, nonDeterministic, memoryCache);
                    if (cryptoResult.OutputError != null)
                    {
                        throw new Exception($"Failed to encrypt the property '{prop.Name}' inside the class '{obj.GetType().FullName}'.", cryptoResult.OutputError.Exception);
                    }
                    else
                    {
                        newValue = cryptoResult.Value;
                    }
                }
                else if (dataField.Hashed)
                {
                    var cryptoResult = newValue.ToString().ToHash(dataAccessSettings, memoryCache);
                    if (cryptoResult.OutputError != null)
                    {
                        throw new Exception($"Failed to hash the data of the property '{prop.Name}' inside the class '{obj.GetType().FullName}'.", cryptoResult.OutputError.Exception);
                    }
                    else
                    {
                        newValue = cryptoResult.Value;
                    }
                }

                if (childProp)
                {
                    prop.SetValue(obj, newValue);
                }
            }
            else
            {
                var newValue = value;
                if (dataField.Encrypted || dataField.MayBeEncrypted)
                {
                    var nonDeterministic = dataField.EncryptionType == EncryptionType.Randomized || dataAccessSettings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType == EncryptionType.Randomized;
                    var cryptoResult = newValue.ToString().DecryptSymmetric(dataAccessSettings, nonDeterministic, memoryCache);
                    if (cryptoResult.Value != null)
                    {
                        newValue = cryptoResult.Value;
                    }
                    else
                    {
                        if (!dataField.MayBeEncrypted)
                        {
                            var ex = new Exception($"Failed to decrypt the property '{prop.Name}' inside the class '{obj.GetType().FullName}'.", cryptoResult.OutputError.Exception);
                            var outputError = cryptoResult.OutputError;
                            outputError.Exception = ex;
                            handleError(outputError);
                        }
                        else
                        {
                            var ex = new Exception($"Failed to decrypt the property '{prop.Name}' inside the class '{obj.GetType().FullName}' with the flag 'MayBeEncrypted'.", cryptoResult.OutputError.Exception);
                            var outputWarning = cryptoResult.OutputError;
                            outputWarning.LogLevel = Microsoft.Extensions.Logging.LogLevel.Warning;
                            outputWarning.Exception = ex;
                            handleError(outputWarning);
                            return;
                        }
                    }
                }

                if (dataField.SpecialType == SpecialType.Json)
                {
                    newValue = value.ToString().FromJsonString(prop.PropertyType);
                }
                else if (dataField.SpecialType == SpecialType.Xml)
                {
                    newValue = value.ToString().FromXmlString(prop.PropertyType);
                }

                prop.SetValue(obj, newValue);
            }
        }
        #endregion DataTable

        /// <summary>
        ///    Get the threshold memory warning message in a "<c>JSON</c>" string format.
        /// </summary>
        /// <param name="cacheKey">The unique cache key.</param>
        /// <param name="size">The cache size in bytes.</param>
        /// <param name="memoryCache">The memory cache object.</param>
        /// <param name="dataAccessSettings">The data settings object.</param>
        /// <returns>
        ///    The threshold memory warning message in a "<c>JSON</c>" string format.
        /// </returns>
        private static string GetMemoryThresholdWarningJsonMessage(string cacheKey, long size, IMemoryCache memoryCache, IDataAccessSettings dataAccessSettings)
        {
            return $"{{'CacheKey': '{cacheKey}', 'CacheSize': '{size * 1.5}', 'SecondLevelCacheCurrentSize': '{memoryCache.SecondLevelCacheMemorySize}', 'SecondLevelMemoryCacheThreshold': '{dataAccessSettings.CacheSettings.MemoryCacheThreshold}'}}";
        }
        #endregion Private Methods
    }
}
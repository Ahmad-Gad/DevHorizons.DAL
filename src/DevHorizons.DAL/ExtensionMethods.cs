// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionMethods.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the public extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
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
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using Attributes;
    using DevHorizons.DAL.Interfaces;
    using Newtonsoft.Json;
    using Shared;

    /// <summary>
    ///    A public static class which holds all the public extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 12:41 PM</DateTime>
    /// </Created>
    public static class ExtensionMethods
    {
        #region Public Methods

        /// <summary>
        ///    Converts a collection of generic objects (class based) to the supported structured data type to be passed to the "<see cref="Interfaces.IDataField.Value"/>" property.
        ///    <para>This is required only if the host parameter holds a "Structured" data type.</para>
        /// </summary>
        /// <typeparam name="T">The type of the passed class based object.</typeparam>
        /// <param name="data">The collection of the based class objects to be converted.</param>
        /// <returns>
        ///    A collection of generic objects (class based) to the supported structured data type to be passed to the "<see cref="Interfaces.IDataField.Value"/>" property.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:42 PM</DateTime>
        /// </Created>
        public static System.Data.DataTable ToStructuredDbType<T>(this ICollection<T> data) where T : class
        {
            var dt = new System.Data.DataTable();
            if (data == null)
            {
                return dt;
            }

            var props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                var propType = Nullable.GetUnderlyingType(prop.PropertyType) == null ? prop.PropertyType : typeof(object);
                var col = new DataColumn(prop.Name, propType);
                dt.Columns.Add(col);
            }

            foreach (var item in data)
            {
                var dr = dt.NewRow();
                foreach (var prop in props)
                {
                    dr[prop.Name] = prop.GetValue(item);
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        ///    Converts a collection of generic objects (value data type (struct) based) to the supported structured data type to be passed to the "<see cref="Interfaces.IDataField.Value"/>" property.
        ///    <para>This is required only if the host parameter holds a "Structured" data type.</para>
        /// </summary>
        /// <typeparam name="T">The type of the passed value data type (struct) based object.</typeparam>
        /// <param name="data">The collection of the value data type based objects to be converted.</param>
        /// <returns>
        ///    A collection of generic objects (class based) to the supported structured data type to be passed to the "<see cref="Interfaces.IDataField.Value"/>" property.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 12:42 PM</DateTime>
        /// </Created>
        public static System.Data.DataTable ToStructuredDbType<T>(this IEnumerable<T> data) where T : struct
        {
            var dt = new System.Data.DataTable();
            if (data == null)
            {
                return dt;
            }

            dt.Columns.Add(string.Empty, typeof(T));

            foreach (var item in data)
            {
                var dr = dt.NewRow();

                dr[0] = item;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        ///      Converts to generic data type based on the generic input data type.
        /// </summary>
        /// <typeparam name="T">The generic input data type.</typeparam>
        /// <param name="source">The source object to be converted.</param>
        /// <returns>Value based on generic data type from generic input data type.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static T To<T>(this object source)
        {
            return source.ChangeType<T>();
        }

        /// <summary>
        ///    Gets the description attribute value.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>
        ///    The description attribute value.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static string GetDescription(this object source)
        {
            var type = source.GetType();
            var descriptionAttribute = type.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute?.Description;
        }

        /// <summary>
        ///    Gets the "display name" attribute value.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>
        ///    The "display name" attribute value.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static string GetDisplayName(this object source)
        {
            var type = source.GetType();
            var descriptionAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
            return descriptionAttribute?.DisplayName;
        }

        /// <summary>
        ///    Gets the "Default Value" attribute value.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>
        ///    The "display name" attribute value.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static object GetDefaultValue(this object source)
        {
            var type = source.GetType();
            var descriptionAttribute = type.GetCustomAttribute<DefaultValueAttribute>();
            return descriptionAttribute?.Value;
        }

        /// <summary>
        ///    Gets the "Default Value" attribute value.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <typeparam name="T">The type of the returned value.</typeparam>
        /// <returns>
        ///    The "display name" attribute value.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static T GetDefaultValue<T>(this object source)
        {
            var type = source.GetType();
            var descriptionAttribute = type.GetCustomAttribute<DefaultValueAttribute>();
            if (descriptionAttribute != null)
            {
                return default;
            }

            return descriptionAttribute.Value.To<T>(default);
        }

        /// <summary>
        ///      Converts to generic data type based on the generic input data type.
        /// </summary>
        /// <typeparam name="T">The generic input data type.</typeparam>
        /// <param name="source">The source object to be converted.</param>
        /// <param name="defaultValue">The default return (replacement) value in case if the conversion operation failed.</param>
        /// <returns>Value based on generic data type from generic input data type.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///     <DateTime>30/06/2012  06:22 PM</DateTime>
        /// </Created>
        public static T To<T>(this object source, T defaultValue)
        {
            try
            {
                return Shared.Shared.ChangeType<T>(source, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///    Serialize an object into XML string.
        /// </summary>
        /// <param name="obj">The object to be serialized into XML string.</param>
        /// <returns>The XML string as the result of the specified object XML serialization.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static string ToXmlString(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter);
            xmlSerializer.Serialize(xmlWriter, obj);
            var xml = stringWriter.ToString();
            return xml;
        }

        /// <summary>
        ///   Deserialize an XML string into an object.
        /// </summary>
        /// <param name="xmlString">The XML string to be deserialized into object.</param>
        /// <param name="objectType">The type of the output deserialized object.</param>
        /// <returns>The object as the result of the XML deserialization.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static object FromXmlString(this string xmlString, Type objectType)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
            {
                return null;
            }

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(objectType);
            using var stringReader = new StringReader(xmlString);
            using var xmlReader = XmlReader.Create(stringReader);
            var result = xmlSerializer.Deserialize(xmlReader);
            return result;
        }

        /// <summary>
        ///    Serialize an object into <c>JSON</c> string.
        /// </summary>
        /// <param name="obj">The object to be serialized into <c>JSON</c> string.</param>
        /// <returns>The <c>JSON</c> string as the result of the specified object <c>JSON</c> serialization.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static string ToJsonString(this object obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            return result;
        }

        /// <summary>
        ///   Deserialize an <c>JSON</c> string into an object.
        /// </summary>
        /// <param name="jsonString">The <c>JSON</c> string to be deserialized into object.</param>
        /// <param name="objectType">The type of the output deserialized object.</param>
        /// <returns>The object as the result of the <c>JSON</c> deserialization.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static object FromJsonString(this string jsonString, Type objectType)
        {
            var result = JsonConvert.DeserializeObject(jsonString, objectType);
            return result;
        }

        /// <summary>
        ///   Deserialize an <c>JSON</c> string into an object.
        /// </summary>
        /// <param name="jsonString">The <c>JSON</c> string to be deserialized into object.</param>
        /// <typeparam name="T">The type of the serialized object.</typeparam>
        /// <returns>The object as the result of the <c>JSON</c> deserialization.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static object FromJsonString<T>(this string jsonString)
        {
            var result = JsonConvert.DeserializeObject<T>(jsonString);
            return result;
        }

        /// <summary>
        ///    Extracts the properties with the "<see cref="NameValuePairAttribute"/>" in a dictionary as "<see cref="Dictionary{TKey, TValue}"/>"; where "<c>TKey</c>" is string and "<c>TValue</c>" is object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>
        ///    Dictionary represents the mapped keys/names and values as "<see cref="Dictionary{TKey, TValue}"/>"; where "<c>TKey</c>" is string and "<c>TValue</c>" is object.
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>23/04/2022 09:48 PM</DateTime>
        /// </Created>
        public static Dictionary<string, object> GetNameValueProperties(this object source)
        {
            var type = source.GetType();
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (props.Length == 0)
            {
                return null;
            }

            var attributesDic = new Dictionary<string, object>();
            foreach (var prop in props)
            {
                var attribute = prop.GetCustomAttribute<NameValuePairAttribute>(true);
                if (attribute != null)
                {
                    var value = prop.GetValue(source);
                    if (value != null)
                    {
                        var newValue = value;
                        if (prop.PropertyType == typeof(bool?))
                        {
                            newValue = (bool)value ? attribute.TrueValue : attribute.FalseValue;
                        }

                        attributesDic.Add(attribute.Name, newValue ?? value);
                    }
                }
            }

            return attributesDic;
        }

        /// <summary>
        ///    Convert an instance of "<see cref="DataFieldAttribute"/>" to "<see cref="DataField"/>".
        /// </summary>
        /// <param name="dataFieldAttribute">The source "<see cref="DataFieldAttribute"/>".</param>
        /// <returns>
        ///    Instance of "<see cref="DataField"/>".
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/06/2022 01:31 AM</DateTime>
        /// </Created>
        public static DataField ToDataField(this DataFieldAttribute dataFieldAttribute)
        {
            if (dataFieldAttribute == null)
            {
                return new DataField();
            }

            var dataField = new DataField
            {
                SpecialType = dataFieldAttribute.SpecialType,
                Name = dataFieldAttribute.Name,
                Optional = dataFieldAttribute.Optional,
                Encrypted = dataFieldAttribute.Encrypted,
                MayBeEncrypted = dataFieldAttribute.MayBeEncrypted,
                EncryptionType = dataFieldAttribute.EncryptionType,
                Hashed = dataFieldAttribute.Hashed,
                DataDirection = dataFieldAttribute.DataDirection,
                NotMapped = dataFieldAttribute.NotMapped
            };

            return dataField;
        }

        /// <summary>
        ///    Convert an instance of "<see cref="DataFieldAttribute"/>" to "<see cref="DataField"/>".
        /// </summary>
        /// <param name="dataFieldAttribute">The source "<see cref="DataFieldAttribute"/>".</param>
        /// <param name="prop">The mapped property.</param>
        /// <param name="obj">The object whose property value will be returned.</param>
        /// <returns>
        ///    Instance of "<see cref="DataField"/>".
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/06/2022 01:31 AM</DateTime>
        /// </Created>
        public static DataField ToDataField(this DataFieldAttribute dataFieldAttribute, PropertyInfo prop, object obj = null)
        {
            var dataField = new DataField(prop);

            if (dataFieldAttribute != null)
            {
                dataField.Name = dataFieldAttribute.Name;
                dataField.SpecialType = dataFieldAttribute.SpecialType;
                dataField.Optional = dataFieldAttribute.Optional;
                dataField.Encrypted = dataFieldAttribute.Encrypted;
                dataField.MayBeEncrypted = dataFieldAttribute.MayBeEncrypted;
                dataField.EncryptionType = dataFieldAttribute.EncryptionType;
                dataField.Hashed = dataFieldAttribute.Hashed;
                dataField.DataDirection = dataFieldAttribute.DataDirection;
                dataField.NotMapped = dataFieldAttribute.NotMapped;
            }

            if (dataField.Name.IsNullOrEmpty(true))
            {
                dataField.Name = prop.Name;
            }

            var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            dataField.Type = obj is not null && prop.GetValue(obj).IsSerializableType() ? typeof(string) : type;

            return dataField;
        }

        /// <summary>
        ///    Convert an instance of "<see cref="DataFieldAttribute"/>" to "<see cref="DataField"/>".
        /// </summary>
        /// <param name="prop">The mapped property.</param>
        /// <param name="obj">The object whose property value will be returned.</param>
        /// <returns>
        ///    Instance of "<see cref="DataField"/>".
        /// </returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>10/06/2022 01:31 AM</DateTime>
        /// </Created>
        public static DataField GetDataField(this PropertyInfo prop, object obj = null)
        {
            var dataFieldAttribute = prop.GetCustomAttribute<DataFieldAttribute>(true);
            return dataFieldAttribute.ToDataField(prop, obj);
        }
        #endregion Public Methods
    }
}

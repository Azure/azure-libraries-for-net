// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for PropertyChangeType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PropertyChangeType
    {
        /// <summary>
        /// The property does not exist in the current state but is present in
        /// the desired state. The property will be created when the deployment
        /// is executed.
        /// </summary>
        [EnumMember(Value = "Create")]
        Create,
        /// <summary>
        /// The property exists in the current state and is missing from the
        /// desired state. It will be deleted when the deployment is executed.
        /// </summary>
        [EnumMember(Value = "Delete")]
        Delete,
        /// <summary>
        /// The property exists in both current and desired state and is
        /// different. The value of the property will change when the
        /// deployment is executed.
        /// </summary>
        [EnumMember(Value = "Modify")]
        Modify,
        /// <summary>
        /// The property is an array and contains nested changes.
        /// </summary>
        [EnumMember(Value = "Array")]
        Array
    }
    internal static class PropertyChangeTypeEnumExtension
    {
        internal static string ToSerializedValue(this PropertyChangeType? value)
        {
            return value == null ? null : ((PropertyChangeType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this PropertyChangeType value)
        {
            switch( value )
            {
                case PropertyChangeType.Create:
                    return "Create";
                case PropertyChangeType.Delete:
                    return "Delete";
                case PropertyChangeType.Modify:
                    return "Modify";
                case PropertyChangeType.Array:
                    return "Array";
            }
            return null;
        }

        internal static PropertyChangeType? ParsePropertyChangeType(this string value)
        {
            switch( value )
            {
                case "Create":
                    return PropertyChangeType.Create;
                case "Delete":
                    return PropertyChangeType.Delete;
                case "Modify":
                    return PropertyChangeType.Modify;
                case "Array":
                    return PropertyChangeType.Array;
            }
            return null;
        }
    }
}

// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ExecutionState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExecutionState
    {
        [EnumMember(Value = "queued")]
        Queued,
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "terminating")]
        Terminating,
        [EnumMember(Value = "succeeded")]
        Succeeded,
        [EnumMember(Value = "failed")]
        Failed
    }
    internal static class ExecutionStateEnumExtension
    {
        internal static string ToSerializedValue(this ExecutionState? value)
        {
            return value == null ? null : ((ExecutionState)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this ExecutionState value)
        {
            switch( value )
            {
                case ExecutionState.Queued:
                    return "queued";
                case ExecutionState.Running:
                    return "running";
                case ExecutionState.Terminating:
                    return "terminating";
                case ExecutionState.Succeeded:
                    return "succeeded";
                case ExecutionState.Failed:
                    return "failed";
            }
            return null;
        }

        internal static ExecutionState? ParseExecutionState(this string value)
        {
            switch( value )
            {
                case "queued":
                    return ExecutionState.Queued;
                case "running":
                    return ExecutionState.Running;
                case "terminating":
                    return ExecutionState.Terminating;
                case "succeeded":
                    return ExecutionState.Succeeded;
                case "failed":
                    return ExecutionState.Failed;
            }
            return null;
        }
    }
}
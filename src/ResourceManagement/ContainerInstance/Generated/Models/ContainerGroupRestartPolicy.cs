// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.


using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.ContainerInstance.Fluent.Models
{

    /// <summary>
    /// Defines values for ContainerGroupRestartPolicy.
    /// </summary>
    [JsonConverter(typeof(ExpandableStringEnumConverter<ContainerGroupRestartPolicy>))]
    public class ContainerGroupRestartPolicy : ExpandableStringEnum<ContainerGroupRestartPolicy>
    {
        public static readonly ContainerGroupRestartPolicy Always = Parse("always");
        public static readonly ContainerGroupRestartPolicy OnFailure = Parse("onFailure");
        public static readonly ContainerGroupRestartPolicy Never = Parse("never");
    }
}

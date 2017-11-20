// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    using Microsoft.Azure.Management.ContainerService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for Container Service storage profile types.
    /// </summary>
    public class StorageProfileTypes :
        ExpandableStringEnum<Microsoft.Azure.Management.ContainerService.Fluent.StorageProfileTypes>
    {
        public static readonly StorageProfileTypes ManagedDisks = Parse(ContainerServiceStorageProfileTypes.ManagedDisks);
        public static readonly StorageProfileTypes StorageAccount = Parse(ContainerServiceStorageProfileTypes.StorageAccount);
    }
}

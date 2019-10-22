// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithImport
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;

    /// <summary>
    /// The template for a key vault update operation, with a new key version to be imported.
    /// </summary>
    public interface IUpdateWithImport :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithHsm
    {
    }
}
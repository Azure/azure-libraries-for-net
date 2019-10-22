// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.KeyVault.Fluent.Key.UpdateWithCreate
{
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Update;

    /// <summary>
    /// The template for a key vault update operation, with a new key version to be created.
    /// </summary>
    public interface IUpdateWithCreate :
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IUpdate,
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Update.IWithKeySize
    {
    }
}
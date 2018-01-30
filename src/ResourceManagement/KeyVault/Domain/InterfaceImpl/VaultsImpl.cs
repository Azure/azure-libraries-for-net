// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Keyvault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VaultsImpl 
    {
        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup.DeleteByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByResourceGroupAsync(resourceGroupName, name, cancellationToken);
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IVault> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IVault>;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<Microsoft.Azure.Management.KeyVault.Fluent.IVault> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>.ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, cancellationToken) as Microsoft.Azure.Management.KeyVault.Fluent.IVault;
        }
    }
}
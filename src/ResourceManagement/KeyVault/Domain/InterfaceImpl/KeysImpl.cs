// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Keyvault.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Keyvault;
    using Microsoft.Azure.Keyvault.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Rx.Functions;

    internal partial class KeysImpl 
    {
        /// <summary>
        /// Restores a backup key into a Key Vault key.
        /// </summary>
        /// <param name="backup">The backup key.</param>
        /// <return>The key restored from the backup.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.IKey Microsoft.Azure.Management.KeyVault.Fluent.IKeys.Restore(params byte[] backup)
        {
            return this.Restore(backup) as Microsoft.Azure.Management.KeyVault.Fluent.IKey;
        }

        /// <summary>
        /// Restores a backup key into a Key Vault key.
        /// </summary>
        /// <param name="backup">The backup key.</param>
        /// <return>The key restored from the backup.</return>
        async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> Microsoft.Azure.Management.KeyVault.Fluent.IKeys.RestoreAsync(byte[] backup, CancellationToken cancellationToken)
        {
            return await this.RestoreAsync(backup, cancellationToken) as Microsoft.Azure.Management.KeyVault.Fluent.IKey;
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
        Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Microsoft.Azure.Management.KeyVault.Fluent.Key.Definition.IBlank;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.KeyVault.Fluent.IKey> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.KeyVault.Fluent.IKey>.GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await this.GetByIdAsync(id, cancellationToken) as Microsoft.Azure.Management.KeyVault.Fluent.IKey;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">The id of the resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.KeyVault.Fluent.IKey Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.KeyVault.Fluent.IKey>.GetById(string id)
        {
            return this.GetById(id) as Microsoft.Azure.Management.KeyVault.Fluent.IKey;
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">The resource ID of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
 
            await this.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.KeyVault.Fluent.IKey>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.KeyVault.Fluent.IKey>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IKey>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.KeyVault.Fluent.IKey>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IKey>;
        }
    }
}
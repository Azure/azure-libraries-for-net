// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class BatchAccountImpl
    {
        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount);
        }

        /// <summary>
        /// Removes the associated storage account.
        /// </summary>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithoutStorageAccount()
        {
            return this.WithoutStorageAccount();
        }

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">The definition of the storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable)
        {
            return this.WithNewStorageAccount(storageAccountCreatable);
        }

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName);
        }

        /// <summary>
        /// Gets the pool quota for this Batch account.
        /// </summary>
        int Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.PoolQuota
        {
            get
            {
                return this.PoolQuota();
            }
        }

        /// <return>The access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.GetKeys()
        {
            return Extensions.Synchronize(() => this.GetKeysAsync());
        }

        /// <summary>
        /// Gets the core quota for this Batch account.
        /// </summary>
        int? Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.CoreQuota
        {
            get
            {
                return this.CoreQuota();
            }
        }

        /// <summary>
        /// Gets the properties and status of any auto storage account associated with the Batch account.
        /// </summary>
        AutoStorageProperties Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.AutoStorage
        {
            get
            {
                return this.AutoStorage();
            }
        }

        /// <summary>
        /// Gets Batch account endpoint.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.AccountEndpoint
        {
            get
            {
                return this.AccountEndpoint();
            }
        }

        /// <summary>
        /// Gets the provisioned state of the resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the active job and job schedule quota for this Batch account.
        /// </summary>
        int Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.ActiveJobAndJobScheduleQuota
        {
            get
            {
                return this.ActiveJobAndJobScheduleQuota();
            }
        }

        /// <summary>
        ///Gets a value indicating whether the core quota for the Batch Account is enforced per Virtual Machine family or not.
        /// </summary>
        bool IBatchAccount.DedicatedCoreQuotaPerVMFamilyEnforced
        {
            get
            {
                return this.DedicatedCoreQuotaPerVMFamilyEnforced();
            }
        }

        /// <summary>
        /// Gets a list of the dedicated core quota per Virtual Machine family for the Batch account.
        /// </summary>
        IList<VirtualMachineFamilyCoreQuota> IBatchAccount.DedicatedCoreQuotaPerVMFamily
        {
            get
            {
                return this.DedicatedCoreQuotaPerVMFamily();
            }
        }

        /// <summary>
        /// Synchronizes the storage account keys for this Batch account.
        /// </summary>
        void Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.SynchronizeAutoStorageKeys()
        {
            Extensions.Synchronize(() => this.SynchronizeAutoStorageKeysAsync()); ;
        }

        /// <summary>
        /// Regenerates the access keys for the Batch account.
        /// </summary>
        /// <param name="keyType">The type if key to regenerate.</param>
        /// <return>Regenerated access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.RegenerateKeys(AccountKeyType keyType)
        {
            return Extensions.Synchronize(() => this.RegenerateKeysAsync(keyType));
        }

        /// <summary>
        /// Gets applications in this Batch account, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Azure.Management.Batch.Fluent.IApplication> Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.Applications
        {
            get
            {
                return this.Applications();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount);
        }

        /// <summary>
        /// Specifies a new storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created along with and used in the Batch account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable)
        {
            return this.WithNewStorageAccount(storageAccountCreatable);
        }

        /// <summary>
        /// Specifies the name of a new storage account to be created and associated with this Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName);
        }

        /// <summary>
        /// Begins the description of an update of an existing Batch application in this Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name of the application to be updated.</param>
        /// <return>The first stage of a Batch application update.</return>
        Application.Update.IUpdate BatchAccount.Update.IWithApplication.UpdateApplication(string applicationId)
        {
            return this.UpdateApplication(applicationId);
        }

        /// <summary>
        /// Removes the specified application from the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application to be removed.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithApplication.WithoutApplication(string applicationId)
        {
            return this.WithoutApplication(applicationId);
        }

        /// <summary>
        /// Starts a definition of an application to be created in the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application.</param>
        /// <return>The first stage of a Batch application definition.</return>
        Application.UpdateDefinition.IBlank<BatchAccount.Update.IUpdate> BatchAccount.Update.IWithApplication.DefineNewApplication(string applicationId)
        {
            return this.DefineNewApplication(applicationId);
        }

        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch application.
        /// </summary>
        /// <param name="applicationId">The id of the application to create.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IBlank<BatchAccount.Definition.IWithApplicationAndStorage> BatchAccount.Definition.IWithApplication.DefineNewApplication(string applicationId)
        {
            return this.DefineNewApplication(applicationId);
        }

        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch pool.
        /// </summary>
        /// <param name="poolId">The id of the pool to create.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IBlank<BatchAccount.Definition.IWithPool> BatchAccount.Definition.IWithPool.DefineNewPool(string poolId)
        {
            return this.DefineNewPool(poolId);
        }

        /// <summary>
        /// Starts a definition of a pool to be created in the Batch account.
        /// </summary>
        /// <param name="poolId">The reference name for the pool.</param>
        /// <return>The first stage of a Batch pool definition.</return>
        Pool.UpdateDefinition.IBlank<BatchAccount.Update.IUpdate> BatchAccount.Update.IWithPool.DefineNewPool(string poolId)
        {
            return this.DefineNewPool(poolId);
        }

        /// <summary>
        /// Begins the description of an update of an existing Batch pool in this Batch account.
        /// </summary>
        /// <param name="poolId">The reference name of the pool to be updated.</param>
        /// <return>The first stage of a Batch pool update.</return>
        Pool.Update.IUpdate BatchAccount.Update.IWithPool.UpdatePool(string poolId)
        {
            return this.UpdatePool(poolId);
        }

        /// <summary>
        /// Removes the specified pool from the Batch account.
        /// </summary>
        /// <param name="poolId">The reference name for the pool to be removed.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithPool.WithoutPool(string poolId)
        {
            return this.WithoutPool(poolId);
        }

        /// <summary>
        /// Gets pool in this Batch account, indexed by name.
        /// </summary>
        IReadOnlyDictionary<string, Fluent.IPool> IBatchAccount.Pools
        {
            get
            {
                return this.Pools();
            }
        }
    }
}
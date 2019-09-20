// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update
{
    /// <summary>
    /// The stage of a Batch account update allowing to specify a storage account.
    /// </summary>
    public interface IWithStorageAccount
    {
        /// <summary>
        /// Removes the associated storage account.
        /// </summary>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutStorageAccount();

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">The definition of the storage account.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithNewStorageAccount(ResourceManager.Fluent.Core.ResourceActions.ICreatable<Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithNewStorageAccount(string storageAccountName);

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithExistingStorageAccount(Storage.Fluent.IStorageAccount storageAccount);
    }

    /// <summary>
    /// The template for a Batch account update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate :
        ResourceManager.Fluent.Core.ResourceActions.IAppliable<IBatchAccount>,
        ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<IUpdate>,
        IWithStorageAccount,
        IWithApplication
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch application.
    /// </summary>
    public interface IWithApplication
    {
        /// <summary>
        /// Starts a definition of an application to be created in the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application.</param>
        /// <return>The first stage of a Batch application definition.</return>
        Application.UpdateDefinition.IBlank<IUpdate> DefineNewApplication(string applicationId);

        /// <summary>
        /// Removes the specified application from the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application to be removed.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutApplication(string applicationId);

        /// <summary>
        /// Begins the description of an update of an existing Batch application in this Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name of the application to be updated.</param>
        /// <return>The first stage of a Batch application update.</return>
        Application.Update.IUpdate UpdateApplication(string applicationId);
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch pool.
    /// </summary>
    public interface IWithPool
    {
        /// <summary>
        /// Starts a definition of a pool to be created in the Batch account.
        /// </summary>
        /// <param name="poolId">The reference name for the pool.</param>
        /// <return>The first stage of a Batch pool definition.</return>
        Pool.UpdateDefinition.IBlank<IUpdate> DefineNewPool(string poolId);

        /// <summary>
        /// Begins the description of an update of an existing Batch pool in this Batch account.
        /// </summary>
        /// <param name="poolId">The reference name of the pool to be updated.</param>
        /// <return>The first stage of a Batch pool update.</return>
        Pool.Update.IUpdate UpdatePool(string poolId);

        /// <summary>
        /// Removes the specified pool from the Batch account.
        /// </summary>
        /// <param name="poolId">The reference name for the pool to be removed.</param>
        /// <return>The next stage of the update.</return>
        IUpdate WithoutPool(string poolId);
    }
}
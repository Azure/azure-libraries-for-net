// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition
{
    /// <summary>
    /// The stage of a Batch account definition allowing the adding of a Batch application or creating the Batch account.
    /// </summary>
    public interface IWithCreateAndApplication :
        IWithCreate,
        IWithApplicationAndStorage,
        IWithPool
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing to associate storage accounts with the Batch account.
    /// </summary>
    public interface IWithStorage
    {
        /// <summary>
        /// Specifies a new storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created along with and used in the Batch account.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithNewStorageAccount(ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable);

        /// <summary>
        /// Specifies the name of a new storage account to be created and associated with this Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithNewStorageAccount(string storageAccountName);

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        IWithCreate WithExistingStorageAccount(Storage.Fluent.IStorageAccount storageAccount);
    }

    /// <summary>
    /// A Batch account definition with sufficient inputs to create a new
    /// Batch account in the cloud, but exposing additional optional inputs to specify.
    /// </summary>
    public interface IWithCreate :
        ResourceManager.Fluent.Core.ResourceActions.ICreatable<IBatchAccount>,
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<IWithCreate>
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing adding an application and a storage account.
    /// </summary>
    public interface IWithApplicationAndStorage :
        IWithStorage,
        IWithApplication
    {
    }

    /// <summary>
    /// The first stage of a Batch account definition.
    /// </summary>
    public interface IBlank :
        ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<IWithGroup>
    {
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch application.
    /// </summary>
    public interface IWithApplication
    {
        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch application.
        /// </summary>
        /// <param name="applicationId">The id of the application to create.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IBlank<IWithApplicationAndStorage> DefineNewApplication(string applicationId);
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the creation of a Batch pool.
    /// </summary>
    public interface IWithPool
    {
        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch pool.
        /// </summary>
        /// <param name="poolId">The id of the pool to create.</param>
        /// <return>The next stage of the definition.</return>
        Pool.Definition.IBlank<IWithPool> DefineNewPool(string poolId);
    }

    /// <summary>
    /// The stage of a Batch account definition allowing the resource group to be specified.
    /// </summary>
    public interface IWithGroup :
        ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<IWithCreateAndApplication>
    {
    }

    /// <summary>
    /// The entirety of a Batch account definition.
    /// </summary>
    public interface IDefinition :
        IBlank,
        IWithGroup,
        IWithCreate,
        IWithApplicationAndStorage,
        IWithCreateAndApplication,
        IWithApplication,
        IWithStorage,
        IWithPool
    {
    }
}
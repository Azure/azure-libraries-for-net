// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.ITroubleshooting>
    {
    }

    /// <summary>
    /// Sets the storage account to save the troubleshoot result.
    /// </summary>
    public interface IWithStorageAccount
    {
        /// <summary>
        /// Set the storageAccounId value.
        /// </summary>
        /// <param name="storageAccountId">The ID for the storage account to save the troubleshoot result.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithStoragePath WithStorageAccount(string storageAccountId);
    }

    /// <summary>
    /// Sets the path to the blob to save the troubleshoot result in.
    /// </summary>
    public interface IWithStoragePath
    {
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithExecute WithStoragePath(string storagePath);
    }

    /// <summary>
    /// The first stage of troubleshooting parameters definition.
    /// </summary>
    public interface IWithTargetResource
    {
        /// <summary>
        /// Set the targetResourceId value (virtual network gateway or virtual network gateway connecyion id).
        /// </summary>
        /// <param name="targetResourceId">The targetResourceId value to set.</param>
        /// <return>The next stage of definition.</return>
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithStorageAccount WithTargetResourceId(string targetResourceId);
    }

    /// <summary>
    /// The entirety of troubleshooting parameters definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithTargetResource,
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithStorageAccount,
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithStoragePath,
        Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition.IWithExecute
    {
    }
}
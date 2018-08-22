// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to getting a specific resource based on its name.
    /// (Note this interface is not intended to be implemented by user code.).
    /// </summary>
    /// <typeparam name="T">The type of the resource collection.</typeparam>
    public interface ISupportsGettingByNameAsync<T> :
        ISupportsGettingByName<T>
    {
    }
}
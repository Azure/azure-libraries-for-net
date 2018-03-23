// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Server Key.
    /// </summary>
    public interface ISqlServerKey  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServerKeyInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlServerKey.Update.IUpdate>
    {
        /// <summary>
        /// Gets the server key type.
        /// </summary>
        Models.ServerKeyType ServerKeyType { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this DNS alias belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the kind of encryption protector; this is metadata used for the Azure Portal experience.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the thumbprint of the server key.
        /// </summary>
        string Thumbprint { get; }

        /// <summary>
        /// Deletes the DNS alias asynchronously.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the resource location.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets the server key creation date.
        /// </summary>
        System.DateTime? CreationDate { get; }

        /// <summary>
        /// Gets the URI of the server key.
        /// </summary>
        string Uri { get; }

        /// <summary>
        /// Deletes the DNS alias.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }
    }
}
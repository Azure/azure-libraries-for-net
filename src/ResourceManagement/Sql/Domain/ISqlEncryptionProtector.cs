// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Encryption Protector.
    /// </summary>
    public interface ISqlEncryptionProtector  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.EncryptionProtectorInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlEncryptionProtector.Update.IUpdate>
    {
        /// <summary>
        /// Gets the encryption protector type.
        /// </summary>
        Models.ServerKeyType ServerKeyType { get; }

        /// <summary>
        /// Gets the name of the server key.
        /// </summary>
        string ServerKeyName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this DNS alias belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the kind of encryption protector; this is metadata used for the Azure Portal experience.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets thumbprint of the server key.
        /// </summary>
        string Thumbprint { get; }

        /// <summary>
        /// Gets the resource location.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Region { get; }

        /// <summary>
        /// Gets the URI of the server key.
        /// </summary>
        string Uri { get; }

        /// <summary>
        /// Gets the parent SQL server ID.
        /// </summary>
        string ParentId { get; }
    }
}
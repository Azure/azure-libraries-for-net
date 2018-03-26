// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;
    using System;

    /// <summary>
    /// The template for a SQL Firewall Rule update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update.IWithThumbprint,
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update.IWithCreationDate,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlServerKey>
    {
    }

    /// <summary>
    /// The SQL Server Key definition to set the thumbprint.
    /// </summary>
    public interface IWithThumbprint  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the thumbprint of the server key.
        /// </summary>
        /// <param name="thumbprint">The thumbprint of the server key.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update.IUpdate WithThumbprint(string thumbprint);
    }

    /// <summary>
    /// The SQL Server Key definition to set the server key creation date.
    /// </summary>
    public interface IWithCreationDate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Sets the server key creation date.
        /// </summary>
        /// <param name="creationDate">The server key creation date.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlServerKey.Update.IUpdate WithCreationDate(DateTime creationDate);
    }
}
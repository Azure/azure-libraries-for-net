// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Database export operation request.
    /// </summary>
    public interface ISqlDatabaseExportRequest  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ExportRequest>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabaseImportExportResponse>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>
    {
    }
}
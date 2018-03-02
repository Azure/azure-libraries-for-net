// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// Response containing the Azure SQL Active Directory administrator.
    /// </summary>
    public interface ISqlActiveDirectoryAdministrator  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the server administrator login value.
        /// </summary>
        string SignInName { get; }

        /// <summary>
        /// Gets the type of administrator.
        /// </summary>
        string AdministratorType { get; }

        /// <summary>
        /// Gets the server Active Directory Administrator tenant ID.
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets the server administrator ID.
        /// </summary>
        string Id { get; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    internal partial class SqlActiveDirectoryAdministratorImpl 
    {
        /// <summary>
        /// Gets the server Active Directory Administrator tenant ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator.TenantId
        {
            get
            {
                return this.TenantId();
            }
        }

        /// <summary>
        /// Gets the server administrator login value.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator.SignInName
        {
            get
            {
                return this.SignInName();
            }
        }

        /// <summary>
        /// Gets the type of administrator.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator.AdministratorType
        {
            get
            {
                return this.AdministratorType();
            }
        }

        /// <summary>
        /// Gets the server administrator ID.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlActiveDirectoryAdministrator.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}
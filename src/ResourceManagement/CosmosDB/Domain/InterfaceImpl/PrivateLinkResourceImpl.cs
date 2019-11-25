// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    internal partial class PrivateLinkResourceImpl
    {
        /// <summary>
        /// Gets the private link resource group id.
        /// </summary>
        /// <summary>
        /// Gets the groupId value.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource.GroupId
        {
            get
            {
                return this.GroupId();
            }
        }

        /// <summary>
        /// Gets the id value.
        /// </summary>
        /// <summary>
        /// Gets the id value.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name value.
        /// </summary>
        /// <summary>
        /// Gets the name value.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the private link resource required member names.
        /// </summary>
        /// <summary>
        /// Gets the requiredMembers value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource.RequiredMembers
        {
            get
            {
                return this.RequiredMembers();
            }
        }

        /// <summary>
        /// Gets the type value.
        /// </summary>
        /// <summary>
        /// Gets the type value.
        /// </summary>
        string Microsoft.Azure.Management.CosmosDB.Fluent.IPrivateLinkResource.Type
        {
            get
            {
                return this.Type();
            }
        }
    }
}
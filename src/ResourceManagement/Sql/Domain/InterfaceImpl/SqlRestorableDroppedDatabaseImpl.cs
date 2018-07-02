// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SqlRestorableDroppedDatabaseImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the earliest restore date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.EarliestRestoreDate
        {
            get
            {
                return this.EarliestRestoreDate();
            }
        }

        /// <summary>
        /// Gets the service level objective name of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the elastic pool name of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName();
            }
        }

        /// <summary>
        /// Gets the deletion date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.DeletionDate
        {
            get
            {
                return this.DeletionDate();
            }
        }

        /// <summary>
        /// Gets the max size in bytes of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.MaxSizeBytes
        {
            get
            {
                return this.MaxSizeBytes();
            }
        }

        /// <summary>
        /// Gets the creation date of the database (ISO8601 format).
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets the edition of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.Edition
        {
            get
            {
                return this.Edition();
            }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the geo-location where the resource lives.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.Sql.Fluent.ISqlRestorableDroppedDatabase.Region
        {
            get
            {
                return this.Region();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}
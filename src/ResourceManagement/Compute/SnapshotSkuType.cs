// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Defines values for SnapshotSkuType.
    /// </summary>
    public class SnapshotSkuType : IBeta
    {
        private static IDictionary<string, SnapshotSkuType> ValuesByName;

        /// <summary>
        /// Known snapshot SKU types.
        /// </summary>
        /// <returns></returns>

        public static IEnumerable<SnapshotSkuType> Values
        {
            get
            {
                return (ValuesByName != null) ? ValuesByName.Values : null;
            }
        }

        /// <summary>
        /// Static value StandardLRS for DiskSkuTypes.
        /// </summary>
        public static readonly SnapshotSkuType StandardLRS = new SnapshotSkuType(SnapshotStorageAccountTypes.StandardLRS);
        /// <summary>
        /// Static value PremiumLRS for DiskSkuTypes.
        /// </summary>
        public static readonly SnapshotSkuType PremiumLRS = new SnapshotSkuType(SnapshotStorageAccountTypes.PremiumLRS);

        private SnapshotStorageAccountTypes value;

        /// <summary>
        /// Creates a custom value for DiskSkuTypes.
        /// </summary>
        /// <param name="value">the custom value</param>
        public SnapshotSkuType(SnapshotStorageAccountTypes value)
        {
            if (ValuesByName == null)
            {
                ValuesByName = new Dictionary<string, SnapshotSkuType>();
            }

            ValuesByName[value.ToString().ToLower()] = this;
            this.value = value;
        }

        /// <summary>
        /// Parses a snapshot SKU type from a storage account type.
        /// </summary>
        /// <param name="value">a storage account type</param>
        /// <returns>a snapshot SKU type</returns>
        public static SnapshotSkuType FromStorageAccountType(SnapshotStorageAccountTypes value)
        {
            SnapshotSkuType result;
            if (ValuesByName == null)
            {
                return new SnapshotSkuType(value);
            }
            else if (ValuesByName.TryGetValue(value.ToString().ToLower(), out result))
            {
                return result;
            }
            else
            {
                return new SnapshotSkuType(value);
            }
        }

        /// <summary>
        /// Parses a value into a snapshot SKU type and creates a new SnapshotSkuType instance if not found among
        /// the existing ones.
        /// </summary>
        /// <param name="snapshotSku">a snapshot SKU type name</param>
        /// <returns>the parsed or created snapshot SKU type</returns>
        public static SnapshotSkuType FromSnapshotSku(SnapshotSku snapshotSku)
        {
            if (snapshotSku == null || snapshotSku.Name == null)
            {
                return null;
            }
            else
            {
                return FromStorageAccountType(snapshotSku.Name);
            }
        }

        public SnapshotStorageAccountTypes AccountType
        {
            get
            {
                return this.value;
            }
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(SnapshotSkuType lhs, SnapshotSkuType rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SnapshotSkuType lhs, SnapshotSkuType rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is SnapshotSkuType))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            SnapshotSkuType rhs = (SnapshotSkuType)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value.ToString());
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
